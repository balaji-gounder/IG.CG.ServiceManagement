using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class UAddRightsController : ControllerBase
    {
        private readonly ILogger<UAddRightsController> _logger;
        private readonly IAddRightsService _addRightsService;
        public UAddRightsController(IAddRightsService addRightsService, ILogger<UAddRightsController> logger)
        {
            _addRightsService = addRightsService;
            _logger = logger;
        }
        [HttpGet("GetAllUAddRights")]
        public async Task<ActionResult<IEnumerable<UserAdditionalRightsModel>>> GetUAddRights([FromQuery] UAddRightsFilter uAddRightsFilter)
        {
            var uAddRightsLst = await _addRightsService.GetAllUAddRightsAsync(uAddRightsFilter);
            if (uAddRightsLst is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(uAddRightsLst);
            }
        }
        [HttpPost("UpsertUAddRights")]
        public async Task<ActionResult> InsertUAddRights(UserAdditionalRightsModel uAddRightsModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var uAddRights = await _addRightsService.InsertUAddRightsAsync(uAddRightsModel, User?.Identity?.Name);
                return Ok(uAddRights);
            }
        }
        [HttpDelete("DeleteUAddRights")]
        public async Task<ActionResult> RemoveUAddRights(int UAddAutoId, int isActive)
        {
            var uAddRights = await _addRightsService.DeleteUAddRightsAsync(UAddAutoId, User?.Identity?.Name, isActive);
            return Ok(uAddRights);
        }
    }
}
