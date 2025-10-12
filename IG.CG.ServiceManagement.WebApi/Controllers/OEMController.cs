using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Specification;
using IG.CG.ServiceManagement.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Authorize(Policy = "LoginRequired")]
    [Route("api/[controller]")]
    [ApiController]
    public class OEMController:Controller
    {
        private readonly ILogger<OEMController> _logger;
        private readonly IOEMService _oemService;

        public OEMController(IOEMService oemService, ILogger<OEMController> logger)
        {
            _oemService = oemService;
            _logger = logger;
        }
        [HttpGet("GetOEMData")]
        public async Task<ActionResult<IEnumerable<OEMModel>>> GetOEMDataAsync([FromQuery] OEMFilter oemFilter)
        {
            var lead = await _oemService.GetOEMDataAsync(oemFilter);
            if (lead is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(lead);
            }
        }
        [HttpPost("UpdateOEMData")]
        public async Task<IActionResult> UpsertOEMAsync(int ServiceTicketID, string? OEM)
        {
                var paraValResult = await _oemService.UpsertOEMAsync(ServiceTicketID, OEM);
                return Ok(paraValResult);   
            
        }

    }
}
