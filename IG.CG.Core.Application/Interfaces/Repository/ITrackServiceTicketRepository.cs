using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface ITrackServiceTicketRepository
    {
        Task<TrackServiceTicketDetailsEntity?> GetTrackServiceTicketDetailsAsync(string? SerialOrServiceTicketNo);
        Task<int?> UpdateServiceTicketStatusAsync(int serviceTicketId, int ticketStatusId, int ticketSubStatusId, string? userId);
        Task<IList<FeedbackQuestionsEntity>> GetRatingQuestionsAsync(int rating);
        Task<string?> UpsertFeedbackAsync(FeedbackRatingEntity feedbackRatingModel);
        Task<string?> UpsertQuestionAnswerAsync(FeedbackQuestionAnswerEntity questionAnswerObj, string? ratingId, string? serviceTicketNo);
        Task<FeedbackRatingDisplayEntity> GetFeedbackAsync(int RatingId);
        Task<IList<TrackServiceTicketReportEntity>> GetAllTrackServiceTicketReportAsync(TrackServiceTicketReportFilter trackServiceTicketReportFilter);


    }
}
