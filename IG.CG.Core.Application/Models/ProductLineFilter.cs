namespace IG.CG.Core.Application.Models
{
    public class ProductLineFilter : BaseFilter
    {
        public string? ProductLineName { get; set; } = string.Empty;
        public string? DivisionCode { get; set; } = string.Empty;
    }
}
