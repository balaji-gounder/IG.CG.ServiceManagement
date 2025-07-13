using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class ProductGroupModel
    {
        public int ProductGroupId { get; set; }
        [Required(ErrorMessage = "Product Line is Required")]
        public string? ProductLineCode { get; set; }
        [Required(ErrorMessage = "Division is Required")]
        public string? DivisionCode { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Special character not allowed in Product Group Code.")]
        public string? ProductGroupCode { get; set; }
        [Required(ErrorMessage = "Product Group Name is Required")]
        public string? ProductGroupName { get; set; }

        public string? ProductGroupDesc { get; set; }

        public bool IsActive { get; set; }

    }
}
