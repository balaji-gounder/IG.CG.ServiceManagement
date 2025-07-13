

namespace IG.CG.Core.Application.Models
{
    public class UserFilter : BaseFilter
    {
        public string? RoleCode { get; set; } = string.Empty;
        public string? UserName { get; set; } = string.Empty;
        public string? UserTypeCode { get; set; } = string.Empty;
        public string? RegionCode { get; set; } = string.Empty;
    }
}
