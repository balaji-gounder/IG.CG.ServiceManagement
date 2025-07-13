using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class VendorController : Controller
    {
        private readonly ILogger<VendorController> _logger;
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorService, ILogger<VendorController> logger)
        {
            _vendorService = vendorService;
            _logger = logger;

        }


        [HttpGet("GetAllVendor")]
        public async Task<ActionResult<IEnumerable<VendorDisplayModel>>> GetVendor([FromQuery] VendorFilter vendorFilter)
        {
            var Vendor = await _vendorService.GetAllVendorAsync(vendorFilter);
            if (Vendor is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Vendor);
            }

        }


        //Insert and update vendor

        [HttpPost("UpsertVendor")]
        public async Task<ActionResult<VendorModel>> InsertVendor(VendorModel vendorModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var vendor = await _vendorService.UpsertVendorAsync(vendorModel, User?.Identity?.Name);
                return Ok(vendor);
            }
        }

        [HttpGet("GetVendorById")]
        public async Task<ActionResult<VendorDisplayModel>> GetVendorById(int vendorId)
        {
            var Vendor = await _vendorService.GetVendorByIdAsync(vendorId);
            if (Vendor is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(Vendor);

            }

        }


        [HttpDelete("DeleteVendor")]
        public async Task<ActionResult> RemoveVendor(int vendorId, int isActive)
        {
            var vendor = await _vendorService.DeleteVendorAsync(vendorId, User?.Identity?.Name, isActive);
            return Ok(vendor);

        }




        [HttpGet("GetAllVendorAsyncByProduct")]
        public async Task<ActionResult<IEnumerable<VendorDisplayModel>>> GetDefectCategoryByProduct(string? divisionCode, string? productLineCode, string? productGroupCode)
        {
            var DefectCategory = await _vendorService.GetAllVendorAsyncByProductAsync(divisionCode, productLineCode, productGroupCode);
            if (DefectCategory is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(DefectCategory);
            }
        }
    }
}
