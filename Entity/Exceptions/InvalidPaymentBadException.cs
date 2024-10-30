using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public class InvalidPaymentBadException : BadRequestException
    {
        public InvalidPaymentBadException() : base("Payment has not been completed successfully")
        {
        }
    }
}
