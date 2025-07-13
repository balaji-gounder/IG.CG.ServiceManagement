using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class SAPController : Controller
    {
        private readonly ILogger<SAPController> _logger;
        private readonly ISAPService _sapService;
        public SAPController(ISAPService sapService, ILogger<SAPController> logger)
        {
            _sapService = sapService;
            _logger = logger;
        }



        [HttpGet("GetAllSAPData")]
        public async Task<ActionResult<IEnumerable<DivisionModel>>> GetSAPData([FromQuery] SAPCommonFilter SapFilter)
        {
            var Division = await _sapService.GetAllSAPAsync(SapFilter);
            if (Division is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Division);
            }
        }
    }
}
