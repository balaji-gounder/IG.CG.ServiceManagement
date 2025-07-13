namespace IG.CG.Core.Application.Models
{
    public class DefectCategoryFilter : BaseFilter
    {
        public string? DivisionCode { get; set; } = string.Empty;
        public string? ProductLineCode { get; set; } = string.Empty;
        public string? ProductGroupCode { get; set; } = string.Empty;
        public string? DefectCategoryName { get; set; } = string.Empty;
    }
}
