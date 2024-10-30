using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.PlanDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSubscription.Presentation.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[Controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IServiceManager _service;

        public PlanController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("Allplan")]
        public async Task<IActionResult> GetPlans()
        {
            var plans = await _service.PlanService.GetAllPlansAsync();

            return Ok(plans);
        }

        [HttpPost( "CreatePlan")]
        public async Task<IActionResult> CreatePlan(CreatePlanDto createPlanDto)
        {
            var result = await _service.PlanService.CreatePlanAsync(createPlanDto);

            return CreatedAtRoute("GetPlanById", new { id = result.PlanId }, result);
        }

        [HttpGet("{id:guid}", Name = "GetPlanById")]
        public async Task<IActionResult> GetPlan(Guid id)
        {
            var plan = await _service.PlanService.GetPlanByIdAsync(id);

            return Ok(plan);
        }

        [HttpPut("{id:guid}", Name = "UpdatePlan")]
        public async Task<IActionResult> UpdatePlan(UpdatePlanDto updatePlanDto)
        {
            await _service.PlanService.UpdatePlan( updatePlanDto);

            return NoContent();
        }

        [HttpDelete("{id:guid}", Name = "DeletePlan")]
        public async Task<IActionResult> DeletePlan(Guid id)
        {
            await _service.PlanService.DeletePlanAsync(id);
            return NoContent();
        }
    }
}
