using System.ComponentModel.DataAnnotations;

namespace Infocaster.Telemetry.Database.Entities
{
    public class AppTelemetryReport : BaseEntity
    {
        public Guid AppId { get; set; }

        [MaxLength(256)]
        public string? AppName { get; set; }

        public ICollection<AppTelemetry> AppTelemetry { get; set; }
    }
}