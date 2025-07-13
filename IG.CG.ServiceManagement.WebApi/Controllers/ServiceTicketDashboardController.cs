using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class ServiceTicketDashboardController : Controller
    {

        private readonly ILogger<ServiceTicketDashboardController> _logger;
        private readonly IServiceTicketDashboardService _serviceTicketDashboardService;
        public ServiceTicketDashboardController(IServiceTicketDashboardService serviceTicketDashboardService, ILogger<ServiceTicketDashboardController> logger)
        {
            _serviceTicketDashboardService = serviceTicketDashboardService;
            _logger = logger;

        }

        [HttpGet("GetAllRolesServiceTicketDashboard")]
        public async Task<ActionResult<ServiceTicketDashboardModel>> GetAllRolesServiceTicketDashboard([FromQuery] ServiceTicketDashboardFilter serviceTicketDashboardFilter)
        {
            var Dashboard = await _serviceTicketDashboardService.GetAllRolesServiceTicketDashboardAsync(serviceTicketDashboardFilter, User?.Identity?.Name);
            if (Dashboard is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(Dashboard);

            }

        }

        [HttpGet("GetAscTatPerformance")]
        public async Task<ActionResult<AscTatPerformanceModel>> GetAscTatPerformance([FromQuery] AscTatPerformanceFilter ascTatPerformanceFilter)
        {
            var AscTatPerformance = await _serviceTicketDashboardService.GetAscTatPerformanceAsync(ascTatPerformanceFilter, User?.Identity?.Name);
            if (AscTatPerformance is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(AscTatPerformance);

            }

        }

    }
}
