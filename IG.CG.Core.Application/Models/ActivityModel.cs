
using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class ActivityModel
    {
        public int ActivityId { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }

        [Required(ErrorMessage = "Activity Type Id is Required")]
        public int ActivityTypeId { get; set; }

        [Required(ErrorMessage = "Activity Name is Required")]
        public string? ActivityName { get; set; }
        public bool IsActive { get; set; }
    }

    public class TypeOfWorkDoneModel
    { 
        public int ActivityId { get; set; }
        public string? ActivityName { get; set; }
    
    }
}
