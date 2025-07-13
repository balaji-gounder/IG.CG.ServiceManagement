using IG.CG.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CommonController : Controller
    {
        private readonly ILogger<CommonController> _logger;
        private readonly ICommonService _commonValService;
        public CommonController(ICommonService commonService, ILogger<CommonController> logger)
        {
            _commonValService = commonService;
            _logger = logger;
        }

        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetAllCommon")]
        public async Task<IActionResult> GetAllCommon(int mode, int Id, string Code)
        {
            var paraTypeResult = await _commonValService.GetAllCommonAsync(mode, Id, Code);
            return Ok(paraTypeResult);
        }

        [HttpGet("GetAllCommonUnauthorize")]
        public async Task<IActionResult> GetAllCommonUnauthorize(int mode, int Id, string Code)
        {
            var paraTypeResult = await _commonValService.GetAllCommonAsync(mode, Id, Code);
            return Ok(paraTypeResult);
        }


        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetAllActivityStatus")]
        public async Task<IActionResult> GetAllActivityStatusAsync(int ServiceTicketId, int ActivityType, string DivisionCode)
        {
            var paraTypeResult = await _commonValService.GetAllActivityStatusAsync(ServiceTicketId, ActivityType, DivisionCode);
            return Ok(paraTypeResult);
        }


        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetAllActivitySubStatus")]
        public async Task<IActionResult> GetAllActivitySubStatusAsync(int ServiceTicketId, int ActivityStatusId)
        {
            var paraTypeResult = await _commonValService.GetAllActivitySubStatusAsync(ServiceTicketId, ActivityStatusId);
            return Ok(paraTypeResult);
        }

        [Authorize(Policy = "LoginRequired")]
        [HttpGet("GetAllClaimDeviationAsync")]
        public async Task<IActionResult> GetAllClaimDeviationAsync(int ServiceTicketId, string DivisionCode)
        {
            var paraTypeResult = await _commonValService.GetAllClaimDeviationAsync(ServiceTicketId, DivisionCode);
            return Ok(paraTypeResult);
        }


        [HttpGet("GetAllProductLineFrontAsync")]
        public async Task<IActionResult> GetAllProductLineFrontAsync(int? ProductLineFrontId)
        {
            var paraTypeResult = await _commonValService.GetAllProductLineFrontAsync(ProductLineFrontId);
            return Ok(paraTypeResult);
        }


    }
}
