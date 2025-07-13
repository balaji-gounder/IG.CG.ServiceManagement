using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class DefectCategoryModel
    {
        public int DefectCategoryId { get; set; }

        [Required(ErrorMessage = "Defect Category Name is Required")]
        public string? DefectCategoryName { get; set; }

        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Division Code is Required")]
        public string? DivisionCode { get; set; }
        [Required(ErrorMessage = "Product Line Code is Required")]
        public string? ProductLineCode { get; set; }

        public string? ProductGroupCode { get; set; }
    }
}
