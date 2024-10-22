using AutoMapper;
using Contract;
using Entity.Model;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
       private readonly Lazy<ISubscriptionService> _subscriptionService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager)
        {
            _subscriptionService = new Lazy<ISubscriptionService>(() => new SubscriptionService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger,mapper,userManager));
        }
        public ISubscriptionService SubscriptionService => _subscriptionService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
