using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTicketController : Controller
    {
        private readonly ILogger<ServiceTicketController> _logger;
        private readonly IServiceTicketService _ServiceTicketService;
        public ServiceTicketController(IServiceTicketService ServiceTicketService, ILogger<ServiceTicketController> logger)
        {
            _ServiceTicketService = ServiceTicketService;
            _logger = logger;
        }



        //[HttpGet("GetServiceTicketByIdUnauthorize")]GetAllSerialWiseServiceTicketInfoFIR
        //public async Task<ActionResult<ServiceTicketDetailsModel>> GetServiceTicketByIdUnauthorize(int ServiceTickeId)
        //{
        //    var ServiceTicket = await _ServiceTicketService.GetServiceTicketDetailsByIdAsync(ServiceTickeId);
        //    if (ServiceTicket is null)
        //    {
        //        return NotFound();

        //    }
        //    else
        //    {
        //        return Ok(ServiceTicket);

        //    }
        //}



        [HttpGet("GetServiceTicketByIdUnauthorize")]
        public async Task<ActionResult<IEnumerable<ServiceTicketDetailsModel>>> GetServiceTicketByIdUnauthorize(string? ServiceTickeId)
        {
            var ServiceTicket = await _ServiceTicketService.GetServiceTicketDetailsByIdAsync(ServiceTickeId);
            if (ServiceTicket is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ServiceTicket);
            }
        }




        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetServiceTicketById")]
        public async Task<ActionResult<IEnumerable<ServiceTicketDetailsModel>>> GetServiceTicketById(string? ServiceTickeId)
        {
            var ServiceTicket = await _ServiceTicketService.GetServiceTicketDetailsByIdAsync(ServiceTickeId);
            if (ServiceTicket is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(ServiceTicket);

            }
        }


        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetServiceTicketCreateByIdAsync")]
        public async Task<ActionResult<IEnumerable<ServiceTicketDetailsModel>>> GetServiceTicketCreateByIdAsync(int ServiceTickeId)
        {
            var ServiceTicket = await _ServiceTicketService.GetServiceTicketCreateByIdAsync(ServiceTickeId);
            if (ServiceTicket is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(ServiceTicket);

            }
        }


        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetAllServiceTicketInfo")]
        public async Task<ActionResult<IEnumerable<ServiceTicketInfoDisplayModel>>> GetAllServiceTicketInfo([FromQuery] ServiceTicketInfoFilter serviceTicketInfoFilter)
        {
            var ServiceTicketInfo = await _ServiceTicketService.GetAllServiceTicketInfoAsync(serviceTicketInfoFilter);
            if (ServiceTicketInfo is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ServiceTicketInfo);
            }
        }




        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetServiceTicketSearchById")]
        public async Task<ActionResult<IEnumerable<ServiceTicketDetailsModel>>> GetServiceTicketSearchById(int ServiceTickeId)
        {
            var ServiceTicket = await _ServiceTicketService.GetServiceTicketByIdAsync(ServiceTickeId);
            if (ServiceTicket is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(ServiceTicket);

            }
        }



        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetAllSerialWiseServiceTicketInfo")]
        public async Task<ActionResult<IEnumerable<SerialWiseServiceTicketInfoModel>>> GetAllSerialWiseServiceTicketInfo([FromQuery] SerialWiseServiceTicketInfoFilter serialWiseServiceTicketInfoFilter)
        {
            var SerialWiseServiceTicketInfo = await _ServiceTicketService.GetAllSerialWiseServiceTicketInfoAsync(serialWiseServiceTicketInfoFilter);
            if (SerialWiseServiceTicketInfo is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(SerialWiseServiceTicketInfo);
            }
        }



        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetServiceTicketJobsheetInfo")]
        public async Task<ActionResult<IEnumerable<SerialWiseServiceTicketInfoModel>>> GetServiceTicketJobsheetIdAsync(int ServiceTickeId)
        {
            var SerialWiseServiceTicketInfo = await _ServiceTicketService.GetServiceTicketJobsheetIdAsync(ServiceTickeId);
            if (SerialWiseServiceTicketInfo is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(SerialWiseServiceTicketInfo);
            }
        }



        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetAllSerialWiseServiceTicketInfoFIR")]
        public async Task<ActionResult<IEnumerable<SerialWiseServiceTicketInfoModel>>> GetAllSerialWiseServiceTicketInfoFIRAsync([FromQuery] SerialWiseServiceTicketInfoFilter serialWiseServiceTicketInfoFilter)
        {
            var SerialWiseServiceTicketInfo = await _ServiceTicketService.GetAllSerialWiseServiceTicketInfoFIRAsync(serialWiseServiceTicketInfoFilter);
            if (SerialWiseServiceTicketInfo is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(SerialWiseServiceTicketInfo);
            }
        }


        [HttpGet("GetAllSerialWiseServiceTicketInfoFIRUnauthorized")]
        public async Task<ActionResult<IEnumerable<SerialWiseServiceTicketInfoModel>>> GetAllSerialWiseServiceTicketInfoFIRUnauthorizedAsync([FromQuery] SerialWiseServiceTicketInfoFilter serialWiseServiceTicketInfoFilter)
        {
            var SerialWiseServiceTicketInfo = await _ServiceTicketService.GetAllSerialWiseServiceTicketInfoFIRAsync(serialWiseServiceTicketInfoFilter);
            if (SerialWiseServiceTicketInfo is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(SerialWiseServiceTicketInfo);
            }
        }



        [Authorize(Policy = "LoginRequired")]
        [HttpGet("UpdateAcknowledgmentServiceTicket")]
        public async Task<IActionResult> UpdateAcknowledgmentServiceTicket(int serviceTicketId, bool isAcknowledgment, string? StatusName, string? Remark)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var updateAcknowledgmentServiceTicket = await _ServiceTicketService.UpdateAcknowledgmentServiceTicketAsync(serviceTicketId, isAcknowledgment, StatusName, Remark, User?.Identity?.Name);
                return Ok(updateAcknowledgmentServiceTicket);
            }

        }





        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetServiceRequestNoOfDays")]
        public async Task<IActionResult> GetServiceRequestNoOfDays(string productCode)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var ServiceRequestNoDays = await _ServiceTicketService.GetServiceRequestNoOfDays(productCode);
                return Ok(ServiceRequestNoDays);
            }

        }


        [Authorize(Policy = "LoginRequired")]
        [HttpPost("UpdateServiceTickeBusinessCall")]
        public async Task<IActionResult> UpdateServiceTickeBusinessCall([FromBody] businessCallModel BCall)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var updateAcknowledgmentServiceTicket = await _ServiceTicketService.UpdateServiceTickeBusinessCall(BCall.serviceTicketId, BCall.businessCallId);
                return Ok(updateAcknowledgmentServiceTicket);
            }

        }

        [Authorize(Policy = "LoginRequired")]
        [HttpPost("UpdateServiceTickeHappyCode")]
        public async Task<IActionResult> UpdateServiceTickeHappyCode([FromBody] ServiceTickeHappyCodeModel HappyCode)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var updateAcknowledgmentServiceTicket = await _ServiceTicketService.UpdateServiceTickeHappyCode(HappyCode.serviceTicketId, HappyCode.ServiceTicketNumber);
                return Ok(updateAcknowledgmentServiceTicket);
            }

        }


        [Authorize(Policy = "LoginRequired")]
        [HttpPost("ReplacementTagGet")]
        public async Task<IActionResult> ReplacementTagGet([FromBody] ServiceTickeReplacementTagModel objRTag)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var updateAcknowledgmentServiceTicket = await _ServiceTicketService.ReplacementTagGet(objRTag.ServiceTicketId, objRTag.DivCode, objRTag.ProductLineCode);
                return Ok(updateAcknowledgmentServiceTicket);
            }

        }





        //[Authorize(Policy = "LoginRequired")]
        //[HttpGet("ReplacementTagGet")]
        //public async Task<IActionResult> ReplacementTagGet(string? ServiceTicketId, string? DivCode, string? ProductLineCode)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return UnprocessableEntity(ModelState);
        //    }
        //    else
        //    {
        //        var updateAcknowledgmentServiceTicket = await _ServiceTicketService.ReplacementTagGet(ServiceTicketId, DivCode, ProductLineCode);
        //        return Ok(updateAcknowledgmentServiceTicket);
        //    }

        //}

        //[Authorize(Policy = "LoginRequired")]
        //[HttpGet("GetReplacementTag")]
        //public async Task<ActionResult<IEnumerable<ReplacementTagModel>>> ReplacementTagGet(string? ServiceTicketId, string? DivCode, string? ProductLineCode)
        //{
        //    var ServiceTicket = await _ServiceTicketService.ReplacementTagGet(ServiceTicketId, DivCode, ProductLineCode);
        //    if (ServiceTicket is null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(ServiceTicket);
        //    }
        //}


    }
}
