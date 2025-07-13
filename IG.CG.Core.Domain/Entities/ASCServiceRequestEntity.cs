
namespace IG.CG.Core.Domain.Entities
{
    public class ASCServiceRequestEntity : BaseEntity
    {

        public int? ServiceTicketId { get; set; }

        public string? SerialNo { get; set; }

        public string? DivisionCode { get; set; }
        public string? MobileNo { get; set; }
        public string? ProductCode { get; set; }
        public string? ServiceTicketNumber { get; set; }
        public string? RequestDate { get; set; }
        public string? CustomerName { get; set; }
        public string? SiteAddress { get; set; }
        public string? CustomerCity { get; set; }
        public string? ProductLineCode { get; set; }
        public string? ProductLineName { get; set; }
        public string? DivisionName { get; set; }
        public string? BranchName { get; set; }
        public string? WarrantyDateStatus { get; set; }
        public string? InvoiceDateStatus { get; set; }
        public string? DefectDesc { get; set; }
        public string? AgeOfPendency { get; set; }
        public string? Distance { get; set; }
        public string? IssueStatus { get; set; }
        public string? TicketAssignedASMCode { get; set; }
        public string? TicketAssignedASCCode { get; set; }

        public string? AscName { get; set; }
        public string? TechnicianName { get; set; }
        public string? Remarks { get; set; }

        public string? IsAcknowledgment { get; set; }

        public string? ServiceRequestType { get; set; }
        public string? ClaimStatus { get; set; }
        public string? AcknowledgmentStatusName { get; set; }
        public string? ServiceRequestTypeName { get; set; }
        public string? SubStatusName { get; set; }
        public string? IsTicketCustomer { get; set; }
        public string? ActualStatusOfComplaint { get; set; }
        public string? PendingWithWhom { get; set; }
        public string? ActionRequired { get; set; }
        public string? PendencyRemarks { get; set; }
        public string? PendencyReasonUpdatedOn { get; set; }
        public string? TabActive { get; set; }
        public bool? IsSpecialApproval { get; set; }
        public string? SpecialApprovalStatus { get; set; }

        public string? cancelledCount { get; set; }
        public string? suspanseCount { get; set; }

        public string? IsChailTicket { get; set; }
        public string? IsChildVisible { get; set; }

        public string? BusinessCall { get; set; }
        public string? IsRceivedWorkShop { get; set; }
        public string? TotalNoOfTicket { get; set; }

        public string? TelecallerRemarks { get; set; }

    }

    public class ASCServiceRequestTotalCountEntity
    {
        public string? OpenTicket { get; set; }
        public string? CancellationRequestTicket { get; set; }
        public string? WorkedUponTicket { get; set; }
        public string? ClosedTicket { get; set; }
        public string? RejectedByASCTicket { get; set; }
        public string? OWNTicket { get; set; }
        public string? ASCTicket { get; set; }
        public string? ClaimGenerated { get; set; }
        public string? FIRGeneratedAndClosure { get; set; }
    }


    public class SerialNoWiseTicketEntity
    {
        public string? CustomerName { get; set; }
        public string? PrimaryMobileNo { get; set; }
        public string? ServiceTicketId { get; set; }
        public string? ServiceTicketNumber { get; set; }
    }

}
