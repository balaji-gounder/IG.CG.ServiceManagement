

namespace IG.CG.Core.Domain.Entities
{
    public class DefectCategoryEntity :BaseEntity
    {
        public int DefectCategoryId { get; set; }
        public string? DefectCategoryName { get; set; }
        public bool IsActive { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }
        public string? ProductGroupCode { get; set; }
    }
}
