

namespace IG.CG.Core.Domain.Entities
{
    public class ProductDisplayEntity : ProductEntity
    {
        public string? DivisionName { get; set; }
        public string? ProductLineName { get; set; }
        public string? ProductGroupName { get; set; }
        public string? ServiceGroupName { get; set; }
        public int? NoOfVendor { get; set; }

        public List<ParaTypeEntity> VendorList { get; set; }
    }
}
