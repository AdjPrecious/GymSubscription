using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public sealed class PlanNotFoundException : NotFoundException
    {
        public PlanNotFoundException(Guid id) : base($"Plan with the Id: {id} cannot be found.")
        {
        }
    }
}
