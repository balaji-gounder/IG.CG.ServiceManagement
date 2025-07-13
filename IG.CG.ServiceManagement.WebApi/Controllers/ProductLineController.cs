using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class ProductLineController : Controller
    {
        private readonly ILogger<ProductLineController> _logger;
        private readonly IProductLineService _productLineService;
        public ProductLineController(IProductLineService productLineService, ILogger<ProductLineController> logger)
        {
            _productLineService = productLineService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all Product Line Details List.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all active Product Line available in the database.
        /// </remarks>
        /// <returns>Returns a collection of product line objects.</returns>
        [HttpGet("GetAllProductLine")]
        public async Task<ActionResult<IEnumerable<ProductLineDisplayModel>>> GetProductLine([FromQuery] ProductLineFilter productLineFilter)
        {
            var ProductLine = await _productLineService.GetAllProductLineAsync(productLineFilter);
            if (ProductLine is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ProductLine);
            }
        }


        /// <summary>
        /// Retrieve Product Line Data by BranchId.
        /// </summary>
        /// <remarks>
        /// Based on Product Line id,this endpoint returns a matching active Product Line available in the database.
        /// </remarks>
        /// <returns>Returns a single Product Line objects.</returns>
        [HttpGet("GetProductLineById")]
        public async Task<ActionResult<ProductLineModel>> GetProductLineById(int productLineId)
        {
            var ProductLine = await _productLineService.GetProductLineByIdAsync(productLineId);
            if (ProductLine is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(ProductLine);

            }

        }

        /// <summary>
        /// Insert & Update Product Line Information.
        /// </summary>
        /// <remarks>
        /// Insert & Update Product Line into the database.
        /// </remarks>
        /// <returns>Returns a last saved positive Product Line id if insert or update successfully completed
        /// If it's 1000 then Product Line name already exists 
        /// </returns>
        [HttpPost("UpsertProductLine")]
        public async Task<ActionResult> InsertProductLine(ProductLineModel productLineModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var productLine = await _productLineService.UpsertProductLineAsync(productLineModel, User?.Identity?.Name);
                return Ok(productLine);
            }

        }

        /// <summary>
        /// Remove Product Line data.
        /// </summary>
        /// <remarks>
        /// Remove Product Line from the database.
        /// </remarks>
        /// <returns>
        ///  Returns a removed Product Line id.
        /// </returns>
        [HttpDelete("DeleteProductLine")]
        public async Task<ActionResult> RemoveProductLine(int productLineId, int isActive)
        {
            var productline = await _productLineService.DeleteProductLineAsync(productLineId, User?.Identity?.Name, isActive);
            return Ok(productline);
        }



        /// <summary>
        /// Retrieves all Division Wise Product Line Details List.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all active Division Wise Product Line available in the database.
        /// </remarks>

        [HttpGet("GetAllDivisionWiseProductLine")]
        public async Task<ActionResult<IEnumerable<ProductLineDisplayModel>>> GetProductLineByDivisionAsync(string divisionCode)
        {
            var ProductLine = await _productLineService.GetProductLineByDivisionAsync(divisionCode);
            if (ProductLine is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ProductLine);
            }
        }
    }
}
