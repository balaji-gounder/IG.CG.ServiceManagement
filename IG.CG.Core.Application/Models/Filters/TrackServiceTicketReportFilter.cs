
namespace IG.CG.Core.Application.Models.Filters
{
    public class TrackServiceTicketReportFilter : BaseFilter
    {
        public string? ServiceTicketNo { get; set; } = string.Empty;
        public string? ProductCode { get; set; } = string.Empty;
        public int Rating { get; set; } = 0;
        public string? CustomerName {  get; set; } = string.Empty;
    }
}
