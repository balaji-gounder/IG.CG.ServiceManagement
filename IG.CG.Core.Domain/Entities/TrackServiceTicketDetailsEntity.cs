using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Domain.Entities
{
    public class TrackServiceTicketDetailsEntity
    {
        public string? SerialNo { get; set; }
        public string? ServiceTicketNumber { get; set; }
        public string? RequestDate { get; set; }
        public string? IssueType { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CityName { get; set; }
        public string? ProductType { get; set; }
        public string? WarrantyStatus { get; set; }
        public string? TicketStatus { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerMobile { get; set; }
        public string? ASCName { get; set; }
        public string? ASCMobileNo { get; set; }
        public string? ASMName { get; set; }
        public string? ASMMobileNo { get; set; }
        public string? ProductLineName { get; set; }
        public string? FRAME { get; set; }
        public string? Voltage { get; set; }
        public string? Pole { get; set; }
        public string? DateCreated { get; set; }
        public string? AscAddress { get; set; }
        public string? AscCityName { get; set; }
        public string? AscEmailId { get; set; }

    }
    public class FeedbackQuestionsEntity
    {
        public int QuestionId { get; set; }
        public string? Question { get; set; }

    }

    public class FeedbackRatingEntity
    {
        public string? ServiceTicketNo { get; set; }
        public int Rating { get; set; }
        public string? Feedback { get; set; }
        public string? UserIPAddress { get; set; }
        public List<FeedbackQuestionAnswerEntity> QuestionAnswerList { get; set; }

    }

    public class FeedbackRatingDisplayEntity
    {
        public int RatingId { get; set; }
        public string? ServiceTicketNo { get; set; }
        public int Rating { get; set; }
        public string? Feedback { get; set; }
        public string? CreatedOn { get; set; }
        public string? UserIPAddress { get; set; }
        public List<FeedbackQuestionAnswerDisplayEntity> QuestionAnswerList { get; set; }

    }
    public class FeedbackQuestionAnswerEntity
    {
        public int QuestionId { get; set; }
        public string? Answer { get; set; }

    }

    public class FeedbackQuestionAnswerDisplayEntity
    {
        public string? Question { get; set; }
        public string? Answer { get; set; }

    }

    public class TrackServiceTicketReportEntity : BaseEntity
    {
        public int RatingId {  get; set; }
        public string? ServiceTicketNo { get; set; }
        public string? CustomerName { get; set; }
        public string? ProductName { get; set; }
        public int Rating { get; set; }
        public string? Feedback { get; set; }
        public string? CreatedOn { get; set; }
        public string? UserIPAddress { get; set; }
        public List<FeedbackQuestionAnswerDisplayEntity> QuestionAnswerList { get; set; }

    }

}
