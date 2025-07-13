using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Authorize(Policy = "LoginRequired")]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IDashboardService _dashboardservice;

        public DashboardController(IDashboardService dashboardservice, ILogger<DashboardController> logger)
        {
            _dashboardservice = dashboardservice;
            _logger = logger;
        }

        [HttpGet("GetDashBoardDetails")]
        public async Task<ActionResult<IEnumerable<DashboardModel>>> GetDashBoardDetailsAsync([FromQuery] DashboardFilter dashboardfilter)
        {

            string userID = User.Identity.Name;
            dashboardfilter.vUserID = userID;
            var details = await _dashboardservice.GetDashBoardDetailsAsync(dashboardfilter);
            if (details is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(details);
            }
        }



        [HttpGet("GetDashBoardClaimDetails")]
        public async Task<ActionResult<IEnumerable<DashboardClaimModel>>> GetDashBoardClaimDetailsAsync([FromQuery] DashboardFilter dashboardfilter)
        {

            string userID = User.Identity.Name;
            dashboardfilter.vUserID = userID;
            var details = await _dashboardservice.GetDashBoardClaimDetailsAsync(dashboardfilter);
            if (details is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(details);
            }
        }


    }
}
