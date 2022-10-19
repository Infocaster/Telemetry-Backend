using System.Diagnostics;
using Infocaster.Telemetry.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infocaster.Telemetry.Database
{
    public class TelemetryContext : DbContext
    {
        public DbSet<AppTelemetryReport> AppTelemetryReports { get; set; }

        public DbSet<AppTelemetry> AppTelemetry { get; set; }

        public TelemetryContext(DbContextOptions<TelemetryContext> options)
            : base(options) { }

        // Source: https://docs.microsoft.com/en-us/ef/core/logging-events-diagnostics/simple-logging
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(message => Debug.WriteLine(message));

        // Source: https://www.entityframeworktutorial.net/faq/set-created-and-modified-date-in-efcore.aspx
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}