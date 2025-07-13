namespace IG.CG.Core.Application.Models
{
    public class ServiceTicketASCCodeModel
    {
        public int? ServiceTicketId { get; set; }
        public string? TicketAssignedASCCode { get; set; }
        public string? Remark { get; set; }
    }
    public class ServiceTicketASMCodeModel
    {
        public int? ServiceTicketId { get; set; }
        public string? TicketAssignedASMCode { get; set; }
        public string? Remark { get; set; }
    }


    public class ServiceTicketCancelModel
    {
        public int? ServiceTicketId { get; set; }
        public string? Remark { get; set; }
    }
}
