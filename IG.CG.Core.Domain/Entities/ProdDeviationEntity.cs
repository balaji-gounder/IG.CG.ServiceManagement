namespace IG.CG.Core.Domain.Entities
{
    public class ProdDeviationEntity : BaseEntity
    {
        public int ProdDevAutoId { get; set; }
        public int TicketAutoId { get; set; }
        public string? BatchDate { get; set; }
        public string? BatchEndDate { get; set; }
        public string? InvoiceDate { get; set; }
        public string? WarrantyDate { get; set; }
        public string? ProdDeviationDate { get; set; }
        public string? Remarks { get; set; }

    }
}
