using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class AsmServiceTicketCustomerController : Controller
    {
        private readonly ILogger<AsmServiceTicketCustomerController> _logger;
        private readonly IAsmServiceTicketCustomerService _asmServiceTicketCustomerService;
        public AsmServiceTicketCustomerController(IAsmServiceTicketCustomerService asmServiceTicketCustomerService, ILogger<AsmServiceTicketCustomerController> logger)
        {
            _asmServiceTicketCustomerService = asmServiceTicketCustomerService;
            _logger = logger;

        }



        [HttpPost("UpdateAsmServiceTicketCancellationApproval")]
        public async Task<ActionResult> InsertAsmServiceTicketCancellationApproval([FromBody] AsmServiceTicketCancellationApprovalModel asmServiceTicketCancellationApprovalModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var asmServiceTicketCustomer = await _asmServiceTicketCustomerService.UpdateAsmServiceTicketCancellationApprovalAsync(asmServiceTicketCancellationApprovalModel, User?.Identity?.Name);
                return Ok(asmServiceTicketCustomer);
            }

        }


        [HttpPost("UpdateAsmServiceTicketCancellationRejected")]
        public async Task<ActionResult> UpdateAsmServiceTicketCancellationRejected([FromBody] AsmServiceTicketCancellationRejectedModel asmServiceTicketCancellationRejectedModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var asmServiceTicketCustomer = await _asmServiceTicketCustomerService.UpdateAsmServiceTicketCancellationRejectedAsync(asmServiceTicketCancellationRejectedModel);
                return Ok(asmServiceTicketCustomer);
            }

        }

        [HttpGet("GetAllAscByTicketCount")]
        public async Task<ActionResult<IEnumerable<AscListByTicketCountModel>>> GetAscByTicketCount(string? UserId)
        {
            var ascListByCount = await _asmServiceTicketCustomerService.GetAllAscByTicketCountAsync(UserId);
            if (ascListByCount is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ascListByCount);
            }
        }


        [HttpGet("GetAscReportSearch")]
        public async Task<ActionResult<IEnumerable<AscListByTicketCountModel>>> GetAscReportSearch()
        {
            var ascListByCount = await _asmServiceTicketCustomerService.GetAllAscByReportSearchAsync(User?.Identity?.Name);
            if (ascListByCount is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ascListByCount);
            }
        }


        [HttpGet("GetBhranchAscReportSearch")]
        public async Task<ActionResult<IEnumerable<AscListByTicketCountModel>>> GetBhranchAscReportSearch(string? RegionCode, string? BranchCode)
        {
            var ascListByCount = await _asmServiceTicketCustomerService.GetAllAscBranchByReportSearchAsync(User?.Identity?.Name, RegionCode, BranchCode);
            if (ascListByCount is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ascListByCount);
            }
        }


        [HttpGet("GetAllAscByTicketCountASM")]
        public async Task<ActionResult<IEnumerable<AscListByTicketCountModel>>> GetAllAscByTicketCountASMAsync(string? DivCode, string? ProLineCode, string? PinCode)
        {
            var ascListByCount = await _asmServiceTicketCustomerService.GetAllAscByTicketCountASMAsync(DivCode, ProLineCode, PinCode, User?.Identity?.Name);
            if (ascListByCount is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ascListByCount);
            }
        }



        [HttpPost("InsertAscServiceTicketFIR")]
        public async Task<ActionResult> InsertAscServiceTicketFIR(AscServiceTicketFirModel ascServiceTicketFirModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var AscServiceTicketFIR = await _asmServiceTicketCustomerService.InsertAscServiceTicketFIRAsync(ascServiceTicketFirModel, User?.Identity?.Name);
                return Ok(AscServiceTicketFIR);
            }

        }


        [HttpPost("InsertAscServiceTicketDefectFIR")]
        public async Task<ActionResult> InsertAscServiceTicketDefectFIR(AscServiceTicketFirDefectModel ascServiceTicketFirModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var AscServiceTicketFIR = await _asmServiceTicketCustomerService.InsertAscServiceTicketDefectFIRAsync(ascServiceTicketFirModel);
                return Ok(AscServiceTicketFIR);
            }

        }



        [HttpPost("InsertAscServiceTicketDefect")]
        public async Task<ActionResult> InsertAscServiceTicketDefect(AscServiceTicketFirDefectOneModel ascServiceTicketFirModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var AscServiceTicketFIR = await _asmServiceTicketCustomerService.InsertAscServiceTicketDefectAsync(ascServiceTicketFirModel);
                return Ok(AscServiceTicketFIR);
            }

        }


        [HttpPost("InsertAscServiceTicketProductFIR")]
        public async Task<ActionResult> InsertAscServiceTicketProductFIRAsync([FromForm] AscServiceTicketProductFirModel ascServiceTicketFirModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var AscServiceTicketFIR = await _asmServiceTicketCustomerService.InsertAscServiceTicketProductFIRAsync(ascServiceTicketFirModel, User?.Identity?.Name);
                return Ok(AscServiceTicketFIR);
            }

        }





        [HttpPost("InsertAscServiceTicketFIRDocument")]
        public async Task<ActionResult> InsertFIRDocument([FromForm] FIRDocumentWithTypeModel firDocumentWithTypeListModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var AscServiceTicketFIRDocument = await _asmServiceTicketCustomerService.InsertFIRDocumentAsync(firDocumentWithTypeListModel);
                return Ok(AscServiceTicketFIRDocument);
            }

        }


        [HttpGet("GetAllFIRDocumentListAsync")]
        public async Task<ActionResult<IEnumerable<FIRDocumentListDisplaynModel>>> GetAllFIRDocumentListAsync(string? serviceTicketId)
        {
            var ascListByCount = await _asmServiceTicketCustomerService.GetAllFIRDocumentListAsync(serviceTicketId);
            if (ascListByCount is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ascListByCount);
            }
        }



        [HttpGet("GetCancellationRemarks")]
        public async Task<ActionResult<CancellationRemarksModel>> GetCancellationRemarks(int serviceTicketId)
        {
            var CancellationRemarks = await _asmServiceTicketCustomerService.GetCancellationRemarksAsync(serviceTicketId);
            if (CancellationRemarks is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(CancellationRemarks);

            }

        }

        [HttpGet("GetAllInternalEngineerASMList")]
        public async Task<ActionResult<IEnumerable<InternalEngineerASMListModel>>> GetAllInternalEngineerASMList(string? DivisionCode)
        {
            var internalEngineerASMList = await _asmServiceTicketCustomerService.GetAllInternalEngineerASMListAsync(DivisionCode);
            if (internalEngineerASMList is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(internalEngineerASMList);
            }
        }

        [HttpDelete("DeleteAscServiceTicketFIRDocument")]
        public async Task<ActionResult> DeleteFIRDocument(int FIRDocumentId)
        {
            var FIRDocument = await _asmServiceTicketCustomerService.DeleteAscServiceTicketFIRDocumentAsync(FIRDocumentId);
            return Ok(FIRDocument);
        }



        [HttpDelete("DeleteAscServiceTicketDefectAsync")]
        public async Task<ActionResult> DeleteFIRDefect(int FIRDefectId)
        {
            var FIRDocument = await _asmServiceTicketCustomerService.DeleteAscServiceTicketDefectAsync(FIRDefectId);
            return Ok(FIRDocument);
        }


    }
}
