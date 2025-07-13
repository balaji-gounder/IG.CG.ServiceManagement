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
    public class STSubStatusController : Controller
    {
        private readonly ILogger<STSubStatusController> _logger;
        private readonly ISTSubStatusService _stSubStatusService;
        public STSubStatusController(ISTSubStatusService stSubStatusService, ILogger<STSubStatusController> logger)
        {
            _stSubStatusService = stSubStatusService;
            _logger = logger;

        }

        [HttpPost("UpsertSTSubStatus")]
        public async Task<ActionResult> InsertSTSubStatus(STSubStatusModel stSubStatusModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var STSubStatus = await _stSubStatusService.UpsertSTSubStatusAsync(stSubStatusModel, User?.Identity?.Name);
                return Ok(STSubStatus);
            }

        }

        [HttpGet("GetAllSTSubStatus")]
        public async Task<ActionResult<IEnumerable<STSubStatusModel>>> GetSTSubStatus([FromQuery] STSubStatusFilter stSubStatusFilter)
        {
            var stSubStatus = await _stSubStatusService.GetAllSTSubStatusAsync(stSubStatusFilter);
            if (stSubStatus is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(stSubStatus);
            }

        }

        [HttpGet("GetSTSubStatusById")]
        public async Task<ActionResult<STSubStatusModel>> GetSTSubStatusById(int stSubStatusId)
        {
            var stSubStatus = await _stSubStatusService.GetSTSubStatusByIdAsync(stSubStatusId);
            if (stSubStatus is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(stSubStatus);

            }

        }

        [HttpDelete("DeleteSTSubStatus")]
        public async Task<ActionResult> RemoveSTSubStatus(int stSubStatusId, int isActive)
        {
            var stSubStatus = await _stSubStatusService.DeleteSTSubStatusAsync(stSubStatusId, User?.Identity?.Name, isActive);
            return Ok(stSubStatus);
        }


        [HttpGet("GetSTSubStatusByStatus")]
        public async Task<ActionResult<IEnumerable<STSubStatusModel>>> GetSTStatusBySubStatus(int stStatusId)
        {
            var stSubStatus = await _stSubStatusService.GetSTSubStatusByStatusAsync(stStatusId);
            if (stSubStatus is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(stSubStatus);
            }

        }

        [HttpGet("GetAllSTSubStatusByType")]
        public async Task<ActionResult<IEnumerable<STSubStatusByTypeModel>>> GetSTSubStatusByType(string? StatusType, int? ActiveId)
        {
            var stSubStatusByType = await _stSubStatusService.GetAllSTSubStatusByTypeAsync(StatusType, ActiveId);
            if (stSubStatusByType is null)
            {
                return NotFound();


            }
            else
            {
                return Ok(stSubStatusByType);
            }

        }


        [HttpGet("ServiceTicketStatus")]
        public async Task<ActionResult<IEnumerable<ServiceTicketStatusModel>>> GetServiceTicketStatus(int? SubStatusid)
        {
            var stStatus = await _stSubStatusService.GetServiceTicketStatusAsync(SubStatusid);
            if (stStatus is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(stStatus);
            }

        }

    }
}
