namespace IG.CG.Core.Application.Models
{
    public class ProductFilter : BaseFilter
    {
        public string? DivisionCode { get; set; } = string.Empty;
        public string? ProductLineCode { get; set; } = string.Empty;
        public string? ProductGroupCode { get; set; } = string.Empty;
        public int ServiceGroupId { get; set; } = 0;
        public string? ProductDescription { get; set; } = string.Empty;
        public string? ProductCode { get; set; } = string.Empty;

    }
}
