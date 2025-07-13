using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Specification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Authorize(Policy = "LoginRequired")]
    [Route("api/[controller]")]
    [ApiController]
    public class PartConsumptionReportController:Controller
    {
        private readonly ILogger<PartConsumptionReportController> _logger;
        private readonly IPartCosnumptionReportService _partCosnumptionReportServiceService;
        public PartConsumptionReportController(IPartCosnumptionReportService reportsService, ILogger<PartConsumptionReportController> logger)
        {
            _partCosnumptionReportServiceService = reportsService;
            _logger = logger;
        }

        [HttpGet("GetPartConsumptionReport")]
        public async Task<ActionResult<IEnumerable<PartConsumptionReportModel>>> GetPartConsumptionReportAsync([FromQuery] PartConsumptionReportFilter partConsumptionReportFilter)
        {
            string userID = User.Identity.Name;
            partConsumptionReportFilter.UserID = userID;
            var partconsumption = await _partCosnumptionReportServiceService.GetPartConsumptionReportAsync(partConsumptionReportFilter);
            if (partconsumption is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(partconsumption);
            }
        }
    }
}
