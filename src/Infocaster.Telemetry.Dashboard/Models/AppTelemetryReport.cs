namespace Infocaster.Telemetry.Dashboard.Models
{
    public class AppTelemetryReport
    {
        public int Id { get; set; }

        public Guid AppId { get; set; }

        public string? AppName { get; set; }

        public DateTime Timestamp { get; set; }

        public bool ShowExpanded { get; set; }

        public List<AppTelemetry> Telemetry { get; set; }
    }
}