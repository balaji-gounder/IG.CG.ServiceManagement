
namespace IG.CG.Core.Application.Models.Filters
{
    public class SpareFilter : BaseFilter
    {
        public string? DivisionCode { get; set; } = string.Empty;
        public string? ProductLineCode { get; set; } = string.Empty;
        public string? ProductCode { get; set; } = string.Empty;
        public string? ProductGroupCode { get; set; } = string.Empty;
    }
}
