namespace IG.CG.Core.Application.Models
{
    public class UserAdditionalRightsModel
    {
        public int UAddAutoId { get; set; }
        public string? UserCode { get; set; }
        public string? DivisionCode { get; set; }
        public string? PLCode { get; set; }
        public string? BranchCode { get; set; }
        public bool IsActive { get; set; }
    }
}
