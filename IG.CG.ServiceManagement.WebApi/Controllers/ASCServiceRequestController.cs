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
    public class ASCServiceRequestController : Controller
    {
        
        private readonly ILogger<ASCServiceRequestController> _logger;
        private readonly IASCServiceRequestService _ascServiceRequestService;
        public ASCServiceRequestController(IASCServiceRequestService ascServiceRequestService, ILogger<ASCServiceRequestController> logger)
        {
            _ascServiceRequestService = ascServiceRequestService;
            _logger = logger;

        }






        [HttpGet("GetAllASCServiceRequest")]
        public async Task<ActionResult<IEnumerable<ASCServiceRequestModel>>> GetASCServiceRequest([FromQuery] ASCServiceRequestFilter ascServiceRequestFilter)
        {
            var ASCServiceRequest = await _ascServiceRequestService.GetAllASCServiceRequestAsync(ascServiceRequestFilter, User?.Identity?.Name);
            if (ASCServiceRequest is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ASCServiceRequest);
            }
        }





        [HttpGet("GetAllSerialNoWiseTicket")]
        public async Task<ActionResult<IEnumerable<ASCServiceRequestModel>>> GetAlSerialNoWiseTicketAsync([FromQuery] string? SrNo)
        {
            var ASCServiceRequest = await _ascServiceRequestService.GetAlSerialNoWiseTicketAsync(SrNo);
            if (ASCServiceRequest is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ASCServiceRequest);
            }
        }



        [HttpGet("GetAllCallCenterRequestOpenTicket")]
        public async Task<ActionResult<IEnumerable<ASCServiceRequestModel>>> GetAllCallCenterRequestOpenTicketAsync([FromQuery] CallCenterRequestOpenTicketFilter ascServiceRequestFilter)
        {
            var ASCServiceRequest = await _ascServiceRequestService.GetAllCallCenterRequestOpenTicketAsync(ascServiceRequestFilter, User?.Identity?.Name);
            if (ASCServiceRequest is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ASCServiceRequest);
            }
        }




        [HttpGet("GetAllASCServiceRequestTotalCount")]
        public async Task<ActionResult<IEnumerable<ASCServiceRequestTotalCountModel>>> GetAllASCServiceRequestTotalCount([FromQuery] ASCServiceRequestFilter ascServiceRequestFilter)
        {
            var ASCServiceRequest = await _ascServiceRequestService.GetAllASCServiceRequestTotalCountAsync(ascServiceRequestFilter, User?.Identity?.Name);
            if (ASCServiceRequest is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ASCServiceRequest);
            }
        }



        [HttpGet("GetAllASMServiceRequest")]
        public async Task<ActionResult<IEnumerable<ASCServiceRequestModel>>> GetASMServiceRequest([FromQuery] ASCServiceRequestFilter ascServiceRequestFilter)
        {
            var ASMServiceRequest = await _ascServiceRequestService.GetAllASMServiceRequestAsync(ascServiceRequestFilter, User?.Identity?.Name);
            if (ASMServiceRequest is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ASMServiceRequest);
            }
        }

        [HttpGet("GetAllASCServiceRequestView")]
        public async Task<ActionResult<IEnumerable<ASCServiceRequestModel>>> GetAllASCServiceRequestView([FromQuery] ASCServiceRequestViewAllFilter ascServiceRequestFilter)
        {
            var ASCServiceRequestView = await _ascServiceRequestService.GetAllASCServiceRequestViewAsync(ascServiceRequestFilter);
            if (ASCServiceRequestView is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ASCServiceRequestView);
            }
        }

        [HttpGet("GetAllASCServiceRequestCancelled")]
        public async Task<ActionResult<IEnumerable<ASCServiceRequestModel>>> GetASCServiceRequestCancelled([FromQuery] ASCServiceRequestFilter ascServiceRequestFilter)
        {
            var ASCServiceRequestCancelled = await _ascServiceRequestService.GetAllASCServiceRequestCancelledAsync(ascServiceRequestFilter, User?.Identity?.Name);
            if (ASCServiceRequestCancelled is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ASCServiceRequestCancelled);
            }
        }

    }
}
