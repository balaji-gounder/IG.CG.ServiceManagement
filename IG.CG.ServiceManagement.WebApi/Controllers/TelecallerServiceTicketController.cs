using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace IG.CG.ServiceManagement.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class TelecallerServiceTicketController : Controller
    {
        private readonly ILogger<ProdCustInfoController> _logger;
        private readonly ITelecallerServiceTicketService _prodcustInfoService;
        public TelecallerServiceTicketController(ITelecallerServiceTicketService prodcustInfoService, ILogger<ProdCustInfoController> logger)
        {
            _prodcustInfoService = prodcustInfoService;
            _logger = logger;
        }




        [HttpGet("GetProdCustInfo")]
        [Authorize(Policy = "LoginRequired")]
        public async Task<ActionResult<IEnumerable<ProdCustInfoDisplayModel>>> GetProdCustInfo([FromQuery] string MobileNo)
        {
            var ProdCInfo = await _prodcustInfoService.GetAllProdCustInfoAsync(MobileNo);
            if (ProdCInfo is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ProdCInfo);
            }
        }


        [HttpGet("GetServiceTicketProdSerialNo")]
        [Authorize(Policy = "LoginRequired")]
        public async Task<ActionResult<ProdSerialNoWarrantySAPDisplayModel>> GetServiceTicketProdSerialNo([FromQuery] ProdSerialNoFilter psrnoFilter)
        {
            var asc = await _prodcustInfoService.GetAllProdSerialNoWarrantyServiceTicketAsync(psrnoFilter);
            if (asc is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(asc);

            }
        }


        [HttpGet("GetServiceTicketTelecallerProdSerialNo")]
        [Authorize(Policy = "LoginRequired")]
        public async Task<ActionResult<ProdSerialNoWarrantySAPDisplayModel>> GetServiceTicketTelecallerProdSerialNo([FromQuery] ProdSerialNoTelecallerFilter psrnoFilter)
        {
            var asc = await _prodcustInfoService.GetAllProdSerialNoWarrantyServiceTicketTelecallerAsync(psrnoFilter);
            if (asc is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(asc);

            }
        }





        [HttpGet("GetServiceTicketTelecallerProdSerialNoUnauthorized")]
        public async Task<ActionResult<ProdSerialNoWarrantySAPDisplayModel>> GetServiceTicketTelecallerProdSerialNoUnauthorized([FromQuery] ProdSerialNoTelecallerFilter psrnoFilter)
        {
            var asc = await _prodcustInfoService.GetAllProdSerialNoWarrantyServiceTicketTelecallerAsync(psrnoFilter);
            if (asc is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(asc);

            }
        }



        [HttpGet("GetTelecallerProdSerialNo")]
        [Authorize(Policy = "LoginRequired")]
        public async Task<ActionResult<ProductCustomerInfoDisplayModel>> GetTelecallerProdSerialNo([FromQuery] string? SerialNo, string? ProductCode)
        {
            var asc = await _prodcustInfoService.GetAllProdSerialNoAsync(SerialNo, ProductCode);
            if (asc is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(asc);

            }
        }



        //[HttpPost("UpsertTelecallerProductCustomerInfo")]
        //[Authorize(Policy = "LoginRequired")]
        //public async Task<ActionResult> InsertProductCustomerInfo([FromForm] ProductCustomerInfoModel ProcustModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return UnprocessableEntity(ModelState);
        //    }
        //    else
        //    {

        //        string UploadDocuments = "";

        //        var asc = await _prodcustInfoService.UpsertProductCustomerInfoAsync(ProcustModel, User?.Identity?.Name, UploadDocuments);
        //        return Ok(asc);

        //    }

        //}



        [HttpPost("UpsertTelecallerProductCustomerInfo")]
        [Authorize(Policy = "LoginRequired")]
        public async Task<ActionResult> UpsertProductTelecallerInfoAsync([FromForm] ProductCustomerInfoModel ProcustModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {

                string UploadDocuments = "";

                var asc = await _prodcustInfoService.UpsertProductTelecallerInfoAsync(ProcustModel, User?.Identity?.Name, UploadDocuments);
                return Ok(asc);

            }

        }

    }
}
