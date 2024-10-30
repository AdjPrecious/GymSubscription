using Contract;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SubscriptionRepository : RepositoryBase<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateSubscription(Subscription subscription) => await CreateAsync(subscription);
       

        public void DeleteSubscription(Subscription subscription) => Delete(subscription);
       

        public async Task<IEnumerable<Subscription>> GetAllSubscriptionAsync() =>await FindAll().OrderBy(s => s.CreatedAt.ToString()).ToListAsync();
       

        public async Task<Subscription> GetSubscriptionByIdAsync(Guid Id) => await FindByCondition(s => s.SubscriptionID.Equals(Id)).FirstOrDefaultAsync();
       

        
       
       

        public void UpdateSubscription(Subscription subscription) => Update(subscription);
        
    }
}
