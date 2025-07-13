using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class ProductGroupController : Controller
    {

        private readonly ILogger<ProductGroupController> _logger;
        private readonly IProductGroupService _productGroupService;
        public ProductGroupController(IProductGroupService productGroupService, ILogger<ProductGroupController> logger)
        {
            _productGroupService = productGroupService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all Product Group Details List.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all active Product Group available in the database.
        /// </remarks>
        /// <returns>Returns a collection of product objects.</returns>
        [HttpGet("GetAllProductGroup")]
        public async Task<ActionResult<IEnumerable<ProductGroupDisplayModel>>> GetProductGroup([FromQuery] ProductGroupFilter productGroupFilter)
        {
            var ProductGroup = await _productGroupService.GetAllProductGroupAsync(productGroupFilter);
            if (ProductGroup is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ProductGroup);
            }
        }


        /// <summary>
        /// Retrieve Product Group Data by Product Group Id.
        /// </summary>
        /// <remarks>
        /// Based on Product Group id,this endpoint returns a matching active Product Group available in the database.
        /// </remarks>
        /// <returns>Returns a single Product Group objects.</returns>
        [HttpGet("GetProductGroupById")]
        public async Task<ActionResult<ProductLineModel>> GetProductGroupById(int productGroupId)
        {
            var Branch = await _productGroupService.GetProductGroupByIdAsync(productGroupId);
            if (Branch is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(Branch);

            }

        }


        /// <summary>
        /// Insert & Update Product Group Information.
        /// </summary>
        /// <remarks>
        /// Insert & Update Product Group into the database.
        /// </remarks>
        /// <returns>Returns a last saved positive Product Group id if insert or update successfully completed
        /// If it's 1000 then Product group name already exists 
        /// </returns>
        [HttpPost("UpsertProductGroup")]
        public async Task<ActionResult> InsertProductGroup(ProductGroupModel productGroupModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var productGroup = await _productGroupService.UpsertProductGroupAsync(productGroupModel, User?.Identity?.Name);
                return Ok(productGroup);
            }

        }


        /// <summary>
        /// Remove Product Group data.
        /// </summary>
        /// <remarks>
        /// Remove Product Group from the database.
        /// </remarks>
        /// <returns>
        ///  Returns a removed Product Group id.
        /// </returns>
        [HttpDelete("DeleteProductGroup")]
        public async Task<ActionResult> RemoveProductLine(int productGroupId, int isActive)
        {
            var productGroup = await _productGroupService.DeleteProductGroupAsync(productGroupId, User?.Identity?.Name, isActive);
            return Ok(productGroup);
        }
    }
}
