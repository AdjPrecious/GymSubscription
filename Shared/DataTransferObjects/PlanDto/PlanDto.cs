using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.PlanDto
{
    public record PlanDto
    {
       public Guid PlanId { get; set; }
        public string? PlanName { get; init; }
        
        public float Price { get; init; }
        
        public int DurationInDays { get; init; }
       
        public string? Description { get; init; }

        public DateTime CreatedAt { get; init; }
    }
}
