using Entity.EnumData;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    public class Subscription
    {
        public Guid SubscriptionID { get; set; }

        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set; }
        public SubscriptionStatus Status { get; set; }

        public DateTime CreatedAt { get; set;}
        public DateTime UpdatedAt { get; set;}

        public Guid PaymentId { get; set; }

        public Payment Payment { get; set; }
    }
}
