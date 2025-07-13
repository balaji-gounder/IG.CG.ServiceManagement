

namespace IG.CG.Core.Domain.Entities
{
    public class RegionEntity : BaseEntity
    {
        public int RegionId { get; set; }
        public string? RegionCode { get; set; }
        public string? RegionName { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
    }
}
