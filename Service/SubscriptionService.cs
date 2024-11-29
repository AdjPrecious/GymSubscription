using AutoMapper;
using Contract;
using Entity.EnumData;
using Entity.Exceptions;
using Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects.SubscriptionDto;

namespace Service
{
    internal sealed class SubscriptionService : ISubscriptionService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
       

        public SubscriptionService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<SubscriptionDto> CreateSubscription(Guid paymentId)
        {
            var user = await GetUser();
            var payment = await GetPayment(paymentId, user);
            var plan = await _repository.Plan.GetPlanAsync(payment.PlanID);
            if(plan == null)
                throw new PlanNotFoundException(payment.PlanID);
            
            var subscription = new Subscription()
            {
                PaymentId = paymentId,
                Payment = payment,
                CreatedAt = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(plan.DurationInDays),
                Status = SubscriptionStatus.Active,
                
            };

            await _repository.Subscription.CreateSubscription(subscription);
            await _repository.SavechagesAsync();

            var subscriptiontomap = _mapper.Map<SubscriptionDto>(subscription);

            return subscriptiontomap;



        }

        private async Task<Payment> GetPayment(Guid paymentId, User? user)
        {
            var payment = await _repository.Payment.GetUserPaymentAsync(user.Id, paymentId);
            if(payment == null)
            
                throw new PaymentNotFoundException();
            
            if (!payment.isSuccessfull)
                throw new InvalidPaymentBadException();
            return payment;
        }

        private async Task<User?> GetUser()
        {
            var useremail = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
            if (useremail == null)
                throw new UserNotLoginException();
            var user = await _userManager.FindByEmailAsync(useremail);
            if (user == null)
                throw new UserNotFoundException();
            return user;
        }

      

        public async Task<SubscriptionDto> GetPaymentSubscriptionById(Guid paymentId)
        {
            var user = await GetUser();
            var payment = await GetPayment(paymentId, user);

            var subscription = await _repository.Subscription.GetPaymentSubscriptionByIdAsync(payment.PaymentID);

            if (subscription == null)
                throw new SubscriptionNotFoundException(payment.PaymentID);

            var subscriptionDto = _mapper.Map<SubscriptionDto>(subscription);

            return subscriptionDto;
        }
    }
}
