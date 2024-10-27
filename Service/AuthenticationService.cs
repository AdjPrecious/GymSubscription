using AutoMapper;
using Contract;
using Entity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Entity.Exceptions;
using Shared.DataTransferObjects.UserDto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Entity.ConfigurationModels;
using System.Xml.Linq;



namespace Service
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<User> _roleManager;
        private readonly IOptions<JwtConfiguration> _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JwtConfiguration _jwtConfiguration;
        private User? _user;

        public AuthenticationService(ILoggerManager logger,
                                     IMapper mapper,
                                     UserManager<User> userManager,
                                     
                                     IOptions<JwtConfiguration> configuration,
                                     IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
           
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _jwtConfiguration = _configuration.Value;
        }
       

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto)
        {
            var user = _mapper.Map<User>(userForRegistrationDto);
            

            var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password);
            

            if (result.Succeeded) 
                await _userManager.AddToRoleAsync(user, userForRegistrationDto.Role);
            return result;
        }

        public async Task<TokenDto> CreateToken(bool populateExp)
            {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var refreshToken = GenerateRefreshToken();

            _user.RefreshToken = refreshToken;

            if (populateExp)
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

            await _userManager.UpdateAsync(_user);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new TokenDto(accessToken, refreshToken);


        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials,
            List<Claim> claims)
        {
            
            var tokenOptions = new JwtSecurityToken
            (
            issuer: _jwtConfiguration.ValidIssuer,
            audience: _jwtConfiguration.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguration.Expires)),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name, _user.Email)
            };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _user = await _userManager.FindByEmailAsync(userForAuth.Email);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user,
           userForAuth.Password));
            if (!result)
                _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong user name or password.");
                return result;
        }



        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"))),
                ValidateLifetime = true,
                ValidIssuer = _jwtConfiguration.ValidIssuer,
                ValidAudience = _jwtConfiguration.ValidAudience
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out
           securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null ||
           !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
            StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }

        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);

            var user = await _userManager.FindByEmailAsync(principal.Identity.Name);

            if (user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new RefreshTokenBadRequest();

            _user = user;

            return await CreateToken(populateExp: false);
        }

        public async Task<string> ForgotPassword(string email)
        {
            _user = await _userManager.FindByEmailAsync(email);

            if (_user == null)
                throw new UserNotFoundException(email);

            var token = await _userManager.GeneratePasswordResetTokenAsync(_user);
            return token;
        }

        public async Task<IdentityResult> ResetPassword(PasswordResetDto passwordResetDto)
        {
            _user = await _userManager.FindByEmailAsync(passwordResetDto.Email);

            if (_user == null)
                throw new UserNotFoundException(passwordResetDto.Email);

            var resetPassword = await _userManager.ResetPasswordAsync(_user, passwordResetDto.Token, passwordResetDto.NewPassword);

            return resetPassword;
        }

        public async Task<IdentityResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var user =  _httpContextAccessor.HttpContext?.User?.Identity?.Name;

            if (user == null)
                throw new UserNotLoginException();

            _user = await _userManager.FindByEmailAsync(user);
           

            var result = await _userManager.ChangePasswordAsync(_user, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);

            return result;
        }

       


        

        
    }
}
