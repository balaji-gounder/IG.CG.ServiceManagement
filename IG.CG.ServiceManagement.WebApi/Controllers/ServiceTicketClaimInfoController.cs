using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class ServiceTicketClaimInfoController : Controller
    {

        private readonly ILogger<ServiceTicketClaimInfoController> _logger;
        private readonly IServiceTicketClaimInfoService _claimService;
        public ServiceTicketClaimInfoController(IServiceTicketClaimInfoService claimServiceService, ILogger<ServiceTicketClaimInfoController> logger)
        {
            _claimService = claimServiceService;
            _logger = logger;

        }


        [HttpPost("UpsertServiceTicketClaimInfo")]
        public async Task<IActionResult> InsertServiceTicketClaimInfo([FromBody] List<ServiceTicketClaimInfoModel> lstclaim, string? ServiceTicketId)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var activity = await _claimService.UpsertServiceTicketClaimInfoAsync(lstclaim, User?.Identity?.Name, ServiceTicketId);
                return Ok(activity);
            }

        }


        [HttpPost("UpsertServiceTicketDeviationClaimInfo")]
        public async Task<IActionResult> UpsertServiceTicketDeviationClaimInfoAsync([FromForm] ServiceTicketDeviationClaimInfoModel lstclaim)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var activity = await _claimService.UpsertServiceTicketDeviationClaimInfoAsync(lstclaim, User?.Identity?.Name);
                return Ok(activity);
            }

        }

    }
}
