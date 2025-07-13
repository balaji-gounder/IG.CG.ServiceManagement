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
    public class ActivityController : Controller
    {
        private readonly ILogger<ActivityController> _logger;
        private readonly IActivityService _activityService;
        public ActivityController(IActivityService activityService, ILogger<ActivityController> logger)
        {
            _activityService = activityService;
            _logger = logger;

        }

        [HttpPost("UpsertActivity")]
        public async Task<IActionResult> InsertActivity(List<ActivityModel> lstActivity)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var activity = await _activityService.UpsertActivityAsync(lstActivity, User?.Identity?.Name);
                return Ok(activity);
            }

        }

        [HttpGet("GetAllActivity")]
        public async Task<ActionResult<IEnumerable<ActivityDisplayModel>>> GetActivity([FromQuery] ActivityFilter activityFilter)
        {
            var Activity = await _activityService.GetAllActivityAsync(activityFilter);
            if (Activity is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Activity);
            }
        }

        [HttpGet("GetActivityById")]
        public async Task<ActionResult<ActivityModel>> GetActivityById(int activityId)
        {
            var activity = await _activityService.GetActivityByIdAsync(activityId);
            if (activity is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(activity);

            }

        }

        [HttpDelete("DeleteActivity")]
        public async Task<ActionResult> RemoveActivity(int activityId, int isActive)
        {
            var activity = await _activityService.DeleteActivityAsync(activityId, User?.Identity?.Name, isActive);
            return Ok(activity);
        }

        [HttpGet("GetActivityByType")]
        public async Task<ActionResult<ActivityDisplayModel>> GetActivityByType(string? ProductLineCode, string? DivisionCode, string? SubStatusid, string? StatusId, string? ActivityTypeId,string? ServiceTicketId)
        {

            var activity = await _activityService.GetActivityByTypeAsync(ProductLineCode, DivisionCode, SubStatusid, StatusId, ActivityTypeId, ServiceTicketId);
            if (activity is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(activity);
            }
        }



        [HttpGet("GetActivitymstAsync")]
        public async Task<ActionResult<ActivityDisplayModel>> GetActivitymstAsync(string? DivisionCode, string? ActivityTypeId)
        {

            var activity = await _activityService.GetActivitymstAsync(DivisionCode, ActivityTypeId);
            if (activity is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(activity);
            }
        }




        [HttpGet("GetAllTypeOfWorkDone")]
        public async Task<ActionResult<IEnumerable<ActivityDisplayModel>>> GetAllTypeOfWorkDone(int serviceTicketId, string FrameSizeType, string KVAType)
        {
            var TypeOfWorkDone = await _activityService.GetAllTypeOfWorkDoneAsync(serviceTicketId, FrameSizeType, KVAType);
            if (TypeOfWorkDone is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(TypeOfWorkDone);
            }
        }

    }
}
