
namespace IG.CG.Core.Application.Models.Filters
{
    public class ASCServiceRequestFilter : BaseFilter
    {

        public string? DivisionCode { get; set; } = string.Empty;
        public string? ProductLineCode { get; set; } = string.Empty;
        public string? WarrantyStatus { get; set; } = string.Empty;
        public string? IssueStatus { get; set; } = string.Empty;
        public string? TicketStatus { get; set; } = string.Empty;
        public string? ServiceTicketNo { get; set; } = string.Empty;
        public string? FromDate { get; set; } = string.Empty;
        public string? ToDate { get; set; } = string.Empty;
        public string? ASCA { get; set; } = string.Empty;
        public string? SerialNo { get; set; } = string.Empty;
        public string? PrimaryMobileNo { get; set; } = string.Empty;

    }


    public class CallCenterRequestOpenTicketFilter : BaseFilter
    {

        public string? DivisionCode { get; set; } = string.Empty;
        public string? ProductLineCode { get; set; } = string.Empty;
        public string? WarrantyStatus { get; set; } = string.Empty;
        public string? IssueStatus { get; set; } = string.Empty; 
        public string? PrimaryMobileNo { get; set; } = string.Empty;
        public string? ServiceTicketNo { get; set; } = string.Empty;
        public string? FromDate { get; set; } = string.Empty;
        public string? ToDate { get; set; } = string.Empty;


    }



    public class ASCServiceRequestViewAllFilter : BaseFilter
    {

        public string? DivisionCode { get; set; } = string.Empty;
        public string? ProductLineCode { get; set; } = string.Empty;
        public string? WarrantyStatus { get; set; } = string.Empty;
        public string? IssueStatus { get; set; } = string.Empty;
        public string? FromDate { get; set; } = string.Empty;
        public string? ToDate { get; set; } = string.Empty;
        public string? PhoneOrServiceTicketNo { get; set; } = string.Empty;
    }
}
