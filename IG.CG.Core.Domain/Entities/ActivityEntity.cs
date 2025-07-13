

namespace IG.CG.Core.Domain.Entities
{
    public class ActivityEntity : BaseEntity
    {
        public int ActivityId { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }
        public int ActivityTypeId { get; set; }
        public string? ActivityName { get; set; }
        public bool IsActive { get; set; }
    }

    public class TypeOfWorkDoneEntity
    {
        public int ActivityId { get; set; }
        public string? ActivityName { get; set; }

    }
}
