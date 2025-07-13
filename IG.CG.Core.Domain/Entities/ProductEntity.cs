namespace IG.CG.Core.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public int ProductId { get; set; }
        public string? ProductCode { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }
        public string? ProductGroupCode { get; set; }
        public string? ProductDescription { get; set; }
        public int ServiceGroupId { get; set; }
        public int WarrantyFromBatch { get; set; }
        public int WarrantyFromDOI { get; set; }
        public string? HP { get; set; }
        public string? RewindingGroup { get; set; }
        public string? FrameSize { get; set; }
        public bool IsActive { get; set; }
        public string? VendorId { get; set; }
        public string? Kilowatt { get; set; }
        public string? AscDays { get; set; }
        public string? DeviationUpto { get; set; }

        public string? DeviationMonth { get; set; }
    }
}
