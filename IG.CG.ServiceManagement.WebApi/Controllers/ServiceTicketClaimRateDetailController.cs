using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class ServiceTicketClaimRateDetailController : Controller
    {
        private readonly ILogger<ServiceTicketClaimRateDetailController> _logger;
        private readonly IServiceTicketClaimRateDetailService _ascServiceClaimRequestService;
        public ServiceTicketClaimRateDetailController(IServiceTicketClaimRateDetailService ascServiceClaimRequestService, ILogger<ServiceTicketClaimRateDetailController> logger)
        {
            _ascServiceClaimRequestService = ascServiceClaimRequestService;
            _logger = logger;

        }


        [HttpGet("GetAllServiceTicketClaimRateDetail")]
        public async Task<ActionResult<IEnumerable<ServiceTicketClaimRateDetailModel>>> GetAllServiceTicketClaimRateDetail(int serviceTicketId)
        {
            var TypeOfWorkDone = await _ascServiceClaimRequestService.GetAllServiceTicketClaimRateDetailAsync(serviceTicketId);
            if (TypeOfWorkDone is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(TypeOfWorkDone);
            }
        }
    }
}
