using Contract;
using Entity.EnumData;
using Entity.Model;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class JobService : IJobService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public JobService(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        public async Task UpdateSubscription()
        {
            _logger.LogInfo("Updating Subscription status....");

            try
            {
                var subscriptions = await _repositoryManager.Subscription.GetUsersExpiredSubscription();


                foreach (var subscription in subscriptions)
                {
                    subscription.Status = SubscriptionStatus.Expired;
                }

                await _repositoryManager.SavechagesAsync();

                _logger.LogInfo($"Updated {subscriptions.Count()} subscription(s) to 'Expired'. ");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
