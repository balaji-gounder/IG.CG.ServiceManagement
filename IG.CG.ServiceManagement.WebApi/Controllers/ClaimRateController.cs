using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class ClaimRateController : Controller
    {
        private readonly ILogger<ClaimRateController> _logger;
        private readonly IClaimRateService _claimRateService;
        public ClaimRateController(IClaimRateService claimRateService, ILogger<ClaimRateController> logger)
        {
            _claimRateService = claimRateService;
            _logger = logger;
        }

        [HttpPost("UpsertClaimRate")]
        public async Task<IActionResult> InsertClaimRate(ClaimRateModel claimRateModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var paraValResult = await _claimRateService.UpsertclaimRateAsync(claimRateModel, User?.Identity?.Name);
                return Ok(paraValResult);
            }
        }


        [HttpGet("GetAllClaimRate")]
        public async Task<ActionResult<IEnumerable<ClaimRateDisplayModel>>> GetAllclaimRate([FromQuery] ClaimRateFilter leadFilter)
        {
            var lead = await _claimRateService.GetAllclaimRateAsync(leadFilter);
            if (lead is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(lead);
            }
        }



        [HttpGet("GetclaimRateById")]
        public async Task<ActionResult<ClaimRateDisplayModel>> GetclaimRateById(int ClaimRateId)
        {
            var Branch = await _claimRateService.GetclaimRateByIdAsync(ClaimRateId);
            if (Branch is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(Branch);

            }

        }


        [HttpDelete("DeleteClaimRate")]
        public async Task<ActionResult> RemoveClaimRate(int ClaimRateId, int isActive)
        {
            var branch = await _claimRateService.DeleteclaimRateinfoAsync(ClaimRateId, User?.Identity?.Name, isActive);
            return Ok(branch);
        }


        [HttpDelete("DeleteclaimRateDetails")]
        public async Task<ActionResult> DeleteclaimRateDetails(int ClaimRateDetailId)
        {
            var branch = await _claimRateService.DeleteclaimRateDetails(ClaimRateDetailId);
            return Ok(branch);
        }

    }
}
