namespace IG.CG.Core.Application.Models
{
    public class LeadActivityModel
    {
        public int ActivityId { get; set; }
        public string? ActivityName { get; set; }
        public bool IsOrderNo { get; set; }
        public bool IsNextFollowupDate { get; set; }
        public bool IsRemarks { get; set; }
        public bool IsDocument { get; set; }
        public bool IsReasons { get; set; }
        public bool IsActualQuote { get; set; }
        public bool IsRevisedQuote { get; set; }
    }
}
