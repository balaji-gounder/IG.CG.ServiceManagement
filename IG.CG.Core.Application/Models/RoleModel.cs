using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class RoleModel
    {
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Role Name is Required")]
        public string? RoleName { get; set; }

        public string? RoleDesc { get; set; }

        public string? RoleCode { get; set; }

        public int ReportingTo { get; set; }
        public bool IsActive { get; set; }
        public int RightTypeId { get; set; }
        [Required(ErrorMessage = "User Type is Required")]
        public string? UserTypeId { get; set; }
        public bool IsMultipleBranch { get; set; }
        public bool IsMultipleDivision { get; set; }
        public bool IsDeviation { get; set; }
        public string? UserTypeName { get; set; }

        public string? TotalRows { get; set; }
    }
}
