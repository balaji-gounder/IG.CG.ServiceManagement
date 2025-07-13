

using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class UserModel
    {
        public int UserAutoId { get; set; }
        [Required]
        public string? UserId { get; set; }

        public string? UserPassword { get; set; }
        [Required(ErrorMessage = "User Type is Required")]
        public string? UserTypeCode { get; set; }
        [Required(ErrorMessage = "Email address is Required")]

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? UserEmailId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Role is Required")]
        public string? RoleCode { get; set; }
        public int MappingId { get; set; }
        [Required(ErrorMessage = "Branch is Required")]
        public string? BranchCode { get; set; }
        [Required(ErrorMessage = "Division is Required")]
        public string? DivisionCode { get; set; }
        [Required(ErrorMessage = "Product Line is Required")]
        public string? ProductLineCode { get; set; }

        public string? MobileNo { get; set; }
        public bool IsActive { get; set; }
    }
}
