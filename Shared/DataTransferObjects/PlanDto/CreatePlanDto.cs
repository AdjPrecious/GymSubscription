using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.PlanDto
{
    public record CreatePlanDto
    {
        
        [MaxLength(100)]
        [Required]
        public string? PlanName { get; init; }
        [Required]
        public float Price { get; init; }
        [Required]
        public int DurationInDays { get; init; }
        [MaxLength(225)]
        [Required]
        public string? Description { get; init; }


    }
}
