using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Authorize(Policy = "LoginRequired")]
    [Route("api/[controller]")]
    [ApiController]
    public class ASCDetailsController : Controller
    {
        private readonly ILogger<ASCDetailsController> _logger;
        private readonly IASCDetailsService _ascdetailsService;

        public ASCDetailsController(IASCDetailsService ascdetailsservice, ILogger<ASCDetailsController> logger)
        {
            _ascdetailsService = ascdetailsservice;
            _logger = logger;
        }

        [HttpGet("GetASCDetails")]
        public async Task<ActionResult<IEnumerable<ASCDetailsModel>>> GetASCDetailsAsync([FromQuery] ASCDetailsFilter ascdetailsfilter)
        {

            string userID = User.Identity.Name;
            ascdetailsfilter.UserID = userID;
            var details = await _ascdetailsService.GetASCDetailsAsync(ascdetailsfilter);
            if (details is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(details);
            }
        }
    }
}
