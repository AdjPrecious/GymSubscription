using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
