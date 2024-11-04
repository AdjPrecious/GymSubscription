using Entity.EnumData;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    public class Payment
    {
        public Guid PaymentID { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }

        public float AmountPaid { get; set; }
        public DateTime PaymentDate { get; set;}
        public string? PaymentMethod {  get; set; }
        public bool isSuccessfull {  get; set; }
        public DateTime CreatedAt { get;set;}  
        public string? TransactionReference { get; set; }

        public Guid PlanID { get; set; }
        public Plan? Plan { get; set; }

       
        public Subscription Subscription { get; set; }
    }
}
