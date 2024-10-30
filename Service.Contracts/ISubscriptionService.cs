using Shared.DataTransferObjects.SubscriptionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionDto>> GetAllSubScription();
        Task<SubscriptionDto> GetSubscriptionById(Guid subscriptionId);
        Task<SubscriptionDto> CreateSubscription(CreateSubscriptionDto createSubscriptionDto);
    }
}
