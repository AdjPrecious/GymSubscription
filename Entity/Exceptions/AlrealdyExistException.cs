using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public sealed class AlrealdyExistException : Exception
    {
        public AlrealdyExistException(string? message) : base($"Plan with name {message} already exist in the database")
        {
        }
    }
}
