namespace IG.CG.Core.Domain.Entities
{
    public class ClaimApprovalHistoryEntity
    {
        public int ClaimApprovalHistoryId { get; set; }
        public int ServiceTicketId { get; set; }
        public int ServiceTicketClaimId { get; set; }
        public string? ClaimStatus { get; set; }
        public string? ApprovedBy { get; set; }
        public string? ApprovedOn { get; set; }
        public string? AmountBefore { get; set; }
        public string? AmountAfter { get; set; }
        public string? DistanceBefore { get; set; }
        public string? DistanceAfter { get; set; }
        public string? Remarks { get; set; }

        public string? Qty { get; set; }

    }

    public class ClaimApprovalHistoryDisplayEntity
    {
        public int ClaimApprovalHistoryId { get; set; }
        public int ServiceTicketId { get; set; }
        public int ServiceTicketClaimId { get; set; }
        public string? Activity { get; set; }
        public string? DoneBy { get; set; }
        public string? ActivityOn { get; set; }
        public string? ClaimAmountBefore { get; set; }
        public string? ClaimAmountAfter { get; set; }
        public string? DistanceBefore { get; set; }
        public string? DistanceAfter { get; set; }
        public string? Remarks { get; set; }
        public string? Qty { get; set; }
        public string? ClaimNo { get; set; }

    }

    public class SpecialApprovalHistoryEntity
    {
        public int ClaimApprovalHistoryId { get; set; }
        public int ServiceTicketId { get; set; }
        public int SpecialApprovalId { get; set; }
        public string? ClaimStatus { get; set; }
        public string? ApprovedBy { get; set; }
        public string? ApprovedOn { get; set; }
        public string? AmountBefore { get; set; }
        public string? AmountAfter { get; set; }
        public string? Remarks { get; set; }

    }

    public class SpecialApprovalHistoryDisplayEntity
    {
        public int ClaimApprovalHistoryId { get; set; }
        public int ServiceTicketId { get; set; }
        public int SpecialApprovalId { get; set; }
        public string? Activity { get; set; }
        public string? DoneBy { get; set; }
        public string? ActivityOn { get; set; }
        public string? ClaimAmountBefore { get; set; }
        public string? ClaimAmountAfter { get; set; }
        public string? Remarks { get; set; }
        public string? Qty { get; set; }
        public string? ClaimNo { get; set; }
    }

}
