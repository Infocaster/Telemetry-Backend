using System.ComponentModel.DataAnnotations;

namespace Infocaster.Telemetry.Api.Models
{
    public class AppTelemetryReportModel
    {
        /// <summary>
        /// Guid that uniquely identifies the telemetry report source application.
        /// </summary>
        [Required]
        public Guid AppId { get; set; }

        /// <summary>
        /// Preferred display name of the telemetry report source application.
        /// </summary>
        public string? AppName { get; set; }

        /// <summary>
        /// Collection of telemetry to report.
        /// </summary>
        public List<AppTelemetryModel> Telemetry { get; set; }
    }
}