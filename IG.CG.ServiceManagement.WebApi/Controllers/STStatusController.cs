
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class STStatusController :  Controller
    {
        private readonly ILogger<STStatusController> _logger;
        private readonly ISTStatusService _stStatusService;
        public STStatusController(ISTStatusService stStatusService, ILogger<STStatusController> logger)
        {
            _stStatusService = stStatusService;
            _logger = logger;

        }

        [HttpPost("UpsertSTStatus")]
        public async Task<ActionResult> InsertSTStatus(STStatusModel stStatusModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var STStatus = await _stStatusService.UpsertSTStatusAsync(stStatusModel, User?.Identity?.Name);
                return Ok(STStatus);
            }

        }

        [HttpGet("GetAllSTStatus")]
        public async Task<ActionResult<IEnumerable<STStatusModel>>> GetSTStatus([FromQuery] STStatusFilter stStatusFilter)
        {
            var stStatus = await _stStatusService.GetAllSTStatusAsync(stStatusFilter);
            if (stStatus is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(stStatus);
            }

        }

        [HttpGet("GetSTStatusById")]
        public async Task<ActionResult<STStatusModel>> GetSTStatusById(int stStatusId)
        {
            var stStatus = await _stStatusService.GetSTStatusByIdAsync(stStatusId);
            if (stStatus is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(stStatus);

            }

        }

        [HttpDelete("DeleteSTStatus")]
        public async Task<ActionResult> RemoveSTStatus(int stStatusId,int isActive)
        {
            var stStatus = await _stStatusService.DeleteSTStatusAsync(stStatusId, User?.Identity?.Name, isActive);
            return Ok(stStatus);
        }

    }
}
