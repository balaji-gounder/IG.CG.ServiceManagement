using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DealerController : Controller
    {
        private readonly IDealerService _dealerService;
        private readonly ILogger<DealerController> _logger;

        public DealerController(IDealerService dealerService, ILogger<DealerController> logger)
        {
            this._dealerService = dealerService;
            this._logger = logger;
        }


        [Authorize(Policy = "LoginRequired")]
        [HttpPost("UpsertDealer")]
        public async Task<ActionResult> InsertDealer(DealerModel dealerModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }
            else
            {
                var dealer = await _dealerService.UpsertDealerAsync(dealerModel, User?.Identity?.Name);
                return Ok(dealer);
            }
        }

        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetDealerById")]
        public async Task<ActionResult<DealerModel>> GetDealerById(int dealerId)
        {
            var dealer = await _dealerService.GetDealerByIdAsync(dealerId);
            if (dealer is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dealer);
            }
        }

        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetAllDealer")]
        public async Task<ActionResult<IEnumerable<DealerDisplayModel>>> GetDealer([FromQuery] DealerFilter baseFilter)
        {
            var dealer = await _dealerService.GetAllDealerAsync(baseFilter);
            if (dealer is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dealer);
            }
        }


        [Authorize(Policy = "LoginRequired")]
        [HttpDelete("DeleteDealer")]
        public async Task<ActionResult> RemoveDealer(int dealerId, int isActive)
        {
            var dealer = await _dealerService.DeleteDealerAsync(dealerId, User?.Identity?.Name, isActive);
            return Ok(dealer);
        }


        [HttpGet("GetDealerByCode")]
        public async Task<ActionResult<DealerModel>> GetDealerByCode(string? DealerCode)
        {
            var dealer = await _dealerService.GetDealerByCodeAsync(DealerCode);
            if (dealer is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dealer);
            }
        }

        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetDealerByCodeAuthorize")]
        public async Task<ActionResult<DealerModel>> GetDealerByCodeAuthorize(string? DealerCode)
        {
            var dealer = await _dealerService.GetDealerByCodeAsync(DealerCode);
            if (dealer is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dealer);
            }
        }

        [HttpGet("GetDealerByName")]
        public async Task<ActionResult<DealerModel>> GetDealerByName(string? DealerName)
        {
            var dealer = await _dealerService.GetDealerByNameAsync(DealerName);
            if (dealer is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dealer);
            }
        }




        [HttpPost("UpsertRetailer")]
        public async Task<ActionResult> InsertRetailer(DealerModel dealerModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }
            else
            {
                var dealer = await _dealerService.UpsertRetailerAsync(dealerModel, "");
                return Ok(dealer);
            }
        }

        [HttpGet("GetDealerUnauthorize")]
        public async Task<ActionResult<IEnumerable<DealerDisplayModel>>> GetDealerUnauthorize([FromQuery] DealerFilter baseFilter)
        {
            var dealer = await _dealerService.GetAllDealerAsync(baseFilter);
            if (dealer is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dealer);
            }
        }

        [HttpGet("GetAllDealerAndOEMUnauthorize")]
        public async Task<ActionResult<IEnumerable<DealerDisplayModel>>> GetDealerAndOEMUnauthorize(string? DealerTypeId)
        {
            var dealer = await _dealerService.GetDealerAndOEMAsync(DealerTypeId);
            if (dealer is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dealer);
            }
        }



        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetAllDealerAndOEM")]
        public async Task<ActionResult<IEnumerable<DealerDisplayModel>>> GetDealerAndOEMAsync(string? DealerTypeId)
        {
            var dealer = await _dealerService.GetDealerAndOEMAsync(DealerTypeId);
            if (dealer is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dealer);
            }
        }





    }
}
