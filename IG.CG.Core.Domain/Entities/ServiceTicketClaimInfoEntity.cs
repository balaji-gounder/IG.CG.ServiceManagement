using Microsoft.AspNetCore.Http;

namespace IG.CG.Core.Domain.Entities
{
    public class ServiceTicketClaimInfoEntity : BaseEntity
    {
        public int ServiceTicketClaimId { get; set; }
        public int? ServiceTicketId { get; set; }
        public int? ClaimRateDetailId { get; set; }
        public string? SerialNo { get; set; }
        public int? ActivityTypeId { get; set; }
        public string? ParaDetail { get; set; }
        public decimal? ParaValue { get; set; }
        public decimal? RateAmount { get; set; }
        public decimal? ClaimAmount { get; set; }
        public string? IsDeviation { get; set; }
        public string? ClaimNo { get; set; }

        public string? ActivityName { get; set; }
        public string? SysDistanceValue { get; set; }
        public string? SysDistance { get; set; }
        public string? Distance { get; set; }

        public string? IsEditable { get; set; }
        public string? IsConveyance { get; set; }

        public string? Remarks { get; set; }
    }

    public class ServiceTicketDeviationClaimInfoEntity : BaseEntity
    {
        public string? TypeClaim { get; set; }
        public string? ServiceTicketId { get; set; }

        public string? activityTypeId { get; set; }
        public string? SerialNo { get; set; }
        public string? ClaimNo { get; set; }
        public string? ParaDetail { get; set; }
        public decimal? ClaimAmount { get; set; }
        public string? AttachmentType { get; set; }
        public string? AttachmentName { get; set; }
        public List<IFormFile>? AttachmentFile { get; set; }
        public decimal? CurrentDistance { get; set; }
        public decimal? SysDistance { get; set; }
        public string? Remarks { get; set; }
        public string? ClaimDeviationTypeId { get; set; }
        public string? modeOftravel { get; set; }
        public string? wayToDistance { get; set; }
        public string? ParaValue { get; set; }
    }
}
