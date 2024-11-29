using Entity.Model;
using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<(IdentityResult, string)> RegisterUser(UserForRegistrationDto userForRegistrationDto);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto);
        
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);

        Task<string> ForgotPassword(string email);

        Task<IdentityResult> ResetPassword(PasswordResetDto passwordResetDto);

        Task<IdentityResult> ChangePassword(ChangePasswordDto changePasswordDto);

        Task UpdateUserInfo(string email, UpdateUserDto updateUserDto);

        Task<IEnumerable<UserDto>> GetAllUserInfo(); 

        Task<UserDto> GetUserByEmail(string email);

        Task DeleteUser(string email);

        Task<IdentityResult> ConfirmEmail(ConfirmEmailDto confirmEmailDto);



    }
}
