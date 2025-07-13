using ClosedXML.Excel;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.ServiceManagement.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class TicketReportController : Controller
    {

        private readonly ILogger<TicketReportController> _logger;
        private readonly ITicketReportService _ticketreportService;
        public TicketReportController(ITicketReportService ticketreportService, ILogger<TicketReportController> logger)
        {
            _ticketreportService = ticketreportService;
            _logger = logger;
        }


        [HttpGet("GetAllComplaintReport")]
        public async Task<IActionResult> GetAllComplaintReport([FromQuery] ReportFilter reportFilter)
        {
            var userId = User?.Identity?.Name;
            reportFilter.UserId = userId;

            var activity = await _ticketreportService.GetAllComplaintReportAsync(reportFilter, userId);

            if (activity == null)
                return NotFound();

            if (reportFilter.PageSize == 0)
            {
                var csvStream = ComplaintReportCsvExportHelper.GenerateCsvStream(activity.ToList(), ComplaintReportCsvExportHelper.ComplaintHeaderMap());
                return File(csvStream, "text/csv", $"ComplaintReport_{DateTime.Now:yyyyMMdd_HHmmss}.csv");
            }

            return Ok(activity);
        }



        [HttpGet("AllClaimApprovalTATReport")]
        public async Task<ActionResult<IEnumerable<AscServiceTicketInfoComplaintReportModel>>> GetAllClaimApprovalTATReportAsync([FromQuery] ReportFilter ReportFilter)
        {
            var Activity = await _ticketreportService.GetAllClaimApprovalTATReportAsync(ReportFilter, User?.Identity?.Name);
            if (Activity is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Activity);
            }
        }


        [HttpGet("GetAllCancelTicketReport")]
        public async Task<ActionResult<IEnumerable<ComplaintCancelReportModel>>> GetAllCancelReportTicketAsync([FromQuery] ReportFilter ReportFilter)
        {
            var Activity = await _ticketreportService.GetAllCancelReportTicketAsync(ReportFilter, User?.Identity?.Name);
            if (Activity is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Activity);
            }
        }


        [HttpGet("GetDurationTicketTatDashboard")]
        public async Task<ActionResult<IEnumerable<DurationTicketTatDashboardModel>>> GetAllDurationTicketTatDashboardAsync([FromQuery] DurationTicketFilter ReportFilter)
        {
            var Activity = await _ticketreportService.GetAllDurationTicketTatDashboardAsync(ReportFilter, User?.Identity?.Name);
            if (Activity is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Activity);
            }
        }


        [HttpGet("GetDurationOpenTicketTatDashboard")]
        public async Task<ActionResult<IEnumerable<DurationTicketTatDashboardModel>>> GetAllDurationOpenTicketTatDashboardAsync([FromQuery] DurationTicketFilter ReportFilter)
        {
            var Activity = await _ticketreportService.GetAllDurationOpenTicketTatDashboardAsync(ReportFilter, User?.Identity?.Name);
            if (Activity is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Activity);
            }
        }


        [HttpGet("GetAllDefectReport")]
        public async Task<IActionResult> GetAllDefectReportAsync([FromQuery] ReportFilter reportFilter)
        {
            var userId = User?.Identity?.Name;
            var isExport = reportFilter.PageSize == 0;

            try
            {
                var data = await _ticketreportService.GetAllDefectReportAsync(reportFilter, userId, isExport);

                if (data == null || !data.Any())
                    return NotFound();

                if (isExport)
                {
                    var stream = DefectReportCsvExportHelper.GenerateZipWithCsvFiles(data);
                    return File(stream, "application/zip", "DefectReport.zip");
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating defect report.");
                return StatusCode(500, new { Key = 500, Message = "Internal server error: " + ex.Message, IsSuccess = false, Data = (object)null });
            }
        }


        [HttpGet("GetAllRepeatedTicketsReport")]
        public async Task<ActionResult<IEnumerable<RepeatedTicketsReportModel>>> GetAllRepeatedTicketsReportAsync([FromQuery] ReportFilter ReportFilter)
        {
            var Activity = await _ticketreportService.GetAllRepeatedTicketsReportAsync(ReportFilter, User?.Identity?.Name);
            if (Activity is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Activity);
            }
        }

    }
}
