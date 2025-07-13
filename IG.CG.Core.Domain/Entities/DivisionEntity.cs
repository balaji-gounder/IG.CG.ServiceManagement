

namespace IG.CG.Core.Domain.Entities
{
    public class DivisionEntity : BaseEntity
    {
        public int DivisionId { get; set; }
        public string? DivisionCode { get; set; }
        public string? DivisionName { get; set; }
        public string? DivisionRemarks { get; set; }
        public int LongLastingTickitHour { get; set; }
        public bool FrameSizeOrHpReqOrNot { get; set; }
        public bool IsActive { get; set; }
    }
}
