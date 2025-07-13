
using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class TrackServiceTicketService : ITrackServiceTicketService
    {
        private readonly IMapper _mapper;
        private readonly ITrackServiceTicketRepository _trackServiceTicketRepository;
        public TrackServiceTicketService(IMapper mapper, ITrackServiceTicketRepository trackServiceTicketRepository)
        {
            _mapper = mapper;
            _trackServiceTicketRepository = trackServiceTicketRepository;
        }

        public async Task<TrackServiceTicketDetailsModel> GetTrackServiceTicketDetailsAsync(string? SerialOrServiceTicketNo)
        {
            var TrackServiceTicket = await _trackServiceTicketRepository.GetTrackServiceTicketDetailsAsync(SerialOrServiceTicketNo);
            var trackServiceTicketModel = _mapper.Map<TrackServiceTicketDetailsModel>(TrackServiceTicket);
            return trackServiceTicketModel;
        }

        public async Task<int?> UpdateServiceTicketStatusAsync(int serviceTicketId, int ticketStatusId, int ticketSubStatusId, string? userId)
        {
            return await _trackServiceTicketRepository.UpdateServiceTicketStatusAsync(serviceTicketId, ticketStatusId, ticketSubStatusId, userId);
        }

        public async Task<IList<FeedbackQuestionsModel>> GetRatingQuestionsAsync(int rating)
        {
            var RatingQuestions = await _trackServiceTicketRepository.GetRatingQuestionsAsync(rating);
            var ratingQuestionsModel = _mapper.Map<List<FeedbackQuestionsModel>>(RatingQuestions.ToList());
            return ratingQuestionsModel;
        }

        public async Task<string?> UpsertFeedbackAsync(FeedbackRatingModel feedbackRatingModel)
        {
            string? result;
            string? ratingId = null;
            var lstQuestionAnswerModel = _mapper.Map<List<FeedbackQuestionAnswerEntity>>(feedbackRatingModel.QuestionAnswerList);

            var feedbackRatingObj = _mapper.Map<FeedbackRatingEntity>(feedbackRatingModel);
            ratingId = await _trackServiceTicketRepository.UpsertFeedbackAsync(feedbackRatingObj);
            string serviceTicketNo = feedbackRatingObj.ServiceTicketNo;

            foreach (var paraVal in lstQuestionAnswerModel)
            {
                result = await _trackServiceTicketRepository.UpsertQuestionAnswerAsync(paraVal,ratingId, serviceTicketNo);
            }
            return ratingId;
        }

        public async Task<FeedbackRatingDisplayModel> GetFeedbackAsync(int RatingId)
        {
            var Feedback = await _trackServiceTicketRepository.GetFeedbackAsync(RatingId);
            var feedbackModel = _mapper.Map<FeedbackRatingDisplayModel>(Feedback);
            return feedbackModel;
        }

        public async Task<IList<TrackServiceTicketReportModel>> GetAllTrackServiceTicketReportAsync(TrackServiceTicketReportFilter trackServiceTicketReportFilter)
        {
            var TrackServiceTicketReport = await _trackServiceTicketRepository.GetAllTrackServiceTicketReportAsync(trackServiceTicketReportFilter);
            var TrackServiceTicketReportModel = _mapper.Map<List<TrackServiceTicketReportModel>>(TrackServiceTicketReport.ToList());
            return TrackServiceTicketReportModel;
        }

    }
}
