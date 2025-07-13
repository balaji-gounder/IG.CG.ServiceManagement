
namespace IG.CG.Core.Application.Models
{
    public class ServiceTicketInfoDisplayModel
    {
        public int ServiceTicketId { get; set; }
        public string? DefectDesc { get; set; }
        public int TicketStatusId { get; set; }
        public string? RequestDate { get; set; }
        public string? TicketAssignedASCCode { get; set; }
        public string? TicketAssignedASMCode { get; set; }
        public string? ServiceTicketNumber { get; set; }
        public string? AscName { get; set; }
        public string? ASCMobileNo { get; set; }
        public string? ASMName { get; set; }
        public string? ASMMobileNo { get; set; }
        public string? SerialNo { get; set; }
        public string? DivCode { get; set; }
        public string? DivisionName { get; set; }
        public string? ProductCode { get; set; }
        public string? InvoiceDate { get; set; }
        public string? InvoiceNo { get; set; }
        public bool? InWarranty { get; set; }
        public bool? IsDeviation { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerMobile { get; set; }
        public string? CustomerEmail { get; set; }
        public string? SiteAddress { get; set; }
        public string? CustomerPinCode { get; set; }
        public string? CustomerCity { get; set; }
        public string? CustomerState { get; set; }
        public string? TotalRows { get; set; } 

    }
}
