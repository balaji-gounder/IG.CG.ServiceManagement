using Microsoft.AspNetCore.Http;

namespace IG.CG.Core.Domain.Entities
{
    public class ProductCustomerInfoEntity : BaseEntity
    {
        public int? ProdRegAutoId { get; set; }
        public int? CustVerificationId { get; set; }
        public string? CustomerName { get; set; }
        public string? ContactPerson { get; set; }
        public string? PrimaryMobileNo { get; set; }
        public string? EmailId { get; set; }
        public string? CustAddess { get; set; }
        public string? AltContactNo { get; set; }
        public string? AltEmailId { get; set; }
        public string? SiteAddress { get; set; }
        public int? PinId { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public string? NameOfSpoc { get; set; }
        public string? SpocMobileNo { get; set; }
        public string? SpocEmailId { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public int? ProdInstallationPinId { get; set; }
        public int? ProdInstallationCityId { get; set; }
        public int? ProdInstallationStateId { get; set; }

        public string? SerialNo { get; set; }
        public string? DivCode { get; set; }
        public string? ProductCode { get; set; }
        public string? PurchaseFrom { get; set; }
        public string? InvoiceNo { get; set; }


        public string? BatchStartDate { get; set; }
        public string? BatchEndDate { get; set; }
        public string? InvoiceDate { get; set; }

        public string? WarrantyDate { get; set; }

        public List<IFormFile>? InvoceFilePath { get; set; }
        public bool? InWarranty { get; set; }
        public string? ProductType { get; set; }
        public string? FrameSize { get; set; }
        public string? Voltage { get; set; }
        public string? Pole { get; set; }

        public string? Kva { get; set; }
        public string? SAPWarrantyDate { get; set; }
        public string? HP { get; set; }
        public string? Efficiency { get; set; }
        public string? Flp { get; set; }
        public bool? IsDeviation { get; set; }
        public bool? IsActive { get; set; }

        public string? DefectId { get; set; }
        public string? Remarks { get; set; }
        public string? RedirectingFrom { get; set; }


        public string? NearestPinCode { get; set; }

        public string? NearestAscUserCode { get; set; }
        public string? NearestAsmUserCode { get; set; }
        public string? Distance { get; set; }
        public string? UserCode { get; set; }

        public string? TicketCreateName { get; set; }
        public string? TicketCreateNumber { get; set; }
        public string? UserType { get; set; }
        public string? DealerCode { get; set; }
        public string? RetailerCode { get; set; }
        public int? CallModeId { get; set; }
        public string? IsPriority { get; set; }
        public int? SourceId { get; set; }

        public string? ProductGroup { get; set; }
        public string? ComplaintType { get; set; }
        public string? RequestType { get; set; }
        public string? OEMCode { get; set; }
        public string? ServiceRequestTypeName { get; set; }
        public string? productLineName { get; set; }
        public string? Isreceived { get; set; }

        public string? ManufacturingDate { get; set; }
        public string? DateOfDispatch { get; set; }
        public string? SourceTypeId { get; set; }
        public string? ProductLineCode { get; set; }
        public string? FinalRemarks { get; set; }

        public int? noOfProducts { get; set; }


    }


    public class ProductCustomerAMSInfoEntity
    {
        public int? ServiceTicketId { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailId { get; set; }
        public string? Address { get; set; }
        public string? PinCode { get; set; }
        public string? CityId { get; set; }
        public string? StateId { get; set; }
        public string? SerialNo { get; set; }
        public string? DivCode { get; set; }
        public string? ProductlineCode { get; set; }
        public string? ProductCode { get; set; }
        public string? InvoiceNo { get; set; }
        public string? InvoiceDate { get; set; }
        public string? Frame { get; set; }

        public string? HP { get; set; }
        public string? Kva { get; set; }
        public string? RandomNo { get; set; }
        public string? UserType { get; set; }
        public string? typeOfCustomerId { get; set; }
        public string? CallTypeId { get; set; }
        public string? DefectId { get; set; }
        public string? DealerCode { get; set; }
        public string? NearestPinCode { get; set; }
        public string? NearestAscUserCode { get; set; }
        public string? Distance { get; set; }
    }

    public class ProductUpdateActivityEntity
    {
        public int? ServiceTicketId { get; set; }
        public string? SerialNo { get; set; }
        public string? DivCode { get; set; }
        public string? ProductlineCode { get; set; }
        public string? ProductCode { get; set; }
        public string? InvoiceNo { get; set; }
        public string? InvoiceDate { get; set; }
        public string? Frame { get; set; }
        public string? HP { get; set; }
        public string? Kva { get; set; }
        public string? CallTypeId { get; set; }
        public string? DefectId { get; set; }

        public string? UserType { get; set; }
        public string? DealerCode { get; set; }
        public List<IFormFile>? InvoiceFile { get; set; }
        public List<IFormFile>? FIRcopy { get; set; }
    }



}
