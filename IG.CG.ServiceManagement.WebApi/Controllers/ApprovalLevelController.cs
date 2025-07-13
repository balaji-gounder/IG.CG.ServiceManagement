using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Application.Specification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Authorize(Policy = "LoginRequired")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalLevelController : Controller
    {
        private readonly ILogger<ApprovalLevelController> _logger;
        private readonly IApprovalLevelService _approvalLevelService;
        public ApprovalLevelController(IApprovalLevelService approvalLevelService, ILogger<ApprovalLevelController> logger)
        {
            _approvalLevelService = approvalLevelService;
            _logger = logger;

        }

        [HttpPost("UpsertApprovalLevel")]
        public async Task<ActionResult> InsertApprovalLevel(ApprovalLevelModel approvalLevelModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var InsertApprovalLevel = await _approvalLevelService.UpsertApprovalLevelAsync(approvalLevelModel, User?.Identity?.Name);
                return Ok(InsertApprovalLevel);
            }
        }

        [HttpGet("GetAllApprovalLevel")]
        public async Task<ActionResult<IEnumerable<ApprovalLevelDisplayModel>>> GetAllApprovalLevel([FromQuery] ApprovalLevelFilter approvalLevelFilter)
        {
            var ApprovalLevel = await _approvalLevelService.GetAllApprovalLevelAsync(approvalLevelFilter);
            if (ApprovalLevel is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ApprovalLevel);
            }
        }

        [HttpGet("GetAllApprovalLevelUsers")]
        public async Task<ActionResult<IEnumerable<ApprovalLevelUsersModel>>> GetAllApprovalLevelUsers([FromQuery] ApprovalLevelFilter approvalLevelFilter)
        {
            var ApprovalLevelUsers = await _approvalLevelService.GetAllApprovalLevelUsersAsync(approvalLevelFilter);
            if (ApprovalLevelUsers is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ApprovalLevelUsers);
            }
        }

    }
}
