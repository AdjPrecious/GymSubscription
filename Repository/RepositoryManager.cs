using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<SubscriptionRepository> _subscriptionRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _subscriptionRepository = new Lazy<SubscriptionRepository>(() => new SubscriptionRepository(repositoryContext));
        }
        public ISubscriptionRepository Subscription => _subscriptionRepository.Value;

        public async Task SavechagesAsync() => await _repositoryContext.SaveChangesAsync();
        
    }
}
