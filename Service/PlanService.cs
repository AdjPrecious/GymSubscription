using AutoMapper;
using Contract;
using Entity.Exceptions;
using Entity.Model;
using Service.Contracts;
using Shared.DataTransferObjects.PlanDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

            var plans = await _repository.Plan.GetAllPlanAsync();

            if (plans.Any(plan => string.Equals(plan.PlanName.Trim(), createPlanDto.PlanName.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                    throw new AlrealdyExistException(createPlanDto.PlanName);
            }

            var planEntity = _mapper.Map<Plan>(createPlanDto);

            await _repository.Plan.CreatePlanAsync(planEntity);
            
            await _repository.SavechagesAsync();

            var plantoreturn = _mapper.Map<PlanDto>(planEntity);

            return plantoreturn;
        }

        public async Task DeletePlanAsync(Guid id)
        {
            var plan = await _repository.Plan.GetPlanAsync(id);
            if (plan is null)
                throw new PlanNotFoundException(id);

            _repository.Plan.DeletePlan(plan);
            await _repository.SavechagesAsync();
        }

        public async Task<IEnumerable<PlanDto>> GetAllPlansAsync()
        {
            var plans = await _repository.Plan.GetAllPlanAsync();

            var planDto = _mapper.Map<IEnumerable<PlanDto>>(plans);

            return planDto;
        }

        public async Task<PlanDto> GetPlanByIdAsync(Guid id)
        {
            var plan = await _repository.Plan.GetPlanAsync(id);
            if (plan is null)
                throw new PlanNotFoundException(id);

            var plantdto = _mapper.Map<PlanDto>(plan);

            return plantdto;
        }

       

        public async Task UpdatePlan(Guid PlanId, UpdatePlanDto updatePlanDto)
        {
            var plan = await _repository.Plan.GetPlanAsync(PlanId);
            if (plan is null)
                throw new PlanNotFoundException(PlanId);

            var plans = await _repository.Plan.GetAllPlanAsync();

            if (plans.Any(plan => string.Equals(plan.PlanName.Trim(), updatePlanDto.PlanName.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                throw new AlrealdyExistException(updatePlanDto.PlanName);
            }
            _mapper.Map(updatePlanDto, plan);
            await _repository.SavechagesAsync();
        }
    }
}
