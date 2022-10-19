using Infocaster.Telemetry.Api.Models;
using Infocaster.Telemetry.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Infocaster.Telemetry.Api.Controllers
{
    [ApiController]
    [Route("telemetryreport")]
    public class TelemetryReportController : ControllerBase
    {
        private readonly ITelemetryReportService _telemetryReportService;

        public TelemetryReportController(ITelemetryReportService telemetryReportService)
        {
            _telemetryReportService = telemetryReportService;
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateTelemetryReport(AppTelemetryReportModel report)
        {
            await _telemetryReportService.CreateTelemetryReport(report);
            // There's no human interaction with this endpoint so just return 200 OK. 
            return Ok();
        }
    }
}