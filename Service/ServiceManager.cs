using AutoMapper;
using Contract;
using Entity.ConfigurationModels;
using Entity.Model;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly Lazy<IPaymentService> _paymentService;
        private readonly Lazy<IAttendanceService> _attendanceService; 
        private readonly Lazy<IEmailService> _emailService;
        

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager,  IOptions<JwtConfiguration> configuration, IOptions<EmailSettings> emailSettings, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _subscriptionService = new Lazy<ISubscriptionService>(() => new SubscriptionService(repositoryManager, logger, mapper, httpContextAccessor, userManager));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger,mapper,userManager,  configuration, httpContextAccessor));
            _planService = new Lazy<IPlanService>(() => new PlanService(logger, mapper, repositoryManager));
            _paymentService = new Lazy<IPaymentService>(() => new PaymentService(repositoryManager, logger, mapper, httpContextAccessor, userManager, config));

            _attendanceService = new Lazy<IAttendanceService>(() => new AttendanceService(repositoryManager, logger, mapper, userManager, configuration, httpContextAccessor));

            _emailService = new Lazy<IEmailService>(() => new EmailService( emailSettings));
        }
        public ISubscriptionService SubscriptionService => _subscriptionService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IPlanService PlanService => _planService.Value;

        public IPaymentService PaymentService => _paymentService.Value;

        public IAttendanceService AttendanceService => _attendanceService.Value;

        public IEmailService EmailService => _emailService.Value;
    }
}
