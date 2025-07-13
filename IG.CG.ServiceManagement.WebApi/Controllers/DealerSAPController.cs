using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class DealerSAPController : Controller
    {

        private readonly IDealerSAPService _dealerSAPService;
        private readonly ILogger<DealerSAPController> _logger;

        public DealerSAPController(IDealerSAPService dealerSAPService, ILogger<DealerSAPController> logger)
        {
            this._dealerSAPService = dealerSAPService;
            this._logger = logger;
        }

        [HttpGet("GetAllSAPDealer")]
        public async Task<ActionResult<IEnumerable<DealerDisplayModel>>> GetSAPDealer([FromQuery] DealerSAPFilter baseFilter)
        {
            var dealer = await _dealerSAPService.GetAllDealerSAPAsync(baseFilter);
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
