namespace IG.CG.Core.Domain.Entities
{
    public class RoleEntity : BaseEntity
    {
        public int RoleId { get; set; }

        public string? RoleCode { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDesc { get; set; }
        public int ReportingTo { get; set; }
        public bool IsActive { get; set; }
        public int RightTypeId { get; set; }
        public string? UserTypeId { get; set; }
        public bool IsMultipleBranch { get; set; }
        public bool IsDeviation { get; set; }
        public bool IsMultipleDivision { get; set; }
        public string? UserTypeName { get; set; }
    }
}
