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
        public string? PlanName { get; set; }
        public float Price { get; set; }
        public int DurationInDays { get; set; }
        public string? Description { get; set; }

        

       
        

       
    }
}
