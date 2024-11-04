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

        

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSubscription(Guid paymentid)
        {
            var result = await _service.SubscriptionService.GetPaymentSubscriptionById(paymentid);

            return Ok(result);  
        }

        [HttpPost(Name ="CreateSubscription")]
        public async Task<IActionResult> CreateSubscription(Guid paymentId)
        {
            var result = await _service.SubscriptionService.CreateSubscription( paymentId);

            return Ok(result);
        } 
    }
}
