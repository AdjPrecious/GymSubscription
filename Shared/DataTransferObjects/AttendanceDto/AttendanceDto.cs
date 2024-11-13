using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.AttendanceDto
{
    public record AttendanceDto
    {
        public Guid AttendanceID { get; init; }


        public string? UserID { get; init; }

       

        public DateTime CheckInTime { get; init; }
        public DateTime CheckOutTime { get; init; }
        public TimeSpan Duration {  get; init; }
       
        public DateTime CreatedAt { get; init; }
    }
}
