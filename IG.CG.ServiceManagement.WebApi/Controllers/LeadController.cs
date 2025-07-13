using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class LeadController : Controller
    {

        private readonly ILogger<LeadController> _logger;
        private readonly ILeadService _leadService;
        public LeadController(ILeadService leadService, ILogger<LeadController> logger)
        {
            _leadService = leadService;
            _logger = logger;
        }

        [HttpGet("GetAllLead")]
        public async Task<ActionResult<IEnumerable<LeadDisplayModel>>> Getlead([FromQuery] LeadFilter leadFilter)
        {
            var lead = await _leadService.GetAllLeadAsync(leadFilter, User?.Identity?.Name);
            if (lead is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(lead);
            }
        }


        [HttpPost("UpsertLead")]
        public async Task<ActionResult> InsertLead(LeadModel leadModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var lead = await _leadService.UpsertLeadAsync(leadModel, User?.Identity?.Name);
                return Ok(lead);
            }

        }



        [HttpGet("GetLeadById")]
        public async Task<ActionResult<LeadModel>> GetLeadById(int leadId)
        {
            var Branch = await _leadService.GetLeadByIdAsync(leadId);
            if (Branch is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(Branch);

            }

        }


        [HttpDelete("DeleteLead")]
        public async Task<ActionResult> RemoveLead(int? leadId, int? isActive, string? DeleteRemark)
        {
            var lead = await _leadService.DeleteLeadAsync(leadId, User?.Identity?.Name, isActive, DeleteRemark);
            return Ok(lead);
        }




        [HttpDelete("DeleteLeadProduct")]
        public async Task<ActionResult> RemoveLeadProduct(int divisionLeadId)
        {
            var lead = await _leadService.DeleteLeadProductAsync(divisionLeadId);
            return Ok(lead);
        }


        [HttpGet("GetAllLeadsDashboard")]
        public async Task<ActionResult<IEnumerable<LeadsDashboardModel>>> GetLeadsDashboard([FromQuery] LeadsDashboardFilter leadFilter)
        {
            var lead = await _leadService.GetLeadsDashboardAsync(leadFilter, User?.Identity?.Name);
            if (lead is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(lead);
            }
        }


        [HttpGet("GetMonthWishLeadsLineChartDashboard")]
        public async Task<ActionResult<IEnumerable<LeadsDashboardModel>>> GetMonthWishLeadsLineChartDashboard([FromQuery] LeadsDashboardFilter leadFilter)
        {
            var lead = await _leadService.GetMonthWishLeadsLineChartAsync(leadFilter, User?.Identity?.Name);
            if (lead is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(lead);
            }
        }

        [HttpGet("GetLeadActivityStatusPieChartDashboard")]
        public async Task<ActionResult<IEnumerable<LeadsDashboardModel>>> GetLeadActivityStatusPieChartDashboard([FromQuery] LeadsDashboardFilter leadFilter)
        {
            var lead = await _leadService.GetLeadActivityStatusPieChartAsync(leadFilter, User?.Identity?.Name);
            if (lead is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(lead);
            }
        }

    }
}
