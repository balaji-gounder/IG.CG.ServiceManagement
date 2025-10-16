namespace IG.CG.Core.Domain.Entities
{
    public class ServiceTicketClaimRateDetailEntity
    {
        public int ServiceTicketId { get; set; }
        public int? ClaimRateDetailId { get; set; }

        public string? ServiceTicketClaimId { get; set; }
        public string? ActivityTypeId { get; set; }
        public string? SerialNo { get; set; }
        public string? ActivityType { get; set; }
        public string? ParaDetail { get; set; }
        public string? ParaValue { get; set; }
        public string? ActivityName { get; set; }
        public string? RateAmount { get; set; }
        public string? ClaimAmount { get; set; }
        public string? Distance { get; set; }
        public string? IsValueEditable { get; set; }
        public string? IsConveyance { get; set; }
        public string? IsDeviation { get; set; }

        public string? SysDistance { get; set; }
        public string? IsShow { get; set; }
        public string? IsEditable { get; set; }
        public string? SysDistanceValue { get; set; }
        public string? ServiceTicketNumber { get; set; }
        public string? ClaimStatus { get; set; }

        public string? ApprovedClaimAmount { get; set; }
        public string? Remarks { get; set; }
        public string? IBN { get; set; }
    }
}
