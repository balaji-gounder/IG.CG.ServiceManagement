
namespace IG.CG.Core.Application.Models.Filters
{
    public class ASMServiceRequestClaimFilter : BaseFilter
    {
        public string? AscCode { get; set; } = string.Empty;
        public string? ServiceTicketType { get; set; } = string.Empty;
        public string? DivisionCode { get; set; } = string.Empty;
        public string? RegionCode { get; set; } = string.Empty;
        public string? BranchCode { get; set; } = string.Empty;

        public string? ProductlineCode { get; set; } = string.Empty;
        public int? Month { get; set; } = 0;
        public string? ServiceTicketNo { get; set; } = string.Empty;
    }

    public class AscIBNGeneratedListFilter : BaseFilter
    {
        public string? AscCode { get; set; } = string.Empty;
        public string? DivisionCode { get; set; } = string.Empty;
        public int? Month { get; set; } = 0;
        public int? Year { get; set; } = 0;
        public string? IBNNumber { get; set; } = string.Empty;
    }

    public class ClaimLineItemsViewFilter : BaseFilter
    {
        public int? ASMIsApproved { get; set; } = -1;
        public int? RSMIsApproved { get; set; } = -1;
        public int? IsAcceptRejection { get; set; } = -1;
        public int? IsASMUnApproved { get; set; } = -1;
        public int? IsRSMUnApproved { get; set; } = -1;
        public string? ServiceTicketNo { get; set; } = string.Empty;
        public string? Region { get; set; } = string.Empty;
        public string? Branch { get; set; } = string.Empty;
        public string? AscCode { get; set; } = string.Empty;
        public string? DivCode { get; set; } = string.Empty;
        public string? ProductLineCode { get; set; } = string.Empty;
        public string? FromDate { get; set; } = string.Empty;
        public string? ToDate { get; set; } = string.Empty;
    }
}
