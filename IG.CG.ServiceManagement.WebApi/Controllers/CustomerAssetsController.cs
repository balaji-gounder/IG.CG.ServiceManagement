
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerAssetsController : Controller
    {
        private readonly ICustomerAssetsServices _costomerAssestServices;
        private readonly ILogger<CustomerAssetsController> _logger;


        public CustomerAssetsController(ICustomerAssetsServices costomerAssestServices, ILogger<CustomerAssetsController> logger)
        {
            this._costomerAssestServices = costomerAssestServices;
            this._logger = logger;
        }



        [HttpPost("UpsertCustomerAsset")]
        public async Task<ActionResult> InsertCustomerAssest(CustomerAssetModel model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(model);
            }
            else
            {
                var result = await _costomerAssestServices.UpsertCutomerAssetsAsync(model, model.CustAutoId.ToString());
                return Ok(result);
            }
        }


        [HttpGet("GetCustomerAssestById")]
        public async Task<ActionResult<CustomerAssetModel>> GetCustomerAssestById(int CustWiseAssetId)
        {
            var customerAssest = await _costomerAssestServices.GetCustomerAssestByIdAsync(CustWiseAssetId);
            if (customerAssest is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customerAssest);
            }
        }


        [HttpGet("GetAllCustomerAssest")]
        public async Task<ActionResult<IEnumerable<CustomerAssetDisplayModel>>> GetCustomerAssest([FromQuery] CustomerAssetFilter customerAssestFilter)
        {
            var customerAssest = await _costomerAssestServices.GetAllCustomerAssetsAsync(customerAssestFilter);
            if (customerAssest is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customerAssest);
            }
        }


        [HttpDelete("DeleteCustomerAssest")]
        public async Task<ActionResult> RemoveCustomerAssest(int CustWiseAssetId, int isActive)
        {
            var customerAssest = await _costomerAssestServices.DeleteCustomerAssestAsync(CustWiseAssetId, User?.Identity?.Name, isActive);
            return Ok(customerAssest);
        }

        [HttpGet("GetCustomerAssestBySerialNo")]
        public async Task<ActionResult<CustomerAssetModel>> GetCustomerAssestBySerialNo(string SerialNo)
        {
            var customerAssest = await _costomerAssestServices.GetCustomerAssestBySAPSerialNoAsync(SerialNo);
            if (customerAssest is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customerAssest);
            }
        }


    }
}
