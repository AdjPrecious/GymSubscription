using Contract;
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


        public async Task<IEnumerable<Payment>> GetAllPaymentAsync() => await FindAll().OrderBy(p => p.CreatedAt.ToString()).ToListAsync();
        

        public async Task<Payment> GetPaymentAsync(Guid id) => await FindByCondition(p => p.PaymentID == id).FirstOrDefaultAsync();
      

        public void UpdatePayment(Payment payment) => Update(payment);

        

        public async Task<Payment> GetPaymentByReference(string reference) => await FindByCondition(p => p.TransactionReference.Equals(reference)).FirstOrDefaultAsync();
       

    }
}
