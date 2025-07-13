
namespace IG.CG.Core.Application.Models
{
    public class ProductDeviationModel
    {
        public int ProdDevAutoId { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductCode { get; set; }
        public string? RoleCode { get; set; }
        public int NoOfDevMonth { get; set; }
        public bool IsActive { get; set; }

    }
}
