namespace IG.CG.Core.Application.Models.Filters
{
    public class ReportFilter : BaseFilter
    {
        public string? UserId { get; set; } = string.Empty;
        public string? Region { get; set; } = string.Empty;
        public string? Branch { get; set; } = string.Empty;
        public string? ASC { get; set; } = string.Empty;
        public string? BusinessLine { get; set; } = string.Empty;
        public string? ProductLine { get; set; } = string.Empty;
        public string? DivisionCode { get; set; } = string.Empty;

        public string? CallStage { get; set; } = string.Empty;
        public string? DateType { get; set; } = string.Empty;

        public string? FromDate { get; set; } = string.Empty;
        public string? ToDate { get; set; } = string.Empty;

    }

    public class DurationTicketFilter
    {
        public string? DivCode { get; set; } = string.Empty;
        public string? ProductLineCode { get; set; } = string.Empty;
        public string? UserId { get; set; } = string.Empty;
        public string? FromDate { get; set; } = string.Empty;
        public string? ToDate { get; set; } = string.Empty;

    }
}
