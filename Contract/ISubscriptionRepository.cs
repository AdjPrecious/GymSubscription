using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetAllSubscriptionAsync();
        

        Task CreateSubscription(Subscription subscription);

        Task<Subscription> GetPaymentSubscriptionByIdAsync(Guid paymentId);
        void DeleteSubscription(Subscription subscription);
        void UpdateSubscription(Subscription subscription);

    }
}
