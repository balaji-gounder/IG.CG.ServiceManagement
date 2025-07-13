

namespace IG.CG.Core.Domain.Entities
{
    public class ProductGroupEntity : BaseEntity
    {
        public int ProductGroupId { get; set; }
        public string? ProductLineCode { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductGroupCode { get; set; }
        public string? ProductGroupName { get; set; }
        public string? ProductGroupDesc { get; set; }
      
        public bool IsActive { get; set; }

    }
}
