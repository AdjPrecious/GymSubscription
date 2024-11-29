using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.UserDto
{
    public record ConfirmEmailDto
    {
        public string UserId {  get; init; }

        public string Token { get; init; }
    }
}
