

namespace IG.CG.Core.Application.Models
{
    public class BranchFilter : BaseFilter
    {
        public string? RegionCode { get; set; } = string.Empty;
        public int StateId { get; set; } = 0;
        public int CityId { get; set; } = 0;
        public string? BranchName { get; set; } = string.Empty;
    }
}
