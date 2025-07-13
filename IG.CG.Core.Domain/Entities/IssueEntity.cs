
namespace IG.CG.Core.Domain.Entities
{
    public class IssueEntity : BaseEntity
    {
        public int IssueTypeId { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }
        public string? IssueTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
