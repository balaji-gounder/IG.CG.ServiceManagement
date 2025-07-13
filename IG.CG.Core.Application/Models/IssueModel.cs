
namespace IG.CG.Core.Application.Models
{
    public class IssueModel
    {
        public int IssueTypeId { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }
        public string? IssueTypeName { get; set; }
        public bool IsActive { get; set; }

    }

}
