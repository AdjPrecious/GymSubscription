using Entity.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.PaymentDto;
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
    public class PaymentController : ControllerBase
    {
        private readonly IServiceManager _service;

        public PaymentController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("{id:guid}", Name = "GetPayment")]
        public async Task<IActionResult> GetPayment(Guid id)
        {
            var result = await _service.PaymentService.GetPaymentAsync(id);

            return Ok(result);
        }

        [HttpPost("CreatePayment")]
        public async Task<IActionResult> CreatePayment(CreatePaymentDto createPaymentDto)
        {
            var result = await _service.PaymentService.CreatePaymentAsync(createPaymentDto);

            
            return Ok(new {authorizationurl = result.Data.AuthorizationUrl});
           
        }

        [HttpPost("VerifyPayment")]
        public async Task<IActionResult> VerifyPayment(string reference)
        {
            if(!await _service.PaymentService.Verify(reference))
                throw new InvalidPaymentBadException();

            return NoContent();
        } 

    }
}
