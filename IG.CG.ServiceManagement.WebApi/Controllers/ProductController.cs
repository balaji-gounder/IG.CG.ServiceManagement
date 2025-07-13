using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all Product Detail List.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all active Product available in the database.
        /// </remarks>
        /// <returns>Returns a collection of product objects.</returns>
        [HttpGet("GetAllProduct")]
        [Authorize(Policy = "LoginRequired")]
        public async Task<ActionResult<IEnumerable<ProductDisplayModel>>> GetProduct([FromQuery] ProductFilter productFilter)
        {
            var product = await _productService.GetAllProductAsync(productFilter);
            if (product is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }



        [HttpGet("ProductSearchGetAll")]
        [Authorize(Policy = "LoginRequired")]
        public async Task<ActionResult<IEnumerable<ProductDisplayModel>>> GetProductListAsync(string? DivisionCode, string? ProductLineCode)
        {
            var product = await _productService.GetAllProductListAsync(DivisionCode, ProductLineCode);
            if (product is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }



        [HttpGet("ProductSearchUnauthorizeGetAll")]
       
        public async Task<ActionResult<IEnumerable<ProductDisplayModel>>> GetProductListUnauthorizeAsync(string? DivisionCode, string? ProductLineCode)
        {
            var product = await _productService.GetAllProductListAsync(DivisionCode, ProductLineCode);
            if (product is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }



        /// <summary>
        /// Retrieve product Data by ProductId.
        /// </summary>
        /// <remarks>
        /// Based on product id,this endpoint returns a matching active product available in the database.
        /// </remarks>
        /// <returns>Returns a single product objects.</returns>
        [HttpGet("GetProductById")]
        [Authorize(Policy = "LoginRequired")]
        public async Task<ActionResult<ProductModel>> GetProductById(int productId)
        {
            var product = await _productService.GetProductByIdAsync(productId);
            if (product is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(product);

            }

        }

        /// <summary>
        /// Insert & Update product Information.
        /// </summary>
        /// <remarks>
        /// Insert & Update product into the database.
        /// </remarks>
        /// <returns>Returns a last saved positive product id if insert or update successfully completed
        /// If it's 1000 then product name already exists 
        /// </returns>
        [HttpPost("UpsertProduct")]
        [Authorize(Policy = "LoginRequired")]
        public async Task<ActionResult> InsertProduct(ProductModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var product = await _productService.UpsertProductAsync(productModel, User?.Identity?.Name);
                return Ok(product);
            }

        }

        /// <summary>
        /// Remove Product data.
        /// </summary>
        /// <remarks>
        /// Remove Product from the database.
        /// </remarks>
        /// <returns>
        ///  Returns a removed Product id.
        /// </returns>
        [HttpDelete("DeleteProduct")]
        [Authorize(Policy = "LoginRequired")]
        public async Task<ActionResult> RemoveProduct(int productId, int isActive)
        {
            var product = await _productService.DeleteProductAsync(productId, User?.Identity?.Name, isActive);
            return Ok(product);
        }

    }
}
