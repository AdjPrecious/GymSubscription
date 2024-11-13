using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IPaymentRepository
    {

        Task<IEnumerable<Payment>> GetAllPaymentAsync();

        Task<Payment> GetPaymentByReference(string reference);

        Task<Payment> GetUserPaymentAsync(string userid, Guid paymentId);

        Task CreatePaymentAsync(Payment payment);

        Task<IEnumerable<Payment>> GetAllUserPaymentAsync(string userId);

        Task<Payment> GetUserFirstActivePayment(string userId);

        void DeletePayment(Payment payment);

        void UpdatePayment(Payment payment);

       
    }
}
