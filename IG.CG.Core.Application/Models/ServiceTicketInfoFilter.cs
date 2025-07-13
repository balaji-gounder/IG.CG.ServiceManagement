
namespace IG.CG.Core.Application.Models
{
    public class ServiceTicketInfoFilter : BaseFilter
    {
        public string? ServiceTicketNumber { get; set; } = string.Empty;
        public string? SerialNo { get; set; } = string.Empty;
        public string? DivsionCode { get; set; } = string.Empty;
        public string? ProductCode { get; set; } = string.Empty;
        public string? CustomerName { get; set; } = string.Empty;

    }
}
