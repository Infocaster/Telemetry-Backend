using Infocaster.Telemetry.Api.Models;

namespace Infocaster.Telemetry.Api.Services
{
    public interface ITelemetryReportService
    {
        Task CreateTelemetryReport(AppTelemetryReportModel report);
    }
}