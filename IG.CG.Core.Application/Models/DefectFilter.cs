namespace IG.CG.Core.Application.Models
{
    public class DefectFilter : BaseFilter
    {
        public string? DivisionCode { get; set; } = string.Empty;
        public string? ProductLineCode { get; set; } = string.Empty;
        public string? ProductGroupCode { get; set; } = string.Empty;

        public int DefectCategoryId { get; set; } = 0;


    }
}
