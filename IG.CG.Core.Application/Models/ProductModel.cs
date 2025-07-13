using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        //[RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Special character not allowed in Product Code.")]
        public string? ProductCode { get; set; }
        [Required(ErrorMessage = "Division is Required")]
        public string? DivisionCode { get; set; }
        [Required(ErrorMessage = "Product Line is Required")]
        public string? ProductLineCode { get; set; }
        //[Required(ErrorMessage = "Product Group is Required")]
        public string? ProductGroupCode { get; set; }
        [Required(ErrorMessage = "Product Description is Required")]
        public string? ProductDescription { get; set; }
        public int ServiceGroupId { get; set; }
        [Required(ErrorMessage = "Warranty From Batch is Required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Warranty from batch must be numeric")]
        public int WarrantyFromBatch { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Warranty from DOI must be numeric")]
        public int WarrantyFromDOI { get; set; }

        public string? HP { get; set; }
        public string? RewindingGroup { get; set; }
        public string? AscDays { get; set; }

        public string? DeviationUpto { get; set; }

        public string? DeviationMonth { get; set; }
        public string? FrameSize { get; set; }
        public bool IsActive { get; set; }
        public string? VendorId { get; set; }
        public string? Kilowatt { get; set; }
    }
}
