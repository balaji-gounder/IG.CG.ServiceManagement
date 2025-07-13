using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Specification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Authorize(Policy = "LoginRequired")]
    [Route("api/[controller]")]
    [ApiController]

    public class UniversalSearchController : Controller
    {
        private readonly ILogger<UniversalSearchController> _logger;
        private readonly IUniversalSearchService _universalSearchService;

        public UniversalSearchController(ILogger<UniversalSearchController> logger, IUniversalSearchService universalSearchService)
        {
            _logger = logger;
            _universalSearchService = universalSearchService;
        }

        [HttpGet("GetUniversalSearch_SearchTicketInfo")]

        public async Task<ActionResult<IEnumerable<UniversalSearchModel>>> GetUniversalSearchAsync([FromQuery] UniversalSearchFilter universalSearchFilter)
        {
            var costing = await _universalSearchService.GetUniversalSearchAsync(universalSearchFilter);
            if (costing is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(costing);
            }
        }
    }
}
