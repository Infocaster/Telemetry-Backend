using Infocaster.Telemetry.Dashboard.Models;
using Infocaster.Telemetry.Dashboard.Services;
using Microsoft.AspNetCore.Components;

namespace Infocaster.Telemetry.Dashboard.Pages
{
    public partial class Index
    {
        private int _totalReportCount;

        private List<AppTelemetryReport> _reports;

        [Inject]
        public ITelemetryReportService TelemetryReportService { get; set; }

        protected override void OnInitialized()
        {
            _totalReportCount = TelemetryReportService.GetTelemetryReportCount();
            _reports = TelemetryReportService.GetTelemetryReports();
        }

        private void ExpandTelemetryButtonClick(int id)
        {
            var report = _reports.First(x => x.Id == id);
            report.ShowExpanded = !report.ShowExpanded;
            report.Telemetry ??= TelemetryReportService.GetTelemetry(report.Id);
        }

        private bool HasMoreItems()
            => _reports.Count < _totalReportCount;

        private void LoadMoreItems()
        {
            var reports = TelemetryReportService.GetTelemetryReports(skip: _reports.Count);
            _reports.AddRange(reports);
        }
    }
}