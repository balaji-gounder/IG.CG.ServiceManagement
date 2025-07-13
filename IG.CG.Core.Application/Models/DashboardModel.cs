namespace IG.CG.Core.Application.Models
{
    public class DashboardModel
    {
        public string? TotalNoOfTickets { get; set; }
        public string? ASCRejection { get; set; }
        public string? TotalOpenComplaint { get; set; }
        public string? TechNotAssigned { get; set; }
        public string? ClosedTicket { get; set; }
        public string? CompCancelled { get; set; }
        public string? ASCNTACK { get; set; }
        public string? WorkedUPON { get; set; }

        public string? PendingForCancelApproval { get; set; }

        public string? PendingASMASCApproval { get; set; }
    }


    public class DashboardClaimModel
    {
        public string? ClaimPendingQty { get; set; }
        public string? ClaimASMPendingSubmittedQty { get; set; }
        public string? ClaimRSMPendingSubmittedQty { get; set; }
        public string? ClaimRejectedByCGQty { get; set; }
        public string? ClaimApprovedByCGQty { get; set; }
        public string? ClaimRejectionAcceptedQty { get; set; }
        public string? ClaimPendingForResubmissionQty { get; set; }
        public string? IBNGeneratedQty { get; set; }

        public string? IBNPendingForInvoice { get; set; }

        public string? ClaimPendingAmount { get; set; }

        public string? ClaimASMPendingSubmittedAmount { get; set; }
        public string? ClaimRSMPendingSubmittedAmount { get; set; }
        public string? ClaimRejectedByCGAmount { get; set; }
        public string? ClaimApprovedByCGAmount { get; set; }
        public string? ClaimRejectionAcceptedAmount { get; set; }
        public string? ClaimPendingForResubmissionAmount { get; set; }
        public string? IBNGeneratedAmount { get; set; }
        public string? IBNPendingForInvoiceAmount { get; set; }
    }

}
