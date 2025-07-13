

using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class DealerModel
    {
        public int DealerId { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Special character not allowed in Dealer Code.")]
        [Required(ErrorMessage = "DealerCode is Required")]
        public string? DealerCode { get; set; }
        [Required(ErrorMessage = "Dealer Type is Required")]
        public int DealerTypeId { get; set; }
        [Required(ErrorMessage = "Dealer Name is Required")]
        public string? DealerName { get; set; }
        [Required(ErrorMessage = "Email Address is Required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? DealerEmail { get; set; }

        [Required(ErrorMessage = "Mobile No is Required")]
        [RegularExpression(@"(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "The MobileNo field is not a valid MobileNo Number.")]

        public string? MobileNo { get; set; }

        public string? GSTNo { get; set; }
        public string? WorkingDays { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "State is Required")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "City is Required")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "PinCode is Required")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "PinCode must be numeric")]
        public string? PinCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsIndustryCustomer { get; set; }
        public bool isGSTApplicable { get; set; }
        public string? msg { get; set; }


    }
}
