
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface ITrackServiceTicketService
    {
        Task<TrackServiceTicketDetailsModel> GetTrackServiceTicketDetailsAsync(string? SerialOrServiceTicketNo);
        Task<int?> UpdateServiceTicketStatusAsync(int serviceTicketId, int ticketStatusId, int ticketSubStatusId, string? userId);
        Task<IList<FeedbackQuestionsModel>> GetRatingQuestionsAsync(int rating);
        Task<string?> UpsertFeedbackAsync(FeedbackRatingModel feedbackRatingModel);
        Task<FeedbackRatingDisplayModel> GetFeedbackAsync(int RatingId);
        Task<IList<TrackServiceTicketReportModel>> GetAllTrackServiceTicketReportAsync(TrackServiceTicketReportFilter trackServiceTicketReportFilter);

    }
}
