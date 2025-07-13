using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class CustomerModel
    {
        public int CustAutoId { get; set; }

        [Required(ErrorMessage = "Customer Name is Required")]
        public string? CustName { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        [RegularExpression(@"(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "The Phone field is not a valid Phone Number.")]

        public string? CustPhone { get; set; }
        [RegularExpression(@"(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "The Phone field is not a valid Phone Number.")]

        public string? CustPhone2 { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? CustEmail { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string? CustAddess { get; set; }

        [Required(ErrorMessage = "State is Required")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "City is Required")]
        public int CityId { get; set; }
        public int TalukaId { get; set; }
        public int AreaId { get; set; }


        [Required(ErrorMessage = "Pincode is Required")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "PinCode must be numeric")]
        public int PinId { get; set; }
        public bool IsActive { get; set; }

    }
}
