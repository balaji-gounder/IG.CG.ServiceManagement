using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Specification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class ClaimApprovalHistoryController : Controller
    {
        private readonly ILogger<ClaimApprovalHistoryController> _logger;
        private readonly IClaimApprovalHistoryService _claimApprovalHistoryService;
        public ClaimApprovalHistoryController(IClaimApprovalHistoryService claimApprovalHistoryService, ILogger<ClaimApprovalHistoryController> logger)
        {
            _claimApprovalHistoryService = claimApprovalHistoryService;
            _logger = logger;

        }

        [HttpPost("UpsertClaimApprovalHistory")]
        public async Task<IActionResult> InsertClaimApprovalHistory(List<ClaimApprovalHistoryModel> lstClaimApprovalHistory)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var claimApprovalHistory = await _claimApprovalHistoryService.UpsertClaimApprovalHistoryAsync(lstClaimApprovalHistory, User?.Identity?.Name);
                return Ok(claimApprovalHistory);
            }

        }

        [HttpGet("GetAllClaimApprovalHistory")]
        public async Task<ActionResult<IEnumerable<ClaimApprovalHistoryDisplayModel>>> GetAllClaimApprovalHistory(int serviceTicketClaimId)
        {
            var ClaimApprovalHistory = await _claimApprovalHistoryService.GetAllClaimApprovalHistoryAsync(serviceTicketClaimId);
            if (ClaimApprovalHistory is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ClaimApprovalHistory);
            }
        }

        [HttpPost("UpsertSpecialApprovalHistory")]
        public async Task<IActionResult> InsertSpecialApprovalHistory(List<SpecialApprovalHistoryModel> lstClaimApprovalHistory)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var claimApprovalHistory = await _claimApprovalHistoryService.UpsertSpecialApprovalHistoryAsync(lstClaimApprovalHistory, User?.Identity?.Name);
                return Ok(claimApprovalHistory);
            }

        }


        [HttpGet("GetAllSpecialApprovalHistory")]
        public async Task<ActionResult<IEnumerable<SpecialApprovalHistoryDisplayModel>>> GetAllSpecialApprovalHistory(int specialApprovalId)
        {
            var SpecialApprovalHistory = await _claimApprovalHistoryService.GetAllSpecialApprovalHistoryAsync(specialApprovalId);
            if (SpecialApprovalHistory is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(SpecialApprovalHistory);
            }
        }

    }
}
