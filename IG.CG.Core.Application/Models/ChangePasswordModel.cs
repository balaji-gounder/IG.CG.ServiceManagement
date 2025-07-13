namespace IG.CG.Core.Application.Models
{
    public class ChangePasswordModel
    {
        public string? UserId { get; set; }
        public string? UserPassword { get; set; }
        public string? OldPassword { get; set; }

        //public string? Message { get; set; }
        //public string? status { get; set; }
    }

    public class TicketListModel
    {
        public string? UserId { get; set; }
        public string? IPAddress { get; set; }

    }
}
