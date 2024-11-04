

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.SubscriptionDto
{
    public record SubscriptionDto
    {
        public Guid SubscriptionID { get; set; }
        

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }

        public Guid? PaymentID { get; set; }
       

        public DateTime CreatedAt { get; set; }
        
    }
}
