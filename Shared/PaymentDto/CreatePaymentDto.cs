using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.PaymentDto
{
    public record CreatePaymentDto
    {
        public Guid PlanId { get; init; }
        public string? PaymentMethod { get; init; }

    }
}
