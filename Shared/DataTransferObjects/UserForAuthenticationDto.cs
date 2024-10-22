using System.ComponentModel.DataAnnotations;

namespace Service.Contracts
{
    public record UserForAuthenticationDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; init; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; init; }
    }
}