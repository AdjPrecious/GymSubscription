using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.UserDto
{
    public record UpdateUserDto
    {
        [Required]
        public string? FirstName { get; init; }
        [Required]
        public string? LastName { get; init; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; init; }
        [Required]
        public string? UserName { get; init; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; init; }

        [Required]
        public string? Role { get; init; }
    }
}
