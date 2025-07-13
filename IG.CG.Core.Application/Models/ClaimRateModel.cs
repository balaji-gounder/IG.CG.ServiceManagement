namespace IG.CG.Core.Application.Models
{
    public class ClaimRateModel
    {
        public int ClaimRateId { get; set; }
        public int ServiceClaimTypeId { get; set; }
        public int ActivityId { get; set; }
        public string ProductDivCode { get; set; }
        public string ProductLineCode { get; set; }
        public bool? IsMinor { get; set; }
        public int ServiceId { get; set; }
        public bool? IsActive { get; set; }
        public List<ClaimRateDetailsModel> ClaimRateDetails { get; set; }
    }
}
