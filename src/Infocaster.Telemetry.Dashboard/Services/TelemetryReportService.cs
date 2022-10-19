using Infocaster.Telemetry.Dashboard.Models;
using Infocaster.Telemetry.Database;

namespace Infocaster.Telemetry.Dashboard.Services
{
    public class TelemetryReportService : ITelemetryReportService
    {
        private readonly TelemetryContext _telemetryContext;

        public TelemetryReportService(TelemetryContext telemetryContext)
        {
            _telemetryContext = telemetryContext;
        }

        public int GetTelemetryReportCount()
        {
            return _telemetryContext.AppTelemetryReports.Count();
        }

        public List<AppTelemetry> GetTelemetry(int telemetryReportid)
        {
            return _telemetryContext.AppTelemetry
                .Where(x => x.AppTelemetryReport.Id == telemetryReportid)
                .Select(x => new AppTelemetry
                {
                    Name = x.Name,
                    Type = x.Type,
                    ValueInt = x.ValueInt,
                    ValueBool = x.ValueBool,
                    ValueDateTime = x.ValueDateTime,
                    ValueString = x.ValueString
                }).ToList();
        }

        public List<AppTelemetryReport> GetTelemetryReports(int skip = 0, int take = 10)
        {
            return _telemetryContext.AppTelemetryReports
                .OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(take)
                .Select(x => new AppTelemetryReport
                {
                    Id = x.Id,
                    AppId = x.AppId,
                    AppName = x.AppName,
                    Timestamp = x.CreatedDate
                }).ToList();
        }
    }
}