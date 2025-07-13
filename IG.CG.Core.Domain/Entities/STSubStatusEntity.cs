
namespace IG.CG.Core.Domain.Entities
{
    public class STSubStatusEntity : BaseEntity
    {
        public int STSubStatusId { get; set; }
        public int STStatusId { get; set; }
        public string? STSubStatusName { get; set; }
        public string? STStatusName { get; set; }
        public bool IsActive { get; set; }
    }

    public class STSubStatusByTypeEntity : BaseEntity
    {
        public int STSubStatusId { get; set; }
        public int STStatusId { get; set; }
        public string? STStatusName { get; set; }
        public string? STSubStatusName { get; set; }
        public string? StatusType { get; set; }
        public bool IsActive { get; set; }
    }

    public class ServiceTicketStatusEntity
    {
        public int ServiceTicketStatusId { get; set; }
        public int STSubStatusId { get; set; }
        public string? STSubStatusName { get; set; }
        public string? ServiceTicketStatusName { get; set; }
        public bool IsActive { get; set; }
    }
}
