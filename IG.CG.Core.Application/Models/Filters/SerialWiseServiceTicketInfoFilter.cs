
namespace IG.CG.Core.Application.Models.Filters
{
    public class SerialWiseServiceTicketInfoFilter
    {
        public string? SerialNo { get; set; } = string.Empty;
        public string? ProductCode { get; set; } = string.Empty;
        public string? InvoiceDate { get; set; }
        public string? DivisionCode { get; set; }
    }
}
