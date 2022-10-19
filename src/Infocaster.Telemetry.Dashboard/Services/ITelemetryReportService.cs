using Infocaster.Telemetry.Dashboard.Models;

namespace Infocaster.Telemetry.Dashboard.Services
{
    public interface ITelemetryReportService
    {
        int GetTelemetryReportCount();

        List<AppTelemetry> GetTelemetry(int telemetryReportid);

        List<AppTelemetryReport> GetTelemetryReports(int skip = 0, int take = 10);
    }
}