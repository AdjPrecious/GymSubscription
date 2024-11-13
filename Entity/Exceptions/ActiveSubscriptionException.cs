using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public class ActiveSubscriptionException : AlrealdyExistException
    {
        public ActiveSubscriptionException() : base("You have and active subscription on this plan")
        {
        }
    }
}
