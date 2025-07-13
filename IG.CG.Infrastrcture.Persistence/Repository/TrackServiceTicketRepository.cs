using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class TrackServiceTicketRepository : ITrackServiceTicketRepository
    {
        private readonly ISqlDbContext _trackServiceTicketRepository;
        public TrackServiceTicketRepository(ISqlDbContext trackServiceTicketRepository)
        {
            _trackServiceTicketRepository = trackServiceTicketRepository;
        }

        public async Task<TrackServiceTicketDetailsEntity?> GetTrackServiceTicketDetailsAsync(string? SerialOrServiceTicketNo)
        {
            var para = new DynamicParameters();
            para.Add("@SerialOrServiceTicketNo", SerialOrServiceTicketNo);
            return await _trackServiceTicketRepository.GetAsync<TrackServiceTicketDetailsEntity>(TrackServiceTicketQueries.GetTrackServiceTicketDetails, para);
        }

        public async Task<int?> UpdateServiceTicketStatusAsync(int serviceTicketId, int ticketStatusId, int ticketSubStatusId, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", serviceTicketId);
            para.Add("@TicketStatusId", ticketStatusId);
            para.Add("@TicketSubStatusId", ticketSubStatusId);
            para.Add("@UserId", userId);

            var result = await _trackServiceTicketRepository.ExecuteScalarAsync<int?>(TrackServiceTicketQueries.UpdateServiceTicketStatus, para);
            return result;
        }

        public async Task<IList<FeedbackQuestionsEntity>> GetRatingQuestionsAsync(int rating)
        {
            var para = new DynamicParameters();
            para.Add("@Rating", rating);
            var lstActivity = await _trackServiceTicketRepository.GetAllAsync<FeedbackQuestionsEntity>(TrackServiceTicketQueries.GetRatingQuestions, para);

            return lstActivity.ToList();
        }

        public async Task<string?> UpsertFeedbackAsync(FeedbackRatingEntity feedbackRatingObj)
        {
            var para = new DynamicParameters();
            para.Add("@Rating", feedbackRatingObj.Rating);
            para.Add("@Feedback", feedbackRatingObj.Feedback);
            para.Add("@ServiceTicketNo", feedbackRatingObj.ServiceTicketNo);
            para.Add("@UserIPAddress", feedbackRatingObj.UserIPAddress);

            var result = await _trackServiceTicketRepository.ExecuteScalarAsync<string?>(TrackServiceTicketQueries.InsertFeedbackRating, para);
            return result;
        }

        public async Task<string?> UpsertQuestionAnswerAsync(FeedbackQuestionAnswerEntity questionAnswerObj, string? ratingId, string? serviceTicketNo)
        {
            var para = new DynamicParameters();
            para.Add("@RatingId", ratingId);
            para.Add("@QuestionId", questionAnswerObj.QuestionId);
            para.Add("@Answer", questionAnswerObj.Answer);
            para.Add("@ServiceTicketNo", serviceTicketNo);

            var result = await _trackServiceTicketRepository.ExecuteScalarAsync<string?>(TrackServiceTicketQueries.InsertQuestionAnswer, para);
            return result;
        }

        public async Task<FeedbackRatingDisplayEntity> GetFeedbackAsync(int RatingId)
        {
            var para = new DynamicParameters();
            para.Add("@RatingId", RatingId);
            var feedbackRating = await _trackServiceTicketRepository.GetAsync<FeedbackRatingDisplayEntity>(TrackServiceTicketQueries.GetFeedbackRating, para);
            FeedbackRatingDisplayEntity ObjFeedback = new FeedbackRatingDisplayEntity();
            if (feedbackRating == null)
            {
                return feedbackRating;
            }
            ObjFeedback.ServiceTicketNo = feedbackRating.ServiceTicketNo;
            ObjFeedback.RatingId = feedbackRating.RatingId;
            ObjFeedback.Rating = feedbackRating.Rating;
            ObjFeedback.Feedback = feedbackRating.Feedback;
            ObjFeedback.CreatedOn = feedbackRating.CreatedOn;
            ObjFeedback.UserIPAddress = feedbackRating.UserIPAddress;

            var paraD = new DynamicParameters();
            paraD.Add("@RatingId", feedbackRating.RatingId);
            var lstQuestionAnswer = await _trackServiceTicketRepository.GetAllAsync<FeedbackQuestionAnswerDisplayEntity>(TrackServiceTicketQueries.GetQuestionAnswer, paraD);
            List<FeedbackQuestionAnswerDisplayEntity> QuestionAnswerlist = new List<FeedbackQuestionAnswerDisplayEntity>();
            FeedbackQuestionAnswerDisplayEntity ObjQuestionAnswer = null;
            if (lstQuestionAnswer != null)
            {
                foreach (var itemldp in lstQuestionAnswer)
                {
                    ObjQuestionAnswer = new FeedbackQuestionAnswerDisplayEntity();
                    ObjQuestionAnswer.Question = itemldp.Question;
                    ObjQuestionAnswer.Answer = itemldp.Answer;

                    QuestionAnswerlist.Add(ObjQuestionAnswer);
                }
            }
            ObjFeedback.QuestionAnswerList = QuestionAnswerlist;


            return ObjFeedback;
        }

        public async Task<IList<TrackServiceTicketReportEntity>> GetAllTrackServiceTicketReportAsync(TrackServiceTicketReportFilter trackServiceTicketReportFilter)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketNo", trackServiceTicketReportFilter.ServiceTicketNo);
            para.Add("@ProductCode", trackServiceTicketReportFilter.ProductCode);
            para.Add("@Rating", trackServiceTicketReportFilter.Rating);
            para.Add("@CustomerName", trackServiceTicketReportFilter.CustomerName);
            para.Add("@PageSize", trackServiceTicketReportFilter.PageSize);
            para.Add("@PageNumber", trackServiceTicketReportFilter.PageNumber);
            var lstReport = await _trackServiceTicketRepository.GetAllAsync<TrackServiceTicketReportEntity>(TrackServiceTicketQueries.GetTrackServiceTicketReport, para);

            List<TrackServiceTicketReportEntity> lstTrackServiceTicketReport = new List<TrackServiceTicketReportEntity>();
            TrackServiceTicketReportEntity ObjReport = null;

            foreach (var item in lstReport)
            {
                ObjReport = new TrackServiceTicketReportEntity();
                ObjReport.RatingId = item.RatingId;
                ObjReport.TotalRows = item.TotalRows;
                ObjReport.ServiceTicketNo = item.ServiceTicketNo;
                ObjReport.CustomerName = item.CustomerName;
                ObjReport.ProductName = item.ProductName;
                ObjReport.Rating = item.Rating;
                ObjReport.Feedback = item.Feedback;
                ObjReport.CreatedOn = item.CreatedOn;
                ObjReport.UserIPAddress = item.UserIPAddress;


                var paraQA = new DynamicParameters();
                paraQA.Add("@RatingId", item.RatingId);
                var lstQuestionAnswer = await _trackServiceTicketRepository.GetAllAsync<FeedbackQuestionAnswerDisplayEntity>(TrackServiceTicketQueries.GetQuestionAnswer, paraQA);
                List<FeedbackQuestionAnswerDisplayEntity> QuestionAnswerlist = new List<FeedbackQuestionAnswerDisplayEntity>();
                FeedbackQuestionAnswerDisplayEntity ObjQuestionAnswer = null;
                if (lstQuestionAnswer != null)
                {
                    foreach (var itemQA in lstQuestionAnswer)
                    {
                        ObjQuestionAnswer = new FeedbackQuestionAnswerDisplayEntity();
                        ObjQuestionAnswer.Question = itemQA.Question;
                        ObjQuestionAnswer.Answer = itemQA.Answer;

                        QuestionAnswerlist.Add(ObjQuestionAnswer);
                    }
                }
                ObjReport.QuestionAnswerList = QuestionAnswerlist;
                lstTrackServiceTicketReport.Add(ObjReport);

            }

            return lstTrackServiceTicketReport.ToList();
        }

    }
}
