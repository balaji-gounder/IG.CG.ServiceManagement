
namespace IG.CG.Core.Application.Models
{
    public class ServiceTicketDashboardModel
    {
        //ASC
        public int TotalNoOfComplaintsRegistered { get; set; }
        public int TotalNoOfTicketsRejectedByAsc { get; set; }
        public int TotalNoOfOpenComplaints {  get; set; }
        public int TechnicianNotAssignedCount { get; set; }
        public int TotalNoOfComplaintsClosed {  get; set; }
        public int TotalNoOfComplaintsCancelled { get; set; }
        public int NoOfSRPendingForClaimSubmission { get; set; }
        public int NoOfClaimsSubmitted {  get; set; }
        public int NoOfClaimsPendingForResubmission { get; set; }
        public int NoOfIBNPendingForInvoiceSubmission { get; set; }
        public int NoOfClaimsRejectedByCG { get; set; }
        public int NoOfClaimsRejectionAcceptedByASC { get; set; }
        public int NoOfClaimsRejectionPendingWithASC { get; set; }
        public int NoOfClaimsPendingWithASM { get; set; }
        public int NoOfClaimsPendingWithRSM { get; set; }
        public int NoOfClaimsPendingWithDSH { get; set; }

        //ASM
        public int totalNoOfComplaintsSuspense {  get; set; }
        public int ComplaintsPendingWithASMForCancellation { get; set; }
        public int NoOfClaimsResubmissionPendingWithASC { get; set; }

        //RSM //AISH
        public int NoOfClaimsRejectedByASMPendingWithRSM { get; set; }


    }

    public class AscTatPerformanceModel
    { 
        public string? CPTat1Day { get; set; }
        public string? CPTat3Day { get; set; }
        public string? CPDelayed { get; set; }
        public string? CPPending { get; set; }
        public string? DRTat1Day { get; set; }
        public string? DRTat3Day { get; set; }
        public string? DRDelayed { get; set; }
        public string? DRPending { get; set; }
        public string? M3Tat1Day { get; set; }
        public string? M3Tat3Day { get; set; }
        public string? M3Delayed { get; set; }
        public string? M3Pending { get; set; }
        public string? M7Tat1Day { get; set; }
        public string? M7Tat3Day { get; set; }
        public string? M7Delayed { get; set; }
        public string? M7Pending { get; set; }
        public string? M4Tat1Day { get; set; }
        public string? M4Tat3Day { get; set; }
        public string? M4Delayed { get; set; }
        public string? M4Pending { get; set; }

    }

}
