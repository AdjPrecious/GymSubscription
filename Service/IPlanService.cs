using Shared.DataTransferObjects.PlanDto;

namespace Service
{
    public interface IPlanService
    {
        Task<IEnumerable<PlanDto>> GetAllPlansAsync();
        Task<PlanDto> CreatePlanAsync(CreatePlanDto createPlanDto);
    }
}