using Entity.Model;
using Shared.DataTransferObjects.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IEmailService
    {
        Task AccountEmailAsync(UserForRegistrationDto UserForRegistrationDto);
    }
}
