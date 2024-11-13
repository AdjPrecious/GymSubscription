using Contract;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class AttendanceRepository : RepositoryBase<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateAttendanceAsync(Attendance attendance) => await CreateAsync(attendance);
      

        public void DeleteAttendance(Attendance attendance) => Delete(attendance);
       

        public async Task<IEnumerable<Attendance>> GetAllUserAttendanceAsync(string Userid) => await FindAll().Where( a => a.UserID == Userid ).OrderBy( a => a.CreatedAt).ToListAsync();
      

        public async Task<Attendance> GetUserAttendanceAsync(string UserId, Guid id) => await FindByCondition(a => a.UserID == UserId && a.AttendanceID.Equals(id)).SingleOrDefaultAsync();
      

        public void UpdateAttendance(Attendance attendance) => Update(attendance);

        public async Task<Attendance> CheckAttendanceStatus(string userId) => await FindByCondition(a => a.UserID == userId && a.CheckInTime != null && a.CheckOutTime == null).SingleOrDefaultAsync();

        
      
    }
}
