using System.ComponentModel.DataAnnotations;

namespace Infocaster.Telemetry.Database.Entities
{
    public class AppTelemetry : BaseEntity
    {
        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Type { get; set; }

        public int? ValueInt { get; set; }

        public bool? ValueBool { get; set; }

        public DateTime? ValueDateTime { get; set; }

        [MaxLength(1024)]
        public string? ValueString { get; set; }

        public AppTelemetryReport AppTelemetryReport { get; set; }
    }
}