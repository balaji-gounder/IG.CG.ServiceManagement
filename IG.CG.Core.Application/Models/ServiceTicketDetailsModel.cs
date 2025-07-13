namespace IG.CG.Core.Application.Models
{
    public class ServiceTicketDetailsModel
    {
        public int? ServiceTicketId { get; set; }

        public string? SERNR { get; set; }
        public string? MATNR { get; set; }
        public string? DivisionCode { get; set; }
        public string? DivisionName { get; set; }
        public string? ProductGroupCode { get; set; }
        public string? ProductLineCode { get; set; }
        public string? ProductLineName { get; set; }
        public string? productCode { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductGroupName { get; set; }
        public string? WarrantyDate { get; set; }
        public string? InvoiceDate { get; set; }
        public string? InvoiceNo { get; set; }
        public string? FRAME { get; set; }
        public string? KW { get; set; }
        public string? POLE { get; set; }
        public string? KVA { get; set; }
        public string? EFFE { get; set; }
        public string? FLPS { get; set; }
        public string? HP { get; set; }
        public string? WarrantyDateStatus { get; set; }
        public string? InvoiceDateStatus { get; set; }
        public string? ServiceRequestType { get; set; }
        public string? CustomerName { get; set; }
        public string? PrimaryMobileNo { get; set; }
        public string? EmailId { get; set; }
        public string? SiteAddress { get; set; }
        public string? ASCName { get; set; }
        public string? ASCMobileNo { get; set; }
        public string? ASMName { get; set; }
        public string? ASMEmail { get; set; }
        public string? ASMMobileNo { get; set; }
        public string? DefectDesc { get; set; }
        public string? ServiceTicketNumber { get; set; }
        public string? TicketStateus { get; set; }
        public string? RequestDate { get; set; }
        public string? InvoceFilePath { get; set; }
        public string? TabActive { get; set; }
        public string? ServiceRequestTypeName { get; set; }
        public string? BatchStartDate { get; set; }

        public string? BatchEndDate { get; set; }
        public string? BatchCode { get; set; }

        public string? Address { get; set; }
        public string? CityId { get; set; }
        public string? StateId { get; set; }
        public string? PinCode { get; set; }
        public string? RandomNo { get; set; }

        public string? SpocEmailId { get; set; }
        public string? SpocMobileNo { get; set; }

        public string? ManufacturingDate { get; set; }
        public string? DateOfDispatch { get; set; }
        public string? Distance { get; set; }

        public string? CallTypeId { get; set; }

        public string? callType { get; set; }

        public string? typeOfCustomer { get; set; }

        public string? typeOfCustomerId { get; set; }
        public string? UserType { get; set; }
        public string? DealerCode { get; set; }
        public string? DefectId { get; set; }
        public string? IsAscMultipleTicket { get; set; }

        public string? IsMultipleTicketCreate { get; set; }
        public string? IsFIRCreate { get; set; }

        public string? IsActivitySiteVisit { get; set; }
        public string? IsProductChange { get; set; }

        public string? HappyCode { get; set; }

        public string? TotalTicket { get; set; }

        public string? ReplacementTag { get; set; }

        public string? IsProductReceivedASC { get; set; }
    }

    public class ReplacementTagModel
    {
        public string? ReplacementTag { get; set; }
    }
}
