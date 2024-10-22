using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record UserForRegistrationDto
    {
        [Required]
        public string? FirstName { get; init; }
        [Required]
        public string? LastName { get; init; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; init; }
        [Required]
        public string? UserName {  get; init; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; init; }
        
        [Required]
        public string? Role {  get; init; }
        
    }
}
