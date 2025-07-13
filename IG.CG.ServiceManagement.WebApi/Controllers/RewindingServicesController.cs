using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class RewindingServicesController : Controller
    {

        private readonly ILogger<RewindingServicesController> _logger;
        private readonly IRewindingServicesService _rewindingServicesService;
        public RewindingServicesController(IRewindingServicesService rewindingServicesService, ILogger<RewindingServicesController> logger)
        {
            _rewindingServicesService = rewindingServicesService;
            _logger = logger;

        }

        
        [HttpGet("GetAllRewindingServices")]
        public async Task<ActionResult<IEnumerable<RewindingServicesDisplayModel>>> GetActivity([FromQuery] RewindingServicesFilter rewindingServicesFilter)
        {
            var RewindingServices = await _rewindingServicesService.GetAllRewindingServicesAsync(rewindingServicesFilter);
            if (RewindingServices is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(RewindingServices);
            }
        }

    }
}
