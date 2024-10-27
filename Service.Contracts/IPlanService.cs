using Shared.DataTransferObjects.PlanDto;

namespace Service
{
    public interface IPlanService
    {
        Task<IEnumerable<PlanDto>> GetAllPlansAsync();
        Task<PlanDto> CreatePlanAsync(CreatePlanDto createPlanDto);
        Task<PlanDto> GetPlanByIdAsync(Guid id);
        Task UpdatePlan(Guid PlanId, UpdatePlanDto updatePlanDto);
        Task DeletePlanAsync(Guid id);
    }
}