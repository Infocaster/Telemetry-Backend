using Infocaster.Telemetry.Api.Models;
using Infocaster.Telemetry.Database;
using Infocaster.Telemetry.Database.Entities;

namespace Infocaster.Telemetry.Api.Services
{
    public class TelemetryReportService : ITelemetryReportService
    {
        private readonly TelemetryContext _telemetryContext;

        public TelemetryReportService(TelemetryContext telemetryContext)
        {
            _telemetryContext = telemetryContext;
        }

        public async Task CreateTelemetryReport(AppTelemetryReportModel report)
        {
            var entity = new AppTelemetryReport
            {
                AppId = report.AppId,
                AppName = report.AppName,
                AppTelemetry = new List<AppTelemetry>(
                    report.Telemetry
                        .Where(x => x.Value is not null)
                        .Select(x =>
                        {
                            var entity = new AppTelemetry
                            {
                                Name = x.Name,
                                Type = x.Type
                            };

                            if (x.Value is not null)
                            {
                                // Not pretty but good enough hopefully.
                                switch (x.Type)
                                {
                                    case "System.Int32": entity.ValueInt = Convert.ToInt32(x.Value); break;
                                    case "System.Boolean": entity.ValueBool = (bool)x.Value; break;
                                    case "System.DateTime": entity.ValueDateTime = (DateTime)x.Value; break;
                                    default: entity.ValueString = x.Value.ToString(); break;
                                }
                            }

                            return entity;
                        }))
            };
            _telemetryContext.Add(entity);
            await _telemetryContext.SaveChangesAsync();
        }
    }
}