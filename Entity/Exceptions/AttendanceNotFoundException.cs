using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public class AttendanceNotFoundException : NotFoundException
    {
        public AttendanceNotFoundException(Guid id) : base($"Attendance with Id: {id} cannot be found" )
        {
        }
    }
}
