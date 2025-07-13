
namespace IG.CG.Core.Application.Models.Filters
{
    public class ActivityFilter : BaseFilter
    {
        public string? DivisionCode { get; set; } = string.Empty;
        public string? ProductLineCode { get; set; } = string.Empty;

        public int? ActivityTypeId { get; set; } = 0;
    }
}
