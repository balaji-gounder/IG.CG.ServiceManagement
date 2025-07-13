

using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class STStatusModel
    {
        public int STStatusId { get; set; }

        [Required(ErrorMessage = "Service Ticket Status Name is Required")]
        public string? STStatusName { get; set; }
        public bool IsActive { get; set; }


    }
}
