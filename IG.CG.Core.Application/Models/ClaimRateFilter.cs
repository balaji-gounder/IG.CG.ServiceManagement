namespace IG.CG.Core.Application.Models
{
    public class ClaimRateFilter : BaseFilter
    {
        public string? ProductDivCode { get; set; } = string.Empty;
        public string? ProductLineCode { get; set; } = string.Empty;
        public int? TypeOfActivityId { get; set; } = null;
    }
}
