using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace IG.CG.ServiceManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackServiceTicketController : Controller
    {
        private readonly ILogger<TrackServiceTicketController> _logger;
        private readonly ITrackServiceTicketService _trackServiceTicketService;
        public TrackServiceTicketController(ITrackServiceTicketService trackServiceTicketService, ILogger<TrackServiceTicketController> logger)
        {
            _trackServiceTicketService = trackServiceTicketService;
            _logger = logger;

        }

        [HttpGet("GetTrackServiceTicketDetails")]
        public async Task<ActionResult<TrackServiceTicketDetailsModel>> GetTrackServiceTicketDetails(string? SerialOrServiceTicketNo)
        {
            var TrackServiceTicket = await _trackServiceTicketService.GetTrackServiceTicketDetailsAsync(SerialOrServiceTicketNo);
            if (TrackServiceTicket is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(TrackServiceTicket);

            }

        }

        [HttpPost("UpdateServiceTicketStatus")]
        public async Task<IActionResult> UpdateServiceTicketStatus(int serviceTicketId, int ticketStatusId, int ticketSubStatusId)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var ServiceTicketStatus = await _trackServiceTicketService.UpdateServiceTicketStatusAsync(serviceTicketId, ticketStatusId, ticketSubStatusId, User?.Identity?.Name);
                return Ok(ServiceTicketStatus);
            }

        }


        [HttpGet("GetFeedbackQuestions")]
        public async Task<ActionResult<IEnumerable<FeedbackQuestionsModel>>> GetRatingQuestions(int rating)
        {
            var RatingQuestions = await _trackServiceTicketService.GetRatingQuestionsAsync(rating);
            if (RatingQuestions is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(RatingQuestions);
            }
        }

        [HttpPost("InsertFeedback")]
        public async Task<ActionResult> UpsertFeedback(FeedbackRatingModel feedbackRatingModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                var FeedbackAnswer = await _trackServiceTicketService.UpsertFeedbackAsync(feedbackRatingModel);
                return Ok(FeedbackAnswer);
            }

        }

        [HttpGet("GetFeedback")]
        public async Task<ActionResult<FeedbackRatingDisplayModel>> GetFeedback(int RatingId)
        {
            var Feedback = await _trackServiceTicketService.GetFeedbackAsync(RatingId);
            if (Feedback is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(Feedback);

            }

        }

        [HttpGet("GetAllTrackServiceTicketReport")]
        public async Task<ActionResult<IEnumerable<TrackServiceTicketReportModel>>> GetAllTrackServiceTicketReport([FromQuery] TrackServiceTicketReportFilter trackServiceTicketReportFilter)
        {
            var ServiceTicketReport = await _trackServiceTicketService.GetAllTrackServiceTicketReportAsync(trackServiceTicketReportFilter);
            if (ServiceTicketReport is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ServiceTicketReport);
            }
        }

    }
}
