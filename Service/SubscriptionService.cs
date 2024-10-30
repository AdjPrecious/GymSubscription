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

        public async Task<SubscriptionDto> CreateSubscription(CreateSubscriptionDto createSubscriptionDto)
        {
            var payment = await _repository.Payment.GetPaymentAsync(createSubscriptionDto.PaymentId);
            if (!payment.isSuccessfull)
                throw new InvalidPaymentBadException();
                  
            var subscription = new Subscription()
            {
                CreatedAt = DateTime.Now,
                PlanID = payment.PlanID,
                Plan = payment.Plan,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(payment.Plan.DurationInDays),
                Status = SubscriptionStatus.Active,
            };

            await _repository.Subscription.CreateSubscription(subscription);
            await _repository.SavechagesAsync();

            var subscriptiontomap = _mapper.Map<SubscriptionDto>(subscription);

            return subscriptiontomap;
            


        }


        


        public async Task<IEnumerable<SubscriptionDto>> GetAllSubScription()
        {
           var subscription = await _repository.Subscription.GetAllSubscriptionAsync();
           
            var subscriptionDto = _mapper.Map<IEnumerable<SubscriptionDto>>(subscription);

            return subscriptionDto;


        }

        public async Task<SubscriptionDto> GetSubscriptionById(Guid subscriptionId)
        {
            var subscription = await _repository.Subscription.GetSubscriptionByIdAsync(subscriptionId);

            if (subscription == null)
                throw new SubscriptionNotFoundException(subscriptionId);

            var subscriptionDto = _mapper.Map<SubscriptionDto>(subscription);

            return subscriptionDto;
        }
    }
}
