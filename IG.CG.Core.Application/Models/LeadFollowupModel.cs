using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class LeadFollowupModel
    {
        public int FollowupId { get; set; }
        public int LeadId { get; set; }
        [Required(ErrorMessage = "Visit Date is Required")]
        public string? VisitDate { get; set; }

        public string? DateOfFollowup { get; set; }

        public decimal ActualQuote { get; set; }
        public decimal TotalBudget { get; set; }
        public decimal ReviseQuoteAmount { get; set; }
        [Required(ErrorMessage = "Followup Mode Code is Required")]
        public int FollowupModeId { get; set; }
        [Required(ErrorMessage = "Conversation Details is Required")]
        public string? ConversationDetails { get; set; }
        public List<IFormFile>? UploadDocuments { get; set; }
        public int? DocumentTypeId { get; set; }
        public string? NextFollowupDate { get; set; }
        [Required(ErrorMessage = "Status  is Required")]
        public int StatusId { get; set; }

        public string? Remarks { get; set; }

        public string? OrderNo { get; set; }

        public int? ReasonsOfLeasLostId { get; set; }
        public string? ActivityId { get; set; }
    }
}
