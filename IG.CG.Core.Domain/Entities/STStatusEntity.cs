
namespace IG.CG.Core.Domain.Entities
{
    public class STStatusEntity : BaseEntity
    {
        public int STStatusId { get; set; }
        public string? STStatusName { get; set; }
        public bool IsActive { get; set; }

    }
}
