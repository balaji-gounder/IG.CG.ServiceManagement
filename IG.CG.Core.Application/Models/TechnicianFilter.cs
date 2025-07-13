

namespace IG.CG.Core.Application.Models
{
    public class TechnicianFilter : BaseFilter
    {
        public string? AscCode { get; set; } = string.Empty;
        public string? DivisionCode { get; set; } = string.Empty;
        public string? ProductLineCode { get; set; } = string.Empty;
        public string? TechnicianName { get; set; } = string.Empty;
       
    }
}
