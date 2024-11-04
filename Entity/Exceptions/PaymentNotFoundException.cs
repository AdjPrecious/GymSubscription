using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public class PaymentNotFoundException : NotFoundException
    {
        public PaymentNotFoundException() : base($"Payment Cannot be found in the database")
        {
        }
    }
}
