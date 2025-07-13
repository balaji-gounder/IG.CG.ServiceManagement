using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class DivisionModel
    {
        public int DivisionId { get; set; }
        [Required]
        public string? DivisionCode { get; set; }
        [Required(ErrorMessage = "SAP Division Name is Required")]
        public string? DivisionName { get; set; }

        public string? DivisionRemarks { get; set; }
        [Required(ErrorMessage = "Long Lasting Tickit Hour is Required")]
        [RegularExpression(@"[+-]?([0-9]*[.])?[0-9]+", ErrorMessage = "Please only enter numeric characters only for your Long Lasting Tickit Hour")]
        public int LongLastingTickitHour { get; set; }
        public bool FrameSizeOrHpReqOrNot { get; set; }
        public bool IsActive { get; set; }

        public string? TotalRows { get; set; }
    }
}
