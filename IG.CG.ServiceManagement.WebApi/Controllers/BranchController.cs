using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Authorize(Policy = "LoginRequired")]
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : Controller
    {

        private readonly ILogger<BranchController> _logger;
        private readonly IBranchService _branchService;
        public BranchController(IBranchService branchService, ILogger<BranchController> logger)
        {
            _branchService = branchService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all Branch Detail List.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all active Branch available in the database.
        /// </remarks>
        /// <returns>Returns a collection of order objects.</returns>
        [HttpGet("GetAllBranch")]

        public async Task<ActionResult<IEnumerable<BranchDisplayModel>>> GetBranch([FromQuery] BranchFilter branchFilter)
        {
            var Branch = await _branchService.GetAllBranchAsync(branchFilter);
            if (Branch is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Branch);
            }
        }

        /// <summary>
        /// Retrieve Branch Data by BranchId.
        /// </summary>
        /// <remarks>
        /// Based on Branch id,this endpoint returns a matching active Branch available in the database.
        /// </remarks>
        /// <returns>Returns a single Branch objects.</returns>
        [HttpGet("GetBranchById")]
        public async Task<ActionResult<BranchModel>> GetBranchById(int branchId)
        {
            var Branch = await _branchService.GetBranchByIdAsync(branchId);
            if (Branch is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(Branch);

            }

        }


        /// <summary>
        /// Insert & Update Branch Information.
        /// </summary>
        /// <remarks>
        /// Insert & Update Branch into the database.
        /// </remarks>
        /// <returns>Returns a last saved positive Branch id if insert or update successfully completed
        /// If it's 1000 then Branch name already exists 
        /// </returns>
        [HttpPost("UpsertBranch")]
        public async Task<ActionResult> InsertBranch(BranchModel branchModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var branch = await _branchService.UpsertBranchAsync(branchModel, User?.Identity?.Name);
                return Ok(branch);
            }

        }

        /// <summary>
        /// Remove Branch data.
        /// </summary>
        /// <remarks>
        /// Remove Branch from the database.
        /// </remarks>
        /// <returns>
        ///  Returns a removed Branch id.
        /// </returns>
        [HttpDelete("DeleteBranch")]
        public async Task<ActionResult> RemoveBranch(int branchId, int isActive)
        {
            var branch = await _branchService.DeleteBranchAsync(branchId, User?.Identity?.Name, isActive);
            return Ok(branch);
        }

        [HttpGet("GetAllUserWiseBranch")]
        public async Task<ActionResult<IEnumerable<BranchDisplayModel>>> GetUserWiseBranch([FromQuery] BaseUserWishFilter branchFilter)
        {
            var Branch = await _branchService.GetAllUserWiseBranchAsync(branchFilter, User?.Identity?.Name);


            if (Branch is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Branch);
            }
        }
    }
}
