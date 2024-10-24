using AutoMapper;
using Contract;
using Entity.Model;
using Service.Contracts;
using Shared.DataTransferObjects.PlanDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class PlanService : IPlanService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repository;

        public PlanService(ILoggerManager logger, IMapper mapper, IRepositoryManager repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PlanDto> CreatePlanAsync(CreatePlanDto createPlanDto)
        {
            var planEntity = _mapper.Map<Plan>(createPlanDto);

            await _repository.Plan.CreatePlanAsync(planEntity);
            await _repository.SavechagesAsync();

            var plantoreturn = _mapper.Map<PlanDto>(planEntity);

            return plantoreturn;
        }

        public async Task<IEnumerable<PlanDto>> GetAllPlansAsync()
        {
            var plans = await _repository.Plan.GetAllPlanAsync();

            var planDto = _mapper.Map<IEnumerable<PlanDto>>(plans);

            return planDto;
        }
    }
}
