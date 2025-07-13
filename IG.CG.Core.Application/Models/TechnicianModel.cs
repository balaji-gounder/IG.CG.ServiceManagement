
using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class TechnicianModel
    {
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "Technician Name is Required")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Technician Name should not be greater than 200 characters")]
        public string? TechnicianName { get; set; }

        [Required(ErrorMessage = "ASC Code is Required")]

        public string? AscCode { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string? Mobile { get; set; }

        public string? TechnicianEmail { get; set; }

        [Required(ErrorMessage = "Division  is Required")]
        public string? DivisionCode { get; set; }

        public string? ProductLineCode { get; set; }

        public string? SkillId { get; set; }

        public bool IsActive { get; set; }

        public string? ProductGroupCode { get; set; }
        public string? PhoneNo { get; set; }

    }
}
