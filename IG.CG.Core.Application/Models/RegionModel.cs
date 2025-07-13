using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class RegionModel
    {
        public int RegionId { get; set; }

        public string? RegionCode { get; set; }
        [Required(ErrorMessage = "Region Name is Required")]
        public string? RegionName { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public string? TotalRows { get; set; }
    }
}
