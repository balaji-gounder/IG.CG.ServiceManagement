namespace IG.CG.Core.Domain.Entities
{
    public class ServiceTicketCommenInfoEntitys
    {
        public int ServiceTicketId { get; set; }
        public int? IsSendMailCustomer { get; set; }
        public string? Comment { get; set; }
        public string? UserId { get; set; }

    }


    public class ServiceTicketCommenInfoListEntitys
    {
        public int ServiceTicketId { get; set; }
        public int? IsSendMailCustomer { get; set; }
        public string? Comment { get; set; }
        public string? StatusName { get; set; }
        public string? RoleName { get; set; }
        public string? UserName { get; set; }
        public string? CreatedOn { get; set; }
    }
}
