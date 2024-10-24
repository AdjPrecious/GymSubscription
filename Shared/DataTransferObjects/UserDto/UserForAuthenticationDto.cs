using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.UserDto
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