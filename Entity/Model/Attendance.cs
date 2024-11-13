using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model
{
    public class Attendance
    {
        public Guid AttendanceID { get; set; }

        
        public string? UserID { get; set; }
      
        public User? User { get; set; }

        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public TimeSpan? Duration {  get; set; }
       
        public DateTime? CreatedAt { get; set;}
    }
}
