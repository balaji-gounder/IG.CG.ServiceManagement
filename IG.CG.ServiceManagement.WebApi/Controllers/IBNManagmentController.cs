using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Application.Specification;
using IG.CG.ServiceManagement.API.Helpers;
using IG.CG.ServiceManagement.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Authorize(Policy = "LoginRequired")]
    [Route("api/[controller]")]
    [ApiController]
    public class IBNManagmentController:Controller
    {
        private readonly ILogger<IBNManagmentController> _logger;
        private readonly IIBNManagmentService _ibnService;

        public IBNManagmentController(IIBNManagmentService ibnService, ILogger<IBNManagmentController> logger)
        {
            _ibnService = ibnService;
            _logger = logger;
        }
        [Authorize]
        [HttpGet("GetAllIBNManagmentList")]
        public async Task<IActionResult> GetIBNManagmentAsync([FromQuery] IBNManagmentFilter filter)
        {
            var userId = User?.Identity?.Name;
            var isExport = filter.PageSize == 0;

            try
            {
                var data = await _ibnService.GetIBNManagmentAsync(filter, userId);

                if (data == null || !data.Any())
                    return NotFound();

                if (isExport)
                {
                    var stream = AscIbnReportCsvExportHelper.GenerateZipWithCsvFile(data);
                    return File(stream, "application/zip", "IBNReport.zip");
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating IBN report.");
                return StatusCode(500, new
                {
                    Key = 500,
                    Message = "Internal server error: " + ex.Message,
                    IsSuccess = false,
                    //Data = (object)null
                });
            }
        }
    }
}
