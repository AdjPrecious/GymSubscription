using Entity.EnumData;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    public class Payment
    {
        public Guid PaymentID { get; set; }
        [ForeignKey(nameof(User))]
        public string UserID { get; set; }

        public User? User { get; set; }

        public Guid SubscriptionID { get; set; }
        public Subscription? Subscription { get; set; }
        public float AmountPaid { get; set; }
        public DateTime PaymentDate { get; set;}
        public string? PaymentMethod {  get; set; }
        public PaymentStatus PaymentStatus {  get; set; }
        public DateTime CreatedAt { get;set;}   
    }
}
