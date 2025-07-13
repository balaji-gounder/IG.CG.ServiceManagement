
namespace IG.CG.Core.Domain.Entities
{
    public class RewindingServicesDisplayEntity
    {
        public int ServiceId { get; set; }
        public string? ServiceClaimType { get; set; }
        public string? ServiceName { get; set; }
        public bool IsActive { get; set; }
    }
}
