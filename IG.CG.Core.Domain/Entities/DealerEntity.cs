

namespace IG.CG.Core.Domain.Entities
{
    public class DealerEntity : BaseEntity
    {
        public int DealerId { get; set; }
        public string? DealerCode { get; set; }
        public int DealerTypeId { get; set; }
        public string? DealerName { get; set; }
        public string? DealerEmail { get; set; }
        public string? MobileNo { get; set; }
        public string? GSTNo { get; set; }
        public string? Address { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string? PinCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsIndustryCustomer { get; set; }
        public bool isGSTApplicable { get; set; }
        public string? WorkingDays { get; set; }
        public string? msg { get; set; }

    }
}
