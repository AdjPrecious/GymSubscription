using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.SubscriptionDto
{
    public record CreateSubscriptionDto
    {
        [Required]
        public Guid PlanId { get; set; }
        

      
    }
}
