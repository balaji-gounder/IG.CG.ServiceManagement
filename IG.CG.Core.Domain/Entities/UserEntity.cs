

namespace IG.CG.Core.Domain.Entities
{
    public class UserEntity
    {
        public int UserAutoId { get; set; }
        public string? UserId { get; set; }
        public string? UserPassword { get; set; }
        public string? UserTypeCode { get; set; }
        public string? UserEmailId { get; set; }
        public string? MobileNo { get; set; }
        public string? UserName { get; set; }
        public string? RoleCode { get; set; }
        public int MappingId { get; set; }
        public string? CreatedBy { get; set; }
        public string? BranchCode { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }
        public bool IsActive { get; set; }
        public string? TotalRows { get; set; }
    }
}
