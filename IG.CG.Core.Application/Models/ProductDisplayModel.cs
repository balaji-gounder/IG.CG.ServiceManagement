using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Models
{
    public class ProductDisplayModel : ProductModel
    {
        public string? DivisionName { get; set; }
        public string? ProductLineName { get; set; }
        public string? ProductGroupName { get; set; }
        public string? ServiceGroupName { get; set; }
        public int? NoOfVendor { get; set; }
        public string? TotalRows { get; set; }
        public List<ParaTypeEntity> VendorList { get; set; }
    }
}
