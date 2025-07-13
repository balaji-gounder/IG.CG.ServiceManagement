
namespace IG.CG.Core.Domain.Entities
{
    public class SerialWiseServiceTicketInfoEntity : BaseEntity
    {
        public int? ServiceTicketId { get; set; }
        public string? SerialNo { get; set; }
        public string? ProductCode { get; set; }
        public string? DivisionCode { get; set; }
        public string? DivisionName { get; set; }
        public string? ProductGroupCode { get; set; }
        public string? ProductLineCode { get; set; }
        public string? ProductLineName { get; set; }
        public string? FRAME { get; set; }
        public string? KW { get; set; }
        public string? POLE { get; set; }
        public string? KVA { get; set; }
        public string? EFFE { get; set; }
        public string? FLPS { get; set; }

        public string? HP { get; set; }
        public string? WarrantyDateStatus { get; set; }
        public string? InvoiceDateStatus { get; set; }
        public string? CustomerName { get; set; }
        public string? PrimaryMobileNo { get; set; }
        public string? SiteAddress { get; set; }
        public string? ASCName { get; set; }
        public string? ASCMobileNo { get; set; }
        public string? ASMName { get; set; }
        public string? ASMMobileNo { get; set; }
        public string? DefectDesc { get; set; }
        public string? ServiceTicketNumber { get; set; }
        public string? TicketStateus { get; set; }
        public string? RequestDate { get; set; }
        public string? MsgCode { get; set; }
        public string? msg { get; set; }
        public string? BatchStartDate { get; set; }
        public string? BatchEndDate { get; set; }
        public string? ProductGroupName { get; set; }
        public string? BatchCode { get; set; }
        public string? ProductDescription { get; set; }
        public string? InvoiceNo { get; set; }
        public string? TicketGenerationDate { get; set; }
        public string? InvoiceDate { get; set; }

        public string? ASCAddress { get; set; }
        public string? TechnicianName { get; set; }
        public string? CustomerEmailId { get; set; }
        public string? CustomerContactDate { get; set; }
        public string? ClosureRemarks { get; set; }
        public string? NoOfHours { get; set; }
        public string? BranchAddress { get; set; }
        public string? PurchaseFrom { get; set; }
        public string? ReplacementTagApplied { get; set; }
        public string? NatureOfComplaint { get; set; }
        public string? AscState { get; set; }
        public string? DefectObserved { get; set; }
        public string? ManufacturingDate { get; set; }
        public string? DateOfDispatch { get; set; }
        public string? ASCEmailId { get; set; }
        public string? DateOfCommissioning { get; set; }
        public List<SpareDetailEntity> SpareDetails { get; set; }


        public string? HappyCode { get; set; }
        public string? ReplacementTag { get; set; }

    }

    public class SpareDetailEntity
    {
        public string? SpareCode { get; set; }
        public string? SpareDescription { get; set; }
        public string? SparePrice { get; set; }
        public string? Qty { get; set; }
        public string? SpareSerialNumber { get; set; }

    }
}
