namespace IG.CG.Core.Domain.Entities
{
    public class ClaimRateDetailsEntity
    {
        public int ClaimRateDetailId { get; set; }
        public int ClaimRateId { get; set; }
        public int RepairTypeId { get; set; }
        public int TravelClaimId { get; set; }
        public int ActivityTypeId { get; set; }
        public string? ParaDetail { get; set; }
        public string? ParaValue { get; set; }
        public string? ParaCondition { get; set; }
        public int ParaUOMId { get; set; }
        public bool FixedQty { get; set; }
        public int FixedQtyValue { get; set; }
        public bool MaxAmount { get; set; }
        public int MaximumAmountValue { get; set; }
        public string? ClaimRateName { get; set; }
        public string? RepairTypeName { get; set; }

        public string? TravelClaimName { get; set; }
        public string? ActivityTypeName { get; set; }
        public string? ParaUOM { get; set; }
        public int isUpdate { get; set; }


    }
}
