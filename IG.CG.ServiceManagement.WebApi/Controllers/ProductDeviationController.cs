using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class ProductDeviationController : Controller
    {
        private readonly ILogger<ProductDeviationController> _logger;
        private readonly IProductDeviationService _productDeviationService;
        public ProductDeviationController(IProductDeviationService productDeviationService, ILogger<ProductDeviationController> logger)
        {
            _productDeviationService = productDeviationService;
            _logger = logger;
        }

        [HttpGet("GetAllProductDeviation")]
        public async Task<ActionResult<IEnumerable<ProductDeviationDisplayModel>>> GetProductDeviation([FromQuery] ProductDeviationFilter productDeviationFilter)
        {
            var ProductDeviation = await _productDeviationService.GetAllProductDeviationAsync(productDeviationFilter);

            if (ProductDeviation is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ProductDeviation);
            }
        }

        [HttpGet("GetProductDeviationById")]
        public async Task<ActionResult<ProductDeviationModel>> GetProductDeviationById(int productDeviationId)
        {
            var ProductDeviation = await _productDeviationService.GetProductDeviationByIdAsync(productDeviationId);
            if (ProductDeviation is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(ProductDeviation);

            }

        }

        [HttpPost("UpsertProductDeviation")]
        public async Task<ActionResult> InsertProductDeviation(ProductDeviationModel productDeviationModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var ProductDeviation = await _productDeviationService.UpsertProductDeviationAsync(productDeviationModel, User?.Identity?.Name);
                return Ok(ProductDeviation);
            }

        }

        [HttpDelete("DeleteProductDeviation")]
        public async Task<ActionResult> RemoveProductDeviation(int productDeviationId, int isActive)
        {
            var ProductDeviation = await _productDeviationService.DeleteProductDeviationAsync(productDeviationId, User?.Identity?.Name, isActive);
            return Ok(ProductDeviation);
        }


    }
}
