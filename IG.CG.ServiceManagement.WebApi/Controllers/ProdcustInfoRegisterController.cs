using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{

    [Authorize(Policy = "CustomerOTPRequired")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdcustInfoRegisterController : Controller
    {

        private readonly ILogger<ProdCustInfoController> _logger;
        private readonly IProdCustInfoService _prodcustInfoService;
        public ProdcustInfoRegisterController(IProdCustInfoService prodcustInfoService, ILogger<ProdCustInfoController> logger)
        {
            _prodcustInfoService = prodcustInfoService;
            _logger = logger;
        }


        [HttpGet("GetProdCustInfo")]
        public async Task<ActionResult<IEnumerable<ProdCustInfoDisplayModel>>> GetProdCustInfo([FromQuery] ProdCustInfoFilter pciFilter)
        {
            var ProdCInfo = await _prodcustInfoService.GetAllProdCustInfoAsync(pciFilter);
            if (ProdCInfo is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ProdCInfo);
            }
        }



        [HttpGet("GetProdCustDetails")]
        public async Task<ActionResult<IEnumerable<ProdCustInfoDisplayModel>>> GetProductCustomerDetails([FromQuery] ProductDeviationFilter pciFilter)
        {
            var ProdDCustDetails = await _prodcustInfoService.GetAllProductCustomerDetailsAsync(pciFilter);
            if (ProdDCustDetails is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ProdDCustDetails);
            }
        }

        [HttpPost("UpsertCustVerification")]
        public async Task<ActionResult> InsertCustVerification([FromQuery] CustVerificationModel custvModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var CustV = await _prodcustInfoService.UpsertCustVerificationAsync(custvModel);
                return Ok(CustV);

            }

        }

        [Authorize(Policy = "CustomerOTPRequired")]
        [HttpGet("GetProdSerialNo")]
        public async Task<ActionResult<ProdSerialNoWarrantySAPDisplayModel>> GetProdSerialNo([FromQuery] ProdSerialNoFilter psrnoFilter)
        {
            var asc = await _prodcustInfoService.GetAllProdSerialNoWarrantyAsync(psrnoFilter);
            if (asc is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(asc);

            }
        }

        [Authorize(Policy = "CustomerOTPRequired")]
        [HttpPost("UpsertProductCustomerInfo")]
        public async Task<ActionResult> InsertProductCustomerInfo([FromForm] ProductCustomerInfoModel ProcustModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {

                string UploadDocuments = "";
                //if (ProcustModel?.InvoceFilePath?.Count > 0)
                //{

                //    UploadDocument objUp = new UploadDocument(Request);

                //    UploadDocuments = objUp.UploadImages1(ProcustModel.InvoceFilePath, DocumentTypes.InvoiceDocument);
                //}
                var asc = await _prodcustInfoService.UpsertProductCustomerInfoAsync(ProcustModel, User?.Identity?.Name, UploadDocuments);
                return Ok(asc);

            }

        }
    }
}
