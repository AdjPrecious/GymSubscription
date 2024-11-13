using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSubscription.Presentation.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AttendanceController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("GetUserAttendance")]
        public async Task<IActionResult> GetUserAttendance(Guid userId, Guid attendanceId)
        {
            var result = await _service.AttendanceService.GetUserAttendance(userId, attendanceId);

            return Ok(result);
        }


        [HttpGet("GetAllUserAttendance")]
        public async Task<IActionResult> GetAllUserAttendance(Guid userId)
        {
            var result = await _service.AttendanceService.GetAllUserAttendances(userId);
            return Ok(result);
        }

        [HttpPost("Checkin")]
        public async Task<IActionResult> CheckIn(Guid userId)
        {
            var result = await _service.AttendanceService.CreateCheckIntime(userId);

            return Ok(result);

        }

        [HttpPut("CheckOut")]
        public async Task<IActionResult> CheckOut(Guid userId)
        {
            var result = await _service.AttendanceService.CreateCheckOuttime(userId);

            return Ok(result);
        }
    }
}
