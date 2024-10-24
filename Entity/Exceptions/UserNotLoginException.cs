using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public class UserNotLoginException : NotFoundException
    {
        public UserNotLoginException() : base("User is not logged in")
        {
        }
    }
}
