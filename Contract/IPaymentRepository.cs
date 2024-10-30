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

        Task<Payment> GetPaymentAsync(Guid id);

        Task CreatePaymentAsync(Payment payment);

        void DeletePayment(Payment payment);

        void UpdatePayment(Payment payment);

       
    }
}
