
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.ServiceManagement.API.Helpers;
using IG.CG.ServiceManagement.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class ASMServiceTicketClaimApprovalController : Controller
    {
        private readonly ILogger<ASMServiceTicketClaimApprovalController> _logger;
        private readonly IASMServiceTicketClaimApprovalService _ASMServiceTicketClaimApprovalService;
        public ASMServiceTicketClaimApprovalController(IASMServiceTicketClaimApprovalService ASMServiceTicketClaimApprovalService, ILogger<ASMServiceTicketClaimApprovalController> logger)
        {
            _ASMServiceTicketClaimApprovalService = ASMServiceTicketClaimApprovalService;
            _logger = logger;

        }

        [HttpGet("GetAllServiceRequestClaimInfo")]
        public async Task<ActionResult<IEnumerable<ASMServiceRequestClaimInfoModel>>> GetAllServiceRequestClaimInfo([FromQuery] ASMServiceRequestClaimFilter asmServiceRequestClaimFilter)
        {
            var ServiceRequestClaimInfo = await _ASMServiceTicketClaimApprovalService.GetAllServiceRequestClaimInfoAsync(asmServiceRequestClaimFilter, User?.Identity?.Name);
            if (ServiceRequestClaimInfo is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ServiceRequestClaimInfo);
            }
        }

        [HttpGet("GetAllServiceRequestClaimAttachmentList")]
        public async Task<ActionResult<IEnumerable<ASMServiceRequestClaimInfoModel>>> GetAllServiceRequestClaimAttachmentList(int serviceTicketId)
        {
            var ServiceTicketAttachmentList = await _ASMServiceTicketClaimApprovalService.GetAllServiceRequestClaimAttachmentListAsync(serviceTicketId);
            if (ServiceTicketAttachmentList is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ServiceTicketAttachmentList);
            }
        }



        [HttpGet("GetAllServiceRequestClaimLineItems")]
        public async Task<ActionResult<IEnumerable<ASMServiceRequestClaimLineItemsModel>>> GetAllServiceRequestClaimLineItems(int serviceTicketId, string? serviceTicketIDS)
        {
            var ServiceRequestClaimLineItems = await _ASMServiceTicketClaimApprovalService.GetAllServiceRequestClaimLineItemsAsync(serviceTicketId, serviceTicketIDS, User?.Identity?.Name);
            if (ServiceRequestClaimLineItems is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ServiceRequestClaimLineItems);
            }
        }


        //[HttpPost("UpdateServiceTicketClaimApproval")]
        //public async Task<IActionResult> UpdateServiceTicketClaimApproval(int serviceTicketId, string? Remark)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return UnprocessableEntity(ModelState);
        //    }
        //    else
        //    {
        //        var UpdateServiceTicketClaimApproval = await _ASMServiceTicketClaimApprovalService.UpdateServiceTicketClaimApprovalAsync(serviceTicketId, Remark, User?.Identity?.Name);
        //        return Ok(UpdateServiceTicketClaimApproval);
        //    }

        //}




        [HttpPost("UpdateServiceTicketClaimApproval")]
        public async Task<IActionResult> InsertActivity(List<ASMServiceRequestClaimApprovalModel> lstClaimApprovalLineItems)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var ClaimApproval = await _ASMServiceTicketClaimApprovalService.UpdateServiceTicketClaimApprovalAsync(lstClaimApprovalLineItems, User?.Identity?.Name);
                return Ok(ClaimApproval);
            }

        }

        [HttpGet("GetAllASCServiceRequestClaimInfo")]
        public async Task<ActionResult<IEnumerable<ASCServiceRequestClaimInfoModel>>> GetAllASCServiceRequestClaimInfo([FromQuery] ASMServiceRequestClaimFilter asmServiceRequestClaimFilter)
        {
            var ASCServiceRequestClaimInfo = await _ASMServiceTicketClaimApprovalService.GetAllASCServiceRequestClaimInfoAsync(asmServiceRequestClaimFilter, User?.Identity?.Name);
            if (ASCServiceRequestClaimInfo is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ASCServiceRequestClaimInfo);
            }
        }






        [HttpGet("GetAllASCServiceRequestClaimLineItems")]
        public async Task<ActionResult<IEnumerable<AscClaimApprovalLineItemsModel>>> GetAllASCServiceRequestClaimLineItems(string AscCode)
        {
            var ASCServiceRequestClaimLineItems = await _ASMServiceTicketClaimApprovalService.GetAllASCServiceRequestClaimLineItemsAsync(AscCode);
            if (ASCServiceRequestClaimLineItems is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ASCServiceRequestClaimLineItems);
            }
        }

        [HttpGet("GetAllASCServiceRequestClaimManageApproval")]
        public async Task<ActionResult<IEnumerable<ASCServiceRequestClaimItemsManageApprovalModel>>> GetAllASCServiceRequestClaimManageApproval(int serviceTicketId, string? serviceTicketIDS)
        {
            var ASCServiceRequestClaimLineItems = await _ASMServiceTicketClaimApprovalService.GetAllASCServiceRequestClaimManageApprovalAsync(serviceTicketId, serviceTicketIDS);
            if (ASCServiceRequestClaimLineItems is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ASCServiceRequestClaimLineItems);
            }
        }

        [HttpPost("UpdateAscServiceTicketClaimReApproval")]
        public async Task<IActionResult> UpdateAscServiceTicketClaimReApproval(AscServiceRequestClaimReApprovalModel AscClaimReApprovalModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var ClaimReApproval = await _ASMServiceTicketClaimApprovalService.UpdateAscServiceTicketClaimReApprovalAsync(AscClaimReApprovalModel);
                return Ok(ClaimReApproval);
            }

        }

        [HttpPost("UpdateAscServiceTicketAcceptRejection")]
        public async Task<IActionResult> UpdateAscServiceTicketAcceptRejection(int serviceTicketId, int serviceTicketClaimId, bool IsAcceptRejection)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var AscClaimAcceptRejection = await _ASMServiceTicketClaimApprovalService.UpdateAscServiceTicketAcceptRejectionAsync(serviceTicketId, serviceTicketClaimId, IsAcceptRejection);
                return Ok(AscClaimAcceptRejection);
            }

        }

        [HttpPost("InsertAscSpecialApprovalClaim")]
        public async Task<ActionResult> InsertAscSpecialApprovalClaim([FromForm] AscSpecialApprovalClaimModel ascSpecialApprovalClaimModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var AscServiceTicketSpecialApprovalClaim = await _ASMServiceTicketClaimApprovalService.InsertAscSpecialApprovalClaimAsync(ascSpecialApprovalClaimModel, User?.Identity?.Name);
                return Ok(AscServiceTicketSpecialApprovalClaim);
            }

        }

        [HttpPost("InsertAscIBNGeneration")]
        public async Task<IActionResult> InsertAscIBNGeneration(string AscCode, string IBNGenerationDate)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var IBNGeneration = await _ASMServiceTicketClaimApprovalService.InsertAscIBNGenerationAsync(AscCode, IBNGenerationDate);
                return Ok(IBNGeneration);
            }

        }


        [HttpGet("GetAllAscIBNGeneratedList")]
        public async Task<ActionResult<IEnumerable<AscIBNListModel>>> GetAllAscIBNGeneratedList([FromQuery] AscIBNGeneratedListFilter AscIBNGeneratedListFilter)
        {
            var AscIBNGeneratedList = await _ASMServiceTicketClaimApprovalService.GetAllAscIBNGeneratedListAsync(AscIBNGeneratedListFilter, User?.Identity?.Name);
            if (AscIBNGeneratedList is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(AscIBNGeneratedList);
            }
        }

        [HttpGet("GetIBNPdfDetails")]
        public async Task<ActionResult<IBNPdfInfoModel>> GetIBNPdfDetails(string? IBNNumber, string AscCode)
        {
            var IBNPdfDetails = await _ASMServiceTicketClaimApprovalService.GetIBNPdfDetailsAsync(IBNNumber, AscCode);
            if (IBNPdfDetails is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(IBNPdfDetails);
            }
        }



        //[HttpGet("GetAllServiceRequestClaimInfoView")]
        //public async Task<ActionResult<IEnumerable<ASMServiceRequestClaimInfoModel>>> GetAllServiceRequestClaimInfoView([FromQuery] ASMServiceRequestClaimFilter asmServiceRequestClaimFilter)
        //{
        //    var ServiceRequestClaimInfo = await _ASMServiceTicketClaimApprovalService.GetAllServiceRequestClaimInfoViewAsync(asmServiceRequestClaimFilter, User?.Identity?.Name);
        //    if (ServiceRequestClaimInfo is null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(ServiceRequestClaimInfo);
        //    }
        //}



        [HttpGet("GetAllServiceRequestClaimLineItemsView")]
        public async Task<ActionResult<IEnumerable<ASCServiceRequestClaimItemsManageApprovalModel>>> GetAllServiceRequestClaimLineItemsView([FromQuery] ClaimLineItemsViewFilter ClaimLineItemsViewFilter)
        {
            var ServiceRequestClaimLineItems = await _ASMServiceTicketClaimApprovalService.GetAllServiceRequestClaimLineItemsViewAsync(ClaimLineItemsViewFilter, User?.Identity?.Name);

            if (ServiceRequestClaimLineItems == null)
                return NotFound();

            if (ClaimLineItemsViewFilter.PageSize == 0)
            {
                var csvZipStream = ClaimListingCsvExportHelper.GenerateZippedCsvStream(
                    ServiceRequestClaimLineItems.ToList(),
                    ClaimListingCsvExportHelper.ClaimlistingHeaderMap(),
                    $"ClaimListing_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                );

                return File(csvZipStream, "application/zip", $"ClaimListing__{DateTime.Now:yyyyMMdd_HHmmss}.zip");
            }

            return Ok(ServiceRequestClaimLineItems);
        }

        [HttpPost("UpdateAsmServiceTicketClaimAmountDistance")]
        public async Task<IActionResult> UpdateAsmServiceTicketClaimAmountDistance(AsmServiceTicketClaimAmountDistanceModel AsmClaimDistanceUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var ClaimAmountDistanceUpdate = await _ASMServiceTicketClaimApprovalService.UpdateAsmServiceTicketClaimAmountDistanceAsync(AsmClaimDistanceUpdateModel);
                return Ok(ClaimAmountDistanceUpdate);
            }

        }



        [HttpPost("UpdateAsmIBNTicketClaimAmount")]
        public async Task<IActionResult> UpdateAsmIBNTicketClaimAmountAsync(AsmIBNTicketClaimAmountModel AsmClaimAmountUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var ClaimAmountDistanceUpdate = await _ASMServiceTicketClaimApprovalService.UpdateAsmIBNTicketClaimAmountAsync(AsmClaimAmountUpdateModel);
                return Ok(ClaimAmountDistanceUpdate);
            }

        }


        [HttpPost("DeleteIBNTicketClaimAmount")]
        public async Task<IActionResult> DeleteIBNTicketClaimAmount(AsmIBNTicketClaimAmountModel AsmClaimAmountUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var ClaimAmountDistanceUpdate = await _ASMServiceTicketClaimApprovalService.DeleteAsmIBNTicketClaimAmountAsync(AsmClaimAmountUpdateModel);
                return Ok(ClaimAmountDistanceUpdate);
            }

        }



        [HttpGet("GetAllASMSpecialApproval")]
        public async Task<ActionResult<IEnumerable<ASMSpecialApprovalLineItemsModel>>> GetAllASMSpecialApproval()
        {
            var ASMSpecialApprovalLineItems = await _ASMServiceTicketClaimApprovalService.GetAllASMSpecialApprovalAsync(User?.Identity?.Name);
            if (ASMSpecialApprovalLineItems is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ASMSpecialApprovalLineItems);
            }
        }

        [HttpGet("GetAllRSMSpecialApproval")]
        public async Task<ActionResult<IEnumerable<RSMSpecialApprovalLineItemsModel>>> GetAllRSMSpecialApproval()
        {
            var RSMSpecialApprovalLineItems = await _ASMServiceTicketClaimApprovalService.GetAllRSMSpecialApprovalAsync(User?.Identity?.Name);
            if (RSMSpecialApprovalLineItems is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(RSMSpecialApprovalLineItems);
            }
        }

        [HttpPost("UpdateRSMSpecialApproval")]
        public async Task<IActionResult> UpdateRSMSpecialApproval(UpdateRSMSpecialApprovalModel updateRSMSpecialApprovalModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var RsmSpecialApprovalRejection = await _ASMServiceTicketClaimApprovalService.UpdateRSMSpecialApprovalAsync(updateRSMSpecialApprovalModel, User?.Identity?.Name);
                return Ok(RsmSpecialApprovalRejection);
            }

        }

        [HttpPost("UpdateASMAcceptRejectionResubmission")]
        public async Task<IActionResult> UpdateASMAcceptRejectionResubmission(UpdateASMAcceptRejectionResubmissionModel UpdateASMAcceptRejectionResubmissionModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var RsmSpecialApprovalRejection = await _ASMServiceTicketClaimApprovalService.UpdateASMAcceptRejectionResubmissionAsync(UpdateASMAcceptRejectionResubmissionModel);
                return Ok(RsmSpecialApprovalRejection);
            }

        }

        [HttpGet("GetAllSpecialApprovalClaimAttachmentList")]
        public async Task<ActionResult<IEnumerable<SpecialApprovalClaimAttachmentListModel>>> GetAllSpecialApprovalClaimAttachmentList(string? specialApprovalId, string? serviceTicketId)
        {
            var SpecialApprovalAttachmentList = await _ASMServiceTicketClaimApprovalService.GetAllSpecialApprovalClaimAttachmentListAsync(specialApprovalId, serviceTicketId);
            if (SpecialApprovalAttachmentList is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(SpecialApprovalAttachmentList);
            }
        }

        [HttpGet("GetAllASMSpecialApprovalByServiceTicketId")]
        public async Task<ActionResult<IEnumerable<ASMSpecialApprovalLineItemsModel>>> GetAllASMSpecialApprovalByServiceTicketId(string? serviceTicketId)
        {
            var ASMSpecialApprovalLineItems = await _ASMServiceTicketClaimApprovalService.GetAllASMSpecialApprovalByServiceTicketIdAsync(User?.Identity?.Name, serviceTicketId);
            if (ASMSpecialApprovalLineItems is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ASMSpecialApprovalLineItems);
            }
        }

        [HttpGet("GetAllSpecialApprovalClaim")]
        public async Task<ActionResult<IEnumerable<ASCSpecialApprovalLineItemsModel>>> GetAllSpecialApprovalClaim(int serviceTicketId)
        {
            var ASCSpecialApprovalLineItems = await _ASMServiceTicketClaimApprovalService.GetAllSpecialApprovalClaimAsync(serviceTicketId, User?.Identity?.Name);
            if (ASCSpecialApprovalLineItems is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ASCSpecialApprovalLineItems);
            }
        }

    }
}
