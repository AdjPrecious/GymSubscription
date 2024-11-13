using Contract;
using Entity.EnumData;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreatePaymentAsync(Payment payment) => await CreateAsync(payment);

        public void DeletePayment(Payment payment) => Delete(payment);

        

        public async Task<IEnumerable<Payment>> GetAllPaymentAsync() => await FindAll().OrderBy(p => p.CreatedAt).ToListAsync();
        

        public async Task<Payment> GetUserPaymentAsync(string userId, Guid paymentId) => await FindByCondition(p => p.UserId.Equals(userId) && p.PaymentID.Equals(paymentId)).FirstOrDefaultAsync();
      

        public void UpdatePayment(Payment payment) => Update(payment);

       
        public async Task<Payment> GetPaymentByReference(string reference) => await FindByCondition(p => p.TransactionReference.Equals(reference)).FirstOrDefaultAsync();

        public async Task<IEnumerable<Payment>> GetAllUserPaymentAsync(string userId) => await FindByCondition(p => p.UserId.Equals(userId)).ToListAsync();

        public async Task<Payment> GetUserFirstActivePayment(string userId) => await FindByCondition(p => p.UserId.Equals(userId) && p.Subscription.Status.Equals(SubscriptionStatus.Active)).FirstOrDefaultAsync();
      
    }
}
