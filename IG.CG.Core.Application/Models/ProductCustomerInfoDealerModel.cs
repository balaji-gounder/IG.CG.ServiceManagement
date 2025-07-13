namespace IG.CG.Core.Application.Models
{
    public class ProductCustomerInfoDealerModel
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
        public bool IsActive { get; set; }
        public string? RedirectingFrom { get; set; }

        public string? UserCode { get; set; }
        public string? TicketCreateName { get; set; }
        public string? TicketCreateNumber { get; set; }
        public string? UserType { get; set; }
        public string? DealerCode { get; set; }
        public string? RetailerCode { get; set; }
        public string? OEMCode { get; set; }

        public string? Distance { get; set; }
        public string? ManufacturingDate { get; set; }
        public string? DateOfDispatch { get; set; }
    }

    public class AddAscTicketCreateModel
    {
        public int? serviceTicketId { get; set; }
        public string? serialNo { get; set; }
        public string? productCode { get; set; }
        public string? divisionCode { get; set; }
        public string? productLineCode { get; set; }
        public string? pInvoiceNo { get; set; }
        public string? pInvoiceDate { get; set; }
        public string? ServiceTicketNumber { get; set; }
        public string? TotalMultipleTicket { get; set; }



    }



}
