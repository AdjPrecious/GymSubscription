using Entity.EnumData;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    public class Subscription
    {
        public Guid SubscriptionID { get; set; }
        
        public Guid PlanID { get; set; }
        public Plan? Plan { get; set; }

        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set; }
        public SubscriptionStatus Status { get; set; }

        public DateTime CreatedAt { get; set;}
        public DateTime UpdatedAt { get; set;}
    }
}
