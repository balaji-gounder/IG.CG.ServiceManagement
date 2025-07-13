namespace IG.CG.Core.Domain.Entities
{
    public class ClaimRateDisplayEntity : ClaimRateEntity
    {
        public string ActivityName { get; set; }
        public string ProductDiv { get; set; }
        public string ProductLine { get; set; }
        public string ServiceName { get; set; }
        public string ServiceClaimTypeName { get; set; }
        public string? TotalRows { get; set; }
        public string NoOfClaimRate { get; set; }
    }
}
