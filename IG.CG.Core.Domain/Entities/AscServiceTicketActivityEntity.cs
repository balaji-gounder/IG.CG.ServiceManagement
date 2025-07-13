namespace IG.CG.Core.Domain.Entities
{
    public class AscServiceTicketActivityEntity
    {
        public int AscActivitiesId { get; set; }
        public int? ServiceTicketId { get; set; }
        public string? ComplainType { get; set; }
        public string? Date { get; set; }
        public string? TypeOfActivity { get; set; }
        public int? ActiveStatusId { get; set; }
        public int? ActiveSubStatusId { get; set; }

        public string? Remarks { get; set; }
    }
}
