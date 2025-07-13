using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class DefectModel
    {
        public int DefectId { get; set; }
        [Required(ErrorMessage = "Division is Required")]
        public string? DivisionCode { get; set; }
        [Required(ErrorMessage = "Product Line is Required")]
        public string? ProductLineCode { get; set; }

        public string? ProductGroupCode { get; set; }

        public string? ProductCode { get; set; }

        [Required(ErrorMessage = "Defect Category is Required")]
        public int? DefectCategoryId { get; set; }
        [Required(ErrorMessage = "Defect Description is Required")]
        public string? DefectDesc { get; set; }
        public bool IsActive { get; set; }
    }
}
