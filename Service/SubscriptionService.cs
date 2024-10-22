using AutoMapper;
using Contract;
using Service.Contracts;

namespace Service
{
    internal sealed class SubscriptionService : ISubscriptionService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SubscriptionService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
    }
}
