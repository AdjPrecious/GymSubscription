using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.PaymentDto
{
    public record PaymentDto
    {
        public Guid PaymentID { get; set; }
        
        public string UserID { get; set; }

        

        public Guid SubscriptionID { get; set; }
        
        public float AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }
        public bool isSuccessfull { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
