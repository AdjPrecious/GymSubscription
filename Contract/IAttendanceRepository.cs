using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAllUserAttendanceAsync(string Userid);

        Task<Attendance> GetUserAttendanceAsync(string UserId, Guid id);

        Task CreateAttendanceAsync(Attendance attendance);

        void DeleteAttendance(Attendance attendance);

        void UpdateAttendance(Attendance attendance);

        Task<Attendance> CheckAttendanceStatus(string userId);

    }
}
