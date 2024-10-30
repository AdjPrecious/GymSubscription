using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public class SubscriptionNotFoundException : NotFoundException
    {
        public SubscriptionNotFoundException(Guid SubscriptionId) : base($"Subscription with id: {SubscriptionId} doesn't exist in the dataase. ")
        {
        }
    }
}
