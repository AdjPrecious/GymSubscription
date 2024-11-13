using Entity.Interface;
using Entity.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new PlanConfiguration());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var softDeleteEntries = ChangeTracker.Entries<ISoftDeletable>().Where(e => e.State == EntityState.Deleted);

            foreach(var entryEntry in  softDeleteEntries)
            {
                entryEntry.State = EntityState.Modified;
                entryEntry.Property(nameof(ISoftDeletable.IsDeleted)).CurrentValue = true;
            }

            return await base.SaveChangesAsync(cancellationToken);

        }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Payment> Payment { get; set; }
    }
}
