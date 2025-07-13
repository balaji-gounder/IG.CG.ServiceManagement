using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class ServiceTicketCommenInfoController : Controller
    {
        private readonly ILogger<ServiceTicketCommenInfoController> _logger;
        private readonly IServiceTicketCommenInfoService _serviceCommentService;
        public ServiceTicketCommenInfoController(IServiceTicketCommenInfoService CommentService, ILogger<ServiceTicketCommenInfoController> logger)
        {
            _serviceCommentService = CommentService;
            _logger = logger;
        }

        [HttpGet("GetAllServiceTicketCommentInfo")]
        public async Task<ActionResult<IEnumerable<ServiceTicketCommenInfoListModel>>> GetAllServiceTicketCommenInfoAsync(string? ServiceTicketId)
        {
            var Region = await _serviceCommentService.GetAllServiceTicketCommenInfoAsync(ServiceTicketId);
            if (Region is null)
            {

                return NotFound();

            }
            else
            {

                return Ok(Region);

            }
        }




        [HttpGet("GetAllServiceTicketEscalationInfo")]
        public async Task<ActionResult<IEnumerable<ServiceTicketCommenInfoListModel>>> GetAllServiceTicketEscalationInfoAsync(string? ServiceTicketId)
        {
            var Region = await _serviceCommentService.GetAllServiceTicketEscalationInfoAsync(ServiceTicketId);
            if (Region is null)
            {

                return NotFound();

            }
            else
            {

                return Ok(Region);

            }
        }



        [HttpPost("UpsertServiceTicketComment")]
        public async Task<ActionResult> UpsertServiceTicketCommenInfoAsync(ServiceTicketCommenInfoModel CommentModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var region = await _serviceCommentService.UpsertServiceTicketCommenInfoAsync(CommentModel, User?.Identity?.Name);
                return Ok(region);
            }
        }



        [HttpPost("UpsertServiceTicketEscalation")]
        public async Task<ActionResult> UpsertServiceTicketEscalationInfoAsync(ServiceTicketCommenInfoModel CommentModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var region = await _serviceCommentService.UpsertServiceTicketEscalationInfoAsync(CommentModel, User?.Identity?.Name);
                return Ok(region);
            }
        }

    }
}
