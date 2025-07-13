using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Enums;
using IG.CG.Core.Domain.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "LoginRequired")]
    public class LeadFollowupController : Controller
    {
        private readonly ILogger<LeadFollowupController> _logger;
        private readonly ILeadsFollowupListService _leadFollowupService;
        public LeadFollowupController(ILeadsFollowupListService leadFollowupService, ILogger<LeadFollowupController> logger)
        {
            _leadFollowupService = leadFollowupService;
            _logger = logger;
        }

        [HttpPost("UpsertLeadFollowup")]
        public async Task<ActionResult> InsertLeadFollowup([FromForm] LeadFollowupModel leadModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                string UploadDocuments = "";
                if (leadModel?.UploadDocuments?.Count > 0)
                {

                    UploadDocument objUp = new UploadDocument(Request);

                    UploadDocuments = objUp.UploadImages1(leadModel.UploadDocuments, DocumentTypes.LmsDocument);
                }
                var LeadFollowup = await _leadFollowupService.UpsertleadFollowupAsync(leadModel, User?.Identity?.Name, UploadDocuments);
                return Ok(LeadFollowup);

            }

        }


        [HttpGet("GetAllLeadFollowup")]
        public async Task<ActionResult<IEnumerable<LeadsFollowupListModel>>> GetLeadFollowup([FromQuery] LeadFilter leadFilter)
        {
            var LeadFollowup = await _leadFollowupService.GetAllLeadFollowuplistAsync(leadFilter, User?.Identity?.Name);
            if (LeadFollowup is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(LeadFollowup);
            }
        }


        [HttpGet("GetAllLeadActivity")]
        public async Task<ActionResult<IEnumerable<LeadActivityModel>>> GetAllLeadActivityAsync(int activityId)
        {
            var LeadActivity = await _leadFollowupService.GetAllLeadActivityAsync(activityId);
            if (LeadActivity is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(LeadActivity);
            }
        }



        [HttpGet("GetLeadFollowupById")]
        public async Task<ActionResult<LeadFollowupSelectModel>> GetLeadFollowupById(int leadId)
        {
            var Branch = await _leadFollowupService.GetAllLeadFollowupByIdAsync(leadId);
            if (Branch is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(Branch);

            }

        }


        [HttpGet("download")]
        public IActionResult DownloadFile(string FilePath)
        {
            try
            {

                var _downloadDirectory = FilePathQueries.LmsFilepath;
                //var filePath = FilePath;
                var filePath = Path.Combine(_downloadDirectory, FilePath);

                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("File not found");
                }

                var fileStream = System.IO.File.OpenRead(filePath);

                // Determine the MIME type of the file
                var contentType = "application/octet-stream"; // Default MIME type



                return File(fileStream, contentType, FilePath);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
