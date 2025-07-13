using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.ServiceManagement.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Authorize(Policy = "LoginRequired")]
    [Route("api/[controller]")]
    [ApiController]
    public class CostingReportController : Controller
    {
        private readonly ILogger<CostingReportController> _logger;
        private readonly ICostingReportService _costReportService;

        public CostingReportController(ICostingReportService costreportService, ILogger<CostingReportController> logger)
        {
            _costReportService = costreportService;
            _logger = logger;
        }

        [HttpGet("GetCostingReport")]
        public async Task<IActionResult> GetCostingReportAsync([FromQuery] CostingReportFilter costingReportFilter)
        {
            var userId = User?.Identity?.Name;
            costingReportFilter.UserID = userId;

            var costing = await _costReportService.GetCostingReportAsync(costingReportFilter);

            if (costing == null)
                return NotFound();

            if (costingReportFilter.PageSize == 0)
            {
                var csvZipStream = CostingReportCsvExportHelper.GenerateZippedCsvStream(
                    costing.ToList(),
                    CostingReportCsvExportHelper.CostingHeaderMap(),
                    $"CostingReport_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                );

                return File(csvZipStream, "application/zip", $"CostingReport_{DateTime.Now:yyyyMMdd_HHmmss}.zip");
            }

            return Ok(costing);
        }
    }
}
