namespace IG.CG.Core.Domain.Entities
{
    public class LeadContactEntity
    {
        public string? ContactPersonName { get; set; }
        public string? Designation { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailId { get; set; }
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public int IsPrimaryContact { get; set; }
    }
}
