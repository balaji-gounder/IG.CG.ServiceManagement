namespace IG.CG.Core.Domain.Entities
{
    public class ProdCustInfoDisplayEnitity
    {
        public int ProdRegAutoId { get; set; }

        public int TicketAutoId { get; set; }

        public string? CustomerName { get; set; }

        public string? ContactPerson { get; set; }
        public string? ProductCode { get; set; }
        public string? PrimaryMobileNo { get; set; }
        public string? AltEmailId { get; set; }
        public string? EmailId { get; set; }
        public string? SiteAddress { get; set; }
        public string? CityName { get; set; }
        public string? PinCode { get; set; }

        public string? StateName { get; set; }

        public string? SerialNo { get; set; }
        public string? DivCode { get; set; }
        public string? InvoiceNo { get; set; }

        public string? InvoiceDate { get; set; }
        public string? DivisionName { get; set; }

        public int? PinId { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public string? Msg { get; set; }
        public string? MsgCode { get; set; }
        public string? WarrantyStatus { get; set; }
        public string? IsGeneratedTicket { get; set; }
        public string? ServiceTicketId { get; set; }


    }
}
