

namespace IG.CG.Core.Domain.Entities
{
    public class BranchEntity : BaseEntity
    {
        public int BranchId { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }
        public string? Remarks { get; set; }
        public string? RegionCode { get; set; }
        public string? BranchAddress { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int PinCode { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
    }
}
