

namespace IG.CG.Core.Domain.Entities
{
    public class TechnicianEntity : BaseEntity
    {
        public int TechnicianId { get; set; }
        public string? TechnicianName { get; set; }
        public string? AscCode { get; set; }
        public string? Mobile { get; set; }
        public string? TechnicianEmail { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }
        public string? ProductGroupCode { get; set; }
        public string? PhoneNo { get; set; }
        public string? SkillId { get; set; }
        public bool IsActive { get; set; }

    }
}
