using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.SubscriptionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSubscription.Presentation.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class SubscriptionController : ControllerBase
    {
        private readonly IServiceManager _service;

        public SubscriptionController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubscription()
        {
            var subscriptions = await _service.SubscriptionService.GetAllSubScription();

            return Ok(subscriptions);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSubscription(Guid id)
        {
            var result = _service.SubscriptionService.GetSubscriptionById(id);

            return Ok(result);  
        }

        [HttpPost(Name ="CreateSubscription")]
        public async Task<IActionResult> CreateSubscription(CreateSubscriptionDto createSubscriptionDto)
        {
            var result = await _service.SubscriptionService.CreateSubscription(createSubscriptionDto);

            return Ok(result);
        } 
    }
}
