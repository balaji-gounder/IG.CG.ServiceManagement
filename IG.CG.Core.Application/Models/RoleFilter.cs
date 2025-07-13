namespace IG.CG.Core.Application.Models
{
    public class RoleFilter : BaseFilter
    {
        public int ReportingTo { get; set; } = 0;
        public string? RoleName { get; set; } = string.Empty;
        public int RightTypeId { get; set; } = 0;

    }
}

