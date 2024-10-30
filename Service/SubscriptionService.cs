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
            var plan = await VerifyPlan(createSubscriptionDto);

            if (plan.Payment.isSuccessfull)
                throw new InvalidPaymentBadException();
                  
            var subscription = new Subscription()
            {
                CreatedAt = DateTime.Now,
                PlanID = plan.PlanID,
                Plan = plan,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(plan.DurationInDays),
                Status = SubscriptionStatus.Active,
            };

            await _repository.Subscription.CreateSubscription(subscription);
            await _repository.SavechagesAsync();

            var subscriptiontomap = _mapper.Map<SubscriptionDto>(subscription);

            return subscriptiontomap;
            


        }


        private async Task<Plan> VerifyPlan(CreateSubscriptionDto createSubscriptionDto)
        {
            var plan = await _repository.Plan.GetPlanAsync(createSubscriptionDto.PlanId);
            if (plan == null)
                throw new PlanNotFoundException(createSubscriptionDto.PlanId);
            return plan;
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
