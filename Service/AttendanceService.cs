using AutoMapper;
using Contract;
using Entity.ConfigurationModels;
using Entity.Exceptions;
using Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Service.Contracts;
using Shared.DataTransferObjects.AttendanceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class AttendanceService : IAttendanceService
    {
        private IRepositoryManager _repositoryManager;
        private ILoggerManager _logger;
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private IOptions<JwtConfiguration> _configuration;
        private IHttpContextAccessor _httpContextAccessor;
        private Attendance _attendance;

        public AttendanceService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IOptions<JwtConfiguration> configuration, IHttpContextAccessor httpContextAccessor)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AttendanceDto> CreateCheckIntime(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new UserNotFoundException(userId.ToString());

            var payment = await _repositoryManager.Payment.GetUserFirstActivePayment(user.Id);
            if (payment == null)
                throw new PaymentNotFoundException();

            var attendancestatus = await _repositoryManager.Attendance.CheckAttendanceStatus(userId.ToString());
            if (attendancestatus != null)
                throw new Exception("User has already check in");

            var attendance = new Attendance
            {
                CheckInTime = DateTime.Now,
                CreatedAt = DateTime.Now,
                UserID = user.Id,
                User = user,
            };

            await _repositoryManager.Attendance.CreateAttendanceAsync(attendance);
            await _repositoryManager.SavechagesAsync();

            var checkInTimeToReturn = _mapper.Map<AttendanceDto>(attendance);

            return checkInTimeToReturn;


        }

        public async Task<AttendanceDto> CreateCheckOuttime(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new UserNotFoundException(userId.ToString());

            var attendanceRecord = await _repositoryManager.Attendance.CheckAttendanceStatus(userId.ToString());

            if (attendanceRecord == null)
                throw new Exception("User has not chcked in or has already checkOut");


            attendanceRecord.CheckOutTime = DateTime.Now;
            attendanceRecord.Duration = (DateTime.Now - attendanceRecord.CheckInTime);

             _repositoryManager.Attendance.UpdateAttendance(attendanceRecord);
            await _repositoryManager.SavechagesAsync();

            var checkInTimeToReturn = _mapper.Map<AttendanceDto>(attendanceRecord);

            return checkInTimeToReturn;
        }

        public async Task<IEnumerable<AttendanceDto>> GetAllUserAttendances(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if(user is null)
                throw new UserNotFoundException(userId.ToString());

            var attemdance = await _repositoryManager.Attendance.GetAllUserAttendanceAsync(userId.ToString());

            var attendanceToReturn = _mapper.Map<IEnumerable<AttendanceDto>>(attemdance);

            return attendanceToReturn;


        }

        public async Task<AttendanceDto> GetUserAttendance(Guid userId, Guid attendanceId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is null)
                throw new UserNotFoundException(userId.ToString());

            var attendance = await _repositoryManager.Attendance.GetUserAttendanceAsync(userId.ToString(), attendanceId);
            if(attendance is null)
                throw new AttendanceNotFoundException(attendanceId);

            var attendanceToMap = _mapper.Map<AttendanceDto>(attendance);

            return attendanceToMap;

        }
    }
}
