namespace IG.CG.Core.Domain.Entities
{
    public class ProductDealerEntity
    {
        public string? SerialNo { get; set; }
        public string? DivCode { get; set; }
        public string? ProductCode { get; set; }

        public string? ProductLineCode { get; set; }
        public string? ProductType { get; set; }
        public string? FrameSize { get; set; }
        public string? Voltage { get; set; }
        public string? Pole { get; set; }
        public string? Kva { get; set; }
        public string? SAPWarrantyDate { get; set; }
        public string? HP { get; set; }
        public string? Efficiency { get; set; }
        public string? Flp { get; set; }

        public string? DefectId { get; set; }
        public string? Remarks { get; set; }

        public string? PurchaseFrom { get; set; }

        public string? InvoiceNo { get; set; }
        public string? BatchStartDate { get; set; }
        public string? BatchEndDate { get; set; }
        public string? InvoiceDate { get; set; }
        public string? WarrantyDate { get; set; }

        // public List<IFormFile>? InvoceFilePath { get; set; }
        public bool InWarranty { get; set; }
        public bool IsDeviation { get; set; }
        public string? NameOfSpoc { get; set; }
        public string? SpocMobileNo { get; set; }
        public string? SpocEmailId { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public int? ProdInstallationPinId { get; set; }
        public int? ProdInstallationCityId { get; set; }
        public int? ProdInstallationStateId { get; set; }

        public string? NearestPinCode { get; set; }
        public string? NearestAscUserCode { get; set; }
        public string? NearestAsmUserCode { get; set; }

        public string? ProductGroup { get; set; }
        public string? ComplaintType { get; set; }
        public string? RequestType { get; set; }
        public string? Distance { get; set; }
        public string? ManufacturingDate { get; set; }
        public string? DateOfDispatch { get; set; }
        public string? ParentId { get; set; }
        public string? TotalMultipleTicket { get; set; }

        public string? SourceTypeId { get; set; }
    }
}
