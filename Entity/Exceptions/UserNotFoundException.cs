using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException() : base($"The user with email/name doesn't exist in the database")
        {
        }
    }
}
