namespace Infocaster.Telemetry.Api.Models
{
    public class AppTelemetryModel
    {
        /// <summary>
        /// Name of the telemetry.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of the telemetry.
        /// </summary>
        public object? Value { get; set; }

        /// <summary>
        /// Name of the telemetry value's original clr type.
        /// </summary>
        public string Type { get; set; }
    }
}