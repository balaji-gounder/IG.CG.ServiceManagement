namespace IG.CG.Core.Domain.Entities
{
    public class ServiceTicketASCCodeEntity : BaseEntity
    {
        public int? ServiceTicketId { get; set; }
        public string? TicketAssignedASCCode { get; set; }
        public string? Remark { get; set; }
    }

    public class ServiceTicketASMCodeEntity 
    {
        public int? ServiceTicketId { get; set; }
        public string? TicketAssignedASMCode { get; set; }
        public string? Remark { get; set; }
    }

    public class ServiceTicketCancelEntity
    {
        public int? ServiceTicketId { get; set; }
        public string? Remark { get; set; }
    }


}
