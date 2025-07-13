namespace IG.CG.Core.Domain.Entities
{
    public class VendorEntity : BaseEntity
    {
        public int VendorId { get; set; }
        public string? VendorCode { get; set; }
        public string? SAPVendorCode { get; set; }
        public string? VendorName { get; set; }
        public string? InitialBatch { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailId { get; set; }
        public string? PanNo { get; set; }
        public bool IsGstApplicable { get; set; }
        public string? GstNo { get; set; }
        public bool IsMSME { get; set; }
        public string? MsmeCode { get; set; }
        public string? VendorAddress { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public int? PinId { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }

        public string? ProductGroupCode { get; set; }

        public bool IsActive { get; set; }
    }
}
