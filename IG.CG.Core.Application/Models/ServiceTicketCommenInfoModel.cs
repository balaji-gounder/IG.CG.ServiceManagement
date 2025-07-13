namespace IG.CG.Core.Application.Models
{
    public class ServiceTicketCommenInfoModel
    {
        public int ServiceTicketId { get; set; }
        public int? IsSendMailCustomer { get; set; }
        public string? Comment { get; set; }
        public string? UserId { get; set; }

    }


    public class ServiceTicketCommenInfoListModel
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
