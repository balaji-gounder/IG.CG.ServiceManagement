using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class BranchModel
    {

        public int BranchId { get; set; }


        [Required(ErrorMessage = "Branch Code is Required")]
        public string? BranchCode { get; set; }
        [Required]
        public string? BranchName { get; set; }
        public string? Remarks { get; set; }

        public string? RegionCode { get; set; }
        public string? BranchAddress { get; set; }

        public int CountryId { get; set; }

        [Required(ErrorMessage = "State is Required")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "City is Required")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Pin Code is Required")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "PinCode must be numeric")]
        public int PinCode { get; set; }

        public string? Phone { get; set; }


        public string? Email { get; set; }
        public bool IsActive { get; set; }

    }
}
