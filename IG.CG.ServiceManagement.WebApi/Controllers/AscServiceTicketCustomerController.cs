using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class AscServiceTicketCustomerController : Controller
    {

        private readonly ILogger<AscServiceTicketCustomerController> _logger;
        private readonly IAscServiceTicketCustomerService _ascServiceTicketCustomerService;
        public AscServiceTicketCustomerController(IAscServiceTicketCustomerService ascServiceTicketCustomerService, ILogger<AscServiceTicketCustomerController> logger)
        {
            _ascServiceTicketCustomerService = ascServiceTicketCustomerService;
            _logger = logger;

        }



        [HttpPost("UpsertAscServiceTicketCustomer")]
        public async Task<ActionResult> InsertAscServiceTicketCustomer(AscServiceTicketCustomerModel lstAscServiceTicketCustomer)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var ascServiceTicketCustomer = await _ascServiceTicketCustomerService.UpsertAscServiceTicketCustomerAsync(lstAscServiceTicketCustomer, User?.Identity?.Name);
                return Ok(ascServiceTicketCustomer);
            }

        }


        [HttpPost("UpsertASCSiteVisitAndProductReceived")]
        public async Task<ActionResult> InsertASCSiteVisitAndProductReceived([FromBody] ASCSiteVisitAndProductReceivedModel lstAscServiceTicketCustomer)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var ascServiceTicketCustomer = await _ascServiceTicketCustomerService.UpsertASCSiteVisitAndProductReceivedAsync(lstAscServiceTicketCustomer, User?.Identity?.Name);
                return Ok(ascServiceTicketCustomer);
            }

        }


        [HttpGet("GetServiceTicketTaskDetailsByIdAsync")]
        public async Task<ActionResult<ServiceTicketTaskDetailsModel>> GetServiceTicketTaskDetailsByIdAsync(int ServiceTicketId)
        {
            var asc = await _ascServiceTicketCustomerService.GetServiceTicketTaskDetailsByIdAsync(ServiceTicketId);
            if (asc is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(asc);

            }
        }



        [HttpGet("GetServiceTicketTaskDetailsTicketHistoryByIdAsync")]
        public async Task<ActionResult<ServiceTicketTaskDetailsReportModel>> GetServiceTicketTaskDetailsTicketHistoryByIdAsync(int ServiceTicketId)
        {
            var asc = await _ascServiceTicketCustomerService.GetServiceTicketTaskDetailsTicketHistoryByIdAsync(ServiceTicketId);
            if (asc is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(asc);
            }
        }


        [HttpPost("UpdateReassignedTechniciane")]
        public async Task<IActionResult> UpdateReassignedTechnicianerviceTicketAsync(int serviceTicketId, int? TechnicianId, string? Remark, string? AssignDate, string? AppointmentTime)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var updateAcknowledgmentServiceTicket = await _ascServiceTicketCustomerService.UpdateReassignedTechnicianerviceTicketAsync(serviceTicketId, TechnicianId, Remark, AssignDate, User?.Identity?.Name, AppointmentTime);
                return Ok(updateAcknowledgmentServiceTicket);
            }

        }


        [HttpPost("UpdateAssignedASCService")]
        public async Task<IActionResult> UpdateAssignedASCServiceAsync(ServiceTicketASCCodeModel objAsc)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var updateAcknowledgmentServiceTicket = await _ascServiceTicketCustomerService.UpdateAssignedASCServiceAsync(objAsc, User?.Identity?.Name);
                return Ok(updateAcknowledgmentServiceTicket);
            }

        }

        [HttpPost("UpsertAscServiceTicketActivity")]
        public async Task<IActionResult> UpsertAscServiceTicketActivity(List<AscServiceTicketActivityModel> lstAscActivity)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var roleWiseMenu = await _ascServiceTicketCustomerService.UpsertAscServiceTicketActivity(User?.Identity?.Name, lstAscActivity);
                return Ok(roleWiseMenu);
            }

        }

        [HttpPost("InsertServiceTicketPendencyReason")]
        public async Task<IActionResult> InsertServiceTicketPendencyReason(ServiceTicketPendencyReasonModel serviceTicketPendencyReasonModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var serviceTicketPendencyReason = await _ascServiceTicketCustomerService.InsertServiceTicketPendencyReasonAsync(serviceTicketPendencyReasonModel, User?.Identity?.Name);
                return Ok(serviceTicketPendencyReason);
            }

        }

        [HttpGet("GetAllServiceTicketPendencyReason")]
        public async Task<ActionResult<IEnumerable<ServiceTicketPendencyReasonDisplayModel>>> GetAllServiceTicketPendencyReason(int serviceTicketId)
        {
            var PendencyReason = await _ascServiceTicketCustomerService.GetAllServiceTicketPendencyReasonAsync(serviceTicketId);
            if (PendencyReason is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(PendencyReason);
            }
        }

        [HttpGet("GetAllSTPendingWithWhomList")]
        public async Task<ActionResult<IEnumerable<PendingWithWhomModel>>> GetAllSTPendingWithWhomList(int actualStatusOfComplaintId)
        {
            var PendingWithWhomList = await _ascServiceTicketCustomerService.GetAllSTPendingWithWhomListAsync(actualStatusOfComplaintId);
            if (PendingWithWhomList is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(PendingWithWhomList);
            }
        }



        [HttpGet("GetAllPendencyActionRequiredList")]
        public async Task<ActionResult<IEnumerable<PendencyActionRequiredModel>>> GetAllPendencyActionRequired(int pendingWithWhomId)
        {
            var PendencyActionRequired = await _ascServiceTicketCustomerService.GetAllPendencyActionRequiredAsync(pendingWithWhomId);
            if (PendencyActionRequired is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(PendencyActionRequired);
            }
        }



        [HttpPost("UpdateAssignedASMService")]
        public async Task<IActionResult> UpdateAssignedASMServiceAsync(ServiceTicketASMCodeModel objAsc)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var updateServiceTicketAssignedASM = await _ascServiceTicketCustomerService.UpdateAssignedASMServiceAsync(objAsc, User?.Identity?.Name);
                return Ok(updateServiceTicketAssignedASM);
            }

        }



        [HttpPost("UpdateCancelServiceTicketAsync")]
        public async Task<IActionResult> UpdateCancelServiceAsync(ServiceTicketCancelModel objAsc)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var updateServiceTicketAssignedASM = await _ascServiceTicketCustomerService.UpdateCancelServiceAsync(objAsc, User?.Identity?.Name);
                return Ok(updateServiceTicketAssignedASM);
            }

        }




        [HttpDelete("DeleteAscServiceTicketActivityAsync")]
        public async Task<ActionResult> DeleteAscServiceTicketActivityAsync(int AscActivitiesId)
        {
            var FIRDocument = await _ascServiceTicketCustomerService.DeleteAscServiceTicketActivityAsync(AscActivitiesId);
            return Ok(FIRDocument);
        }




    }
}
