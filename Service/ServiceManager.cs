using AutoMapper;
using Contract;
using Entity.ConfigurationModels;
using Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
        private readonly Lazy<IPlanService> _planService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IOptions<JwtConfiguration> configuration, IHttpContextAccessor httpContextAccessor)
        {
            _subscriptionService = new Lazy<ISubscriptionService>(() => new SubscriptionService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger,mapper,userManager, configuration, httpContextAccessor));
            _planService = new Lazy<IPlanService>(() => new PlanService(logger, mapper, repositoryManager));
        }
        public ISubscriptionService SubscriptionService => _subscriptionService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IPlanService PlanService => throw new NotImplementedException();
    }
}
