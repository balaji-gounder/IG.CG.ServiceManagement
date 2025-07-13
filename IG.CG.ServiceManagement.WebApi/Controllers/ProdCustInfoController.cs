using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ProdCustInfoController : Controller
    {
        private readonly ILogger<ProdCustInfoController> _logger;
        private readonly IProdCustInfoService _prodcustInfoService;


        public ProdCustInfoController(IProdCustInfoService prodcustInfoService, ILogger<ProdCustInfoController> logger)
        {
            _prodcustInfoService = prodcustInfoService;
            _logger = logger;
        }




        //[Authorize(Policy = "CustomerOTPRequired")]
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






        [HttpGet("GetServiceTicketProdSerialNo")]
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



        [HttpPost("UpsertProductCustomerASMInfo")]
        public async Task<ActionResult> UpsertProductCustomerASMInfoAsync([FromBody] ProductCustomerAMSInfoModel ProcustModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var asc = await _prodcustInfoService.UpsertProductCustomerASMInfoAsync(ProcustModel);
                return Ok(asc);

            }

        }


        [HttpPost("ServiceTicketActivityProductUpdate")]
        public async Task<ActionResult> UpsertProductActivityAsync([FromForm] ProductUpdateActivityModel ProcustModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var asc = await _prodcustInfoService.UpsertProductActivityAsync(ProcustModel);
                return Ok(asc);

            }

        }





        [HttpGet("GetProdCustInfoById")]
        public async Task<ActionResult<ProdCustInfoDisplayModel>> GetProdCustInfoById(int ProdRegAutoId)
        {
            var ProdReg = await _prodcustInfoService.GetProdCustInfoByIdAsync(ProdRegAutoId);
            if (ProdReg is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(ProdReg);

            }

        }


        [HttpPost("UpdateProdCustInfo")]
        public async Task<ActionResult> UpdateProdCustInfo([FromBody] ProdCustInfoDisplayModel PcustModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var CustV = await _prodcustInfoService.UpsertProdCustInfoAsync(PcustModel);
                return Ok(CustV);

            }
        }



        [HttpGet("GetProductCustomerDeviationInfoById")]
        public async Task<ActionResult<ProductCustomerInfoDisplayModel>> GetProductCustomerDeviationInfoById(int ProdRegAutoId)
        {
            var ProdReg = await _prodcustInfoService.GetProductCustomerDeviationInfoByIdAsync(ProdRegAutoId);
            if (ProdReg is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(ProdReg);

            }

        }



        [HttpGet("GetProductCustomerInfoById")]
        public async Task<ActionResult<ProductCustomerInfoDisplayModel>> GetProductCustomerInfoById(int ProdRegAutoId)
        {
            var ProdReg = await _prodcustInfoService.GetProductCustomerDeviationInfoByIdAsync(ProdRegAutoId);
            if (ProdReg is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(ProdReg);

            }

        }


        [HttpGet("GetProductCustomerDeviationInfoByUnauthorizeId")]
        public async Task<ActionResult<ProductCustomerInfoDisplayModel>> GetProductCustomerDeviationInfoByUnauthorizeId(int ProdRegAutoId)
        {
            var ProdReg = await _prodcustInfoService.GetProductCustomerDeviationInfoByIdAsync(ProdRegAutoId);
            if (ProdReg is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(ProdReg);

            }

        }


        [HttpGet("GetProductDeviation")]
        public async Task<ActionResult<IEnumerable<ProdCustInfoDisplayModel>>> GetProductDeviation([FromQuery] ProductDeviationFilter pciFilter)
        {
            var ProdDev = await _prodcustInfoService.GetAllProductDeviationAsync(pciFilter);
            if (ProdDev is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ProdDev);
            }
        }



        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetProductCustomeAdmin")]
        public async Task<ActionResult<IEnumerable<ProductCustomerInfoDisplayModel>>> GetProductCustomeAdmin([FromQuery] ProductCustomeAdminFilter pciFilter)
        {
            var ProdAdmin = await _prodcustInfoService.GetAllProductCustomeAdminAsync(pciFilter);
            if (ProdAdmin is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(ProdAdmin);
            }
        }




        [HttpGet("GetProductCustomeAdminByUnauthorize")]
        public async Task<ActionResult<IEnumerable<ProductCustomerInfoDisplayModel>>> GetProductCustomeAdminByUnauthorize([FromQuery] ProductCustomeAdminFilter pciFilter)
        {
            var ProdAdmin = await _prodcustInfoService.GetAllProductCustomeAdminAsync(pciFilter);
            if (ProdAdmin is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(ProdAdmin);
            }
        }



        [HttpPost("UpsertProdDeviation")]
        public async Task<ActionResult> UpsertProdDeviation([FromBody] ProdDeviationModel PcustModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var CustV = await _prodcustInfoService.UpsertProdDeviationAsync(PcustModel, User?.Identity?.Name);
                return Ok(CustV);

            }
        }

        [HttpPost("UpsertProductCustomerDealer")]
        public async Task<IActionResult> AddProductCustomerInfoDealer([FromBody] ProductCustomertDealerInfoModel ObjProdDeal)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {

                var roleWiseMenu = await _prodcustInfoService.AddProductCustomerInfoDealer(ObjProdDeal.ObjProdCustDeal, User?.Identity?.Name, ObjProdDeal.lstProdDeal);
                return Ok(roleWiseMenu);
            }


        }

        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetServiceTicketProdSerialNoAuthorize")]
        public async Task<ActionResult<ProdSerialNoWarrantySAPDisplayModel>> GetServiceTicketProdSerialNoAuthorize([FromQuery] ProdSerialNoFilter psrnoFilter)
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

        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetProdSerialNoAuthorize")]
        public async Task<ActionResult<ProdSerialNoWarrantySAPDisplayModel>> GetProdSerialNoAuthorize([FromQuery] ProdSerialNoFilter psrnoFilter)
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


        [Authorize(Policy = "LoginRequired")]
        [HttpPost("UpsertProductCustomerDealerAuthorize")]
        public async Task<IActionResult> AddProductCustomerInfoDealerAuthorize([FromBody] ProductCustomertDealerInfoModel ObjProdDeal)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {

                var roleWiseMenu = await _prodcustInfoService.AddProductCustomerInfoDealer(ObjProdDeal.ObjProdCustDeal, User?.Identity?.Name, ObjProdDeal.lstProdDeal);
                return Ok(roleWiseMenu);
            }


        }


        [HttpPost("UpserAscTicketCreate")]
        public async Task<IActionResult> AddAscTicketCreate([FromBody] List<AddAscTicketCreateModel> ObjProdDeal)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {

                var roleWiseMenu = await _prodcustInfoService.AddAscTicketCreateInfo(ObjProdDeal, User?.Identity?.Name);
                return Ok(roleWiseMenu);
            }


        }

    }
}
