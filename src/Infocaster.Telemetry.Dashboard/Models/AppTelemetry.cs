namespace Infocaster.Telemetry.Dashboard.Models
{
    public class AppTelemetry
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int? ValueInt { get; set; }

        public bool? ValueBool { get; set; }

        public DateTime? ValueDateTime { get; set; }

        public string? ValueString { get; set; }
    }
}