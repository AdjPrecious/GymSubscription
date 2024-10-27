using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public sealed class IdParameterBadRequest : BadRequestException
    {
        public IdParameterBadRequest() : base("Parameter id is null")
        {
        }
    }
}
