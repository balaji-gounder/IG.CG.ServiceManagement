namespace IG.CG.Core.Domain.Entities
{
    public class DefectEntity : BaseEntity
    {
        public int DefectId { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }
        public string? ProductGroupCode { get; set; }
        public string? ProductCode { get; set; }

        public int? DefectCategoryId { get; set; }
        public string? DefectDesc { get; set; }
        public bool IsActive { get; set; }
    }
}
