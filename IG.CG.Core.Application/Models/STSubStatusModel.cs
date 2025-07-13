
using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class STSubStatusModel
    {
        public int STSubStatusId { get; set; }

        [Required(ErrorMessage = "Service Ticket Status Id is Required")]
        public int STStatusId { get; set; }
        public string? STStatusName { get; set; }

        [Required(ErrorMessage = "Service Ticket Status Name is Required")]
        public string? STSubStatusName { get; set; }

        public bool IsActive { get; set; }
    }

    public class STSubStatusByTypeModel
    {
        public int STSubStatusId { get; set; }
        public int STStatusId { get; set; }
        public string? STStatusName { get; set; }
        public string? STSubStatusName { get; set; }
        public string? StatusType { get; set; }
        public bool IsActive { get; set; }
    }

    public class ServiceTicketStatusModel
    {
        public int ServiceTicketStatusId { get; set; }
        public int STSubStatusId { get; set; }
        public string? STSubStatusName { get; set; }
        public string? ServiceTicketStatusName { get; set; }
        public bool IsActive { get; set; }
    }
}
