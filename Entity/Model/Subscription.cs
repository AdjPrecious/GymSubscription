using Entity.EnumData;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    public class Subscription
    {
        public Guid SubscriptionID { get; set; }
        
        public string? UserID { get; set; }

        public User? User { get; set; }
        
        public Guid PlanID { get; set; }
        public Plan? Plan { get; set; }

        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set; }
        public SubscriptionStatus Status { get; set; }

        public Guid? PaymentID { get; set; }
        public ICollection<Payment>? Payments { get; set; }

        public DateTime CreatedAt { get; set;}
        public DateTime UpdatedAt { get; set;}
    }
}
