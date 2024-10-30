using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public class PaymentNotFoundException : NotFoundException
    {
        public PaymentNotFoundException(Guid PaymentId) : base($"Payment with id: {PaymentId} Cannot be found in the database")
        {
        }
    }
}
