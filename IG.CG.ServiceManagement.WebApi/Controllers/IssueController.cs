using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class IssueController : Controller
    {
        private readonly ILogger<IssueController> _logger;
        private readonly IIssueService _issueService;
        public IssueController(IIssueService issueService, ILogger<IssueController> logger)
        {
            _issueService = issueService;
            _logger = logger;

        }

        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetAllIssue")]
        public async Task<ActionResult<IEnumerable<IssueDisplayModel>>> GetAllIssue([FromQuery] IssueFilter issueFilter)
        {
            var Issue = await _issueService.GetAllIssueAsync(issueFilter);
            if (Issue is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Issue);
            }
        }

        [Authorize(Policy = "LoginRequired")]
        [HttpPost("UpsertIssue")]
        public async Task<ActionResult> InsertIssue(IssueModel issueModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var Issue = await _issueService.UpsertIssueAsync(issueModel, User?.Identity?.Name);
                return Ok(Issue);
            }
        }


        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetIssueById")]
        public async Task<ActionResult<IssueModel>> GetIssueById(int issueTypeId)
        {
            var Issue = await _issueService.GetIssueByIdAsync(issueTypeId);
            if (Issue is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(Issue);

            }

        }


        [Authorize(Policy = "LoginRequired")]
        [HttpDelete("DeleteIssue")]
        public async Task<ActionResult> RemoveIssue(int issueTypeId, int isActive)
        {
            var Issue = await _issueService.DeleteIssueAsync(issueTypeId, User?.Identity?.Name, isActive);
            return Ok(Issue);
        }


        [HttpGet("GetAllIssueUnauthorize")]
        public async Task<ActionResult<IEnumerable<IssueDisplayModel>>> GetAllIssueUnauthorize([FromQuery] IssueFilter issueFilter)
        {
            var Issue = await _issueService.GetAllIssueAsync(issueFilter);
            if (Issue is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Issue);
            }
        }

    }
}
