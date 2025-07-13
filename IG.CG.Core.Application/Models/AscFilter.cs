namespace IG.CG.Core.Application.Models.Filters
{
    public class ASCFilter : BaseFilter
    {

        public string? AscName { get; set; } = string.Empty;
        public string? AscCode { get; set; } = string.Empty;

        public string? DivisionCode { get; set; } = string.Empty;
        public string? BranchCode { get; set; } = string.Empty;
        public string? RegionCode { get; set; } = string.Empty;
    }
}
