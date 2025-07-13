namespace IG.CG.Core.Domain.Entities
{
    public class CustomerAssestsEntity : BaseEntity
    {
        public int CustWiseAssetId { get; set; }
        public int CustAutoId { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }
        public string? ProductGroupCode { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductSerialNo { get; set; }
        public string? Batch { get; set; }
        public DateTime WarrantyStartDateBatch { get; set; }
        public DateTime WarrantyEndDateBatch { get; set; }
        public string? InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime WarrantyStartDateInvoice { get; set; }
        public DateTime WarrantyEndDateInvoice { get; set; }
        public bool WarrantyStatus { get; set; }
        public int InformationSource { get; set; }

        public string? DealerInvoiceNo { get; set; }
        public DateTime DealerInvoiceDate { get; set; }

        public bool IsActive { get; set; }
    }
}
