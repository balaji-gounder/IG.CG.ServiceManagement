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
    public class ClosureTATBranchWiseController:Controller
    {
        private readonly ILogger<ClosureTATBranchWiseController> _logger;
        private readonly IClosureTATBranchWiseService _ClosureService;
        public ClosureTATBranchWiseController(IClosureTATBranchWiseService ClosureService, ILogger<ClosureTATBranchWiseController> logger)
        {
            _ClosureService = ClosureService;
            _logger = logger;
        }

        [HttpGet("GetClosingTATBranchWiseReport")]
        public async Task<ActionResult<IEnumerable<ClosureTATBranchWiseModel>>> GetClosureTATBranchWiseReportAsync([FromQuery] ClosureTATBranchWiseFilter closureTATBranchWiseFilter)
        {
            string userID = User.Identity.Name;
            closureTATBranchWiseFilter.UserID = userID;
            var closureTATBranch = await _ClosureService.GetClosureTATBranchWiseReportAsync(closureTATBranchWiseFilter);
            if (closureTATBranch is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(closureTATBranch);
            }
        }


        [HttpGet("GetFIRClosingTATBranchWiseReport")]
        public async Task<ActionResult<IEnumerable<ClosureTATBranchWiseModel>>> GetFIRClosureTATBranchWiseReportAsync([FromQuery] ClosureTATBranchWiseFilter closureTATBranchWiseFilter)
        {
            string userID = User.Identity.Name;
            closureTATBranchWiseFilter.UserID = userID;
            var closureTATBranch = await _ClosureService.GetFIRClosureTATBranchWiseReportAsync(closureTATBranchWiseFilter);
            if (closureTATBranch is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(closureTATBranch);
            }
        }


    }
}
