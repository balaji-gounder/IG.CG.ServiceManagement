
using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class ProductLineModel
    {
        public int ProductLineID { get; set; }
        [Required(ErrorMessage = "Division is Required")]
        public string? DivisionCode { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Special character not allowed in Product Line Code.")]

        [Required(ErrorMessage = "Product Line Code is Required")]
        public string? ProductLineCode { get; set; }
        [Required(ErrorMessage = "Product Line Name is Required")]
        public string? ProductLineName { get; set; }

        public string? ProductLineRemarks { get; set; }
        public bool IsProductGroupRequired { get; set; }
        public bool IsActive { get; set; }


    }
}
