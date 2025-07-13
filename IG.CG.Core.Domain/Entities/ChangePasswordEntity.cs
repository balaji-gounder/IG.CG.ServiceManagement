namespace IG.CG.Core.Domain.Entities
{
    public class ChangePasswordEntity
    {
        public string? UserId { get; set; }
        public string? UserPassword { get; set; }
        public string? OldPassword { get; set; }
        //public string? Message { get; set; }
        //public string? status { get; set; }
    }
}
