using Entity.Model;
using Shared.DataTransferObjects.AttendanceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAttendanceService
    {
        Task<AttendanceDto> CreateCheckIntime(Guid userId);
        Task<AttendanceDto> CreateCheckOuttime(Guid userId);
        Task<AttendanceDto> GetUserAttendance(Guid userId, Guid attendanceId);
        Task<IEnumerable<AttendanceDto>> GetAllUserAttendances(Guid userId);
    }
}
