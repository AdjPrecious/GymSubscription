using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public class EmailNotSentException : BadRequestException
    {
        public EmailNotSentException() : base("Unable to send email to user")
        {
        }
    }
}
