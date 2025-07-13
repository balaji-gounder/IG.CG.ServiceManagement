namespace IG.CG.Core.Domain.Entities
{
    public class LeadFollowupEntity : BaseEntity
    {
        public int FollowupId { get; set; }
        public int LeadId { get; set; }
        public string? VisitDate { get; set; }
        public string? DateOfFollowup { get; set; }
        public decimal ActualQuote { get; set; }

        public decimal TotalBudget { get; set; }

        public decimal ReviseQuoteAmount { get; set; }
        public int FollowupModeId { get; set; }
        public string? ConversationDetails { get; set; }
        public string? UploadDocuments { get; set; }
        public int DocumentTypeId { get; set; }
        public string? NextFollowupDate { get; set; }
        public int StatusId { get; set; }
        public string? Remarks { get; set; }
        public string? OrderNo { get; set; }
        public int? ReasonsOfLeasLostId { get; set; }
        public string? ActivityId { get; set; }


    }
}
