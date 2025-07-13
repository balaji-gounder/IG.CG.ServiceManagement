using Microsoft.AspNetCore.Http;

namespace IG.CG.Core.Domain.Entities
{
    public class ASMServiceRequestClaimInfoEntity : BaseEntity
    {
        public string? ServiceTicketId { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }
        public string? Internal { get; set; }
        public string? TicketAssignedASCCode { get; set; }
        public string? ASCName { get; set; }
        public string? DivCode { get; set; }
        public string? DivisionName { get; set; }
        public string? TicketCreationDate { get; set; }
        public string? ServiceTicketNumber { get; set; }
        public string? WarrantyStatus { get; set; }
        public string? NoOfDaysOfClosure { get; set; }
        public string? ClaimGenerationDate { get; set; }
        public string? SerialNo { get; set; }
        public string? ProductCode { get; set; }
        public string? DefectId { get; set; }
        public string? DefectDesc { get; set; }
        public string? NoOfDefect { get; set; }
        public string? RequestDate { get; set; }
        public string? AcknowledgmentStatusName { get; set; }
        public string? TotalAmount { get; set; }
        public string? Distance { get; set; }
        public string? Status { get; set; }
        public string? LastComment { get; set; }
        public string? RepetitiveComplaint { get; set; }
        public string? Attachment { get; set; }
        public string? ClosureRemarks { get; set; }
        public string? ClosureDate { get; set; }

        public string? TotalTicket { get; set; }

    }

    public class ClaimAttachmentListEntity
    {
        public string? ServiceTicketNumber { get; set; }
        public string? AttachmentType { get; set; }
        public string? FilePath { get; set; }

    }

    public class ASMServiceRequestClaimLineItemsEntity
    {
        public string? ServiceTicketClaimId { get; set; }
        public string? ServiceTicketId { get; set; }
        public bool IsValueEditable { get; set; }
        public string? ClaimNo { get; set; }
        public string? ProductCode { get; set; }

        public string? WarrantyBatch { get; set; }

        public string? WarrantyInvoice { get; set; }
        public string? ProductDescription { get; set; }
        public string? Type { get; set; }
        public string? ClaimTicketNumber { get; set; }
        public string? ActivityName { get; set; }
        public string? Parameter { get; set; }
        public string? PossibleValue { get; set; }
        public int? Qty { get; set; }
        public string? Rate { get; set; }
        public string? TotalAmount { get; set; }
        public string? ClaimRemarksByASC { get; set; }
        public string? InvoiceNo { get; set; }
        public string? InvoiceAttachment { get; set; }
        public string? Status { get; set; }
        public string? ApprovedRemarks { get; set; }
        public string? Info { get; set; }
        public string? Spare { get; set; }
        public string? SpareDesc { get; set; }
        public string? ApprovedOn { get; set; }
        public string? Challan { get; set; }
        public string? ChallanStatus { get; set; }
        public string? IBN { get; set; }
        public string? IBNGenerationOn { get; set; }
        public string? ActionTakenBy { get; set; }
        public string? ClaimSource { get; set; }
        public bool IsClaimResubmission { get; set; }
        public string? AscJustification { get; set; }
        public int? IsDeviation { get; set; }
        public string? CurrentDistance { get; set; }
        public string? SysDistance { get; set; }
        public string? ParaValue { get; set; }
        public string? IsConveyance { get; set; }
        public bool? IsEditable { get; set; }




    }

    public class ASCServiceRequestClaimItemsManageApprovalEntity
    {
        public string? ServiceTicketClaimId { get; set; }
        public string? ServiceTicketId { get; set; }
        public string? ServiceTicketNumber { get; set; }
        public bool IsAcceptRejection { get; set; }
        public bool IsValueEditable { get; set; }
        public string? ClaimNo { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductDescription { get; set; }
        public string? Type { get; set; }
        public string? ClaimTicketNumber { get; set; }
        public string? ActivityName { get; set; }
        public string? Parameter { get; set; }
        public string? PossibleValue { get; set; }
        public int? Qty { get; set; }
        public string? Rate { get; set; }
        public string? TotalAmount { get; set; }
        public string? ClaimRemarksByASC { get; set; }
        public string? InvoiceNo { get; set; }
        public string? InvoiceAttachment { get; set; }
        public string? ASMStatus { get; set; }
        public string? ASMApprovedRemarks { get; set; }
        public string? RSMStatus { get; set; }
        public string? RSMApprovedRemarks { get; set; }
        public string? ASMApprovedOn { get; set; }
        public string? RSMApprovedOn { get; set; }
        public string? Info { get; set; }
        public string? Spare { get; set; }
        public string? SpareDesc { get; set; }
        public string? Challan { get; set; }
        public string? ChallanStatus { get; set; }
        public string? IBN { get; set; }
        public string? IBNGenerationOn { get; set; }
        public string? ActionTakenBy { get; set; }
        public string? ClaimSource { get; set; }
        public bool IsClaimResubmission { get; set; }
        public string? AscJustification { get; set; }
        public int? IsDeviation { get; set; }
        public string? CurrentDistance { get; set; }
        public string? SysDistance { get; set; }
        public string? ParaValue { get; set; }
        public string? IsConveyance { get; set; }
        public string? TotalRows { get; set; }
        public bool? IsEditable { get; set; }



    }
    public class ASMServiceRequestClaimApprovalEntity
    {
        public int? ServiceTicketId { get; set; }
        public int? ServiceTicketClaimId { get; set; }
        public string? Remarks { get; set; }
        public bool IsApproved { get; set; }

    }
    public class ASCServiceRequestClaimInfoEntity
    {
        public string? AscCode { get; set; }
        public string? RegionName { get; set; }
        public string? BranchName { get; set; }
        public string? ASCName { get; set; }
        public string? ServiceEngineer { get; set; }
        public string? TotalCallClosed { get; set; }
        public string? TotalNoOfClaim { get; set; }
        public string? ToBeApprovedClaimsEIC { get; set; }
        public string? ApprovedClaimsEIC { get; set; }
        public string? RejectedClaimsEIC { get; set; }
        public string? ToBeApprovedClaimsRSM { get; set; }
        public string? ApprovedClaimsRSM { get; set; }
        public string? RejectedClaimsRSM { get; set; }
        public string? TotalApprovedClaim { get; set; }
        public string? TotalClaimPendingForIBNGeneration { get; set; }
        public string? TotalClaimIBNGenerated { get; set; }

    }

    public class ASCServiceRequestClaimLineItemsEntity
    {
        public string? ServiceTicketClaimId { get; set; }
        public string? ServiceTicketId { get; set; }
        public string? TicketNo { get; set; }
        public string? TicketCreateDate { get; set; }
        public string? ClaimNo { get; set; }
        public string? ClaimGenerationDate { get; set; }
        public string? PartnerName { get; set; }
        public string? ProductCode { get; set; }
        public string? Type { get; set; }
        public string? ActivityName { get; set; }
        public string? Parameter { get; set; }
        public string? PossibleValue { get; set; }
        public int? Qty { get; set; }
        public string? Rate { get; set; }
        public string? TotalAmount { get; set; }
        public string? ClaimRemarksByASC { get; set; }
        public string? InvoiceNo { get; set; }
        public string? TicketClosedDate { get; set; }
        public string? TicketAge { get; set; }
        public string? ClaimStatus { get; set; }
        public string? ActionTakenBy { get; set; }
        public string? EICClaimApprovalDate { get; set; }
        public string? RSMClaimApprovedDate { get; set; }
        public string? ClaimDeletedOnDate { get; set; }
        public string? Challan { get; set; }
        public string? ChallanStatus { get; set; }
        public string? IBN { get; set; }
        public string? IBNGenerationOn { get; set; }

    }

    public class AscClaimApprovalLineItemsEntity
    {
        public string? ServiceTicketClaimId { get; set; }
        public string? ServiceTicketId { get; set; }
        public string? TicketNo { get; set; }
        public string? TicketCreateDate { get; set; }
        public string? ClaimNo { get; set; }
        public string? ClaimGenerationDate { get; set; }
        public string? PartnerName { get; set; }
        public string? ProductCode { get; set; }
        public string? Type { get; set; }
        public string? ActivityName { get; set; }
        public string? Parameter { get; set; }
        public string? PossibleValue { get; set; }
        public int? Qty { get; set; }
        public string? Rate { get; set; }
        public string? TotalAmount { get; set; }
        public string? ClaimRemarksByASC { get; set; }
        public string? InvoiceNo { get; set; }
        public string? TicketClosedDate { get; set; }
        public string? TicketAge { get; set; }
        public string? ASMStatus { get; set; }
        public string? ASMApprovedRemarks { get; set; }
        public string? RSMStatus { get; set; }
        public string? RSMApprovedRemarks { get; set; }
        public string? ActionTakenBy { get; set; }
        public string? EICClaimApprovalDate { get; set; }
        public string? RSMClaimApprovedDate { get; set; }
        public string? ClaimDeletedOnDate { get; set; }
        public string? Challan { get; set; }
        public string? ChallanStatus { get; set; }
        public string? IBN { get; set; }
        public string? IBNGenerationOn { get; set; }



    }

    public class AscServiceRequestClaimReApprovalEntity
    {
        public int? ServiceTicketId { get; set; }
        public int? ServiceTicketClaimId { get; set; }
        public bool ASMIsRejected { get; set; }
        public bool RSMIsRejected { get; set; }
        public decimal ClaimAmount { get; set; }
        public decimal CurrentDistance { get; set; }
        public string? AscJustification { get; set; }

    }

    public class AscSpecialApprovalClaimEntity
    {
        public string? ServiceTicketId { get; set; }
        public decimal ClaimAmount { get; set; }
        public string? Remarks { get; set; }
        public List<IFormFile>? DocumentFile { get; set; }
    }

    public class AscIBNListEntity
    {
        public int IBNId { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
        public string? AscCode { get; set; }
        public string? AscName { get; set; }
        public string? DivisionName { get; set; }
        public string? ProductLineName { get; set; }
        public string? IBNNumber { get; set; }
        public string? BillGenerationDate { get; set; }
        public string? NoOfServiceTickets { get; set; }
        public string? CountOfServiceClaims { get; set; }
        public string? AmountOfServiceClaims { get; set; }
    }
    public class IBNPdfInfoEntity
    {
        public int PrintStatusCount { get; set; }
        public string? InternetBillNo { get; set; }
        public string? Type { get; set; }
        public string? AscName { get; set; }
        public string? AscAddress { get; set; }
        public string? Branch { get; set; }
        public string? Address { get; set; }
        public string? ProductDivision { get; set; }
        public string? ProductLine { get; set; }
        public string? NoOfTickets { get; set; }
        public string? NoOfClaims { get; set; }
        public string? TotalAmount { get; set; }
        public string? ComplaintClosedDate { get; set; }
        public string? ComplaintClosedMonth { get; set; }
        public string? IBNGeneratedDate { get; set; }
        public string? IBNGeneratedMonth { get; set; }
        public string? BillRemark { get; set; }
        public string? TotalNoOfRecords { get; set; }

        public string? IbnTitleDate { get; set; }

        public List<ClaimDetailsEntity>? ClaimDetailsList { get; set; }

    }

    public class ClaimDetailsEntity
    {
        public string? ServiceRequestNo { get; set; }
        public string? ClaimApprovalDate { get; set; }
        public string? ApprovedBy { get; set; }
        public string? Spare { get; set; }
        public string? SpareDesc { get; set; }
        public string? Activity { get; set; }
        public string? Parameter { get; set; }
        public string? PossibleValue { get; set; }
        public string? InvoiceNo { get; set; }
        public string? ProductSerialNo { get; set; }
        public string? Qty { get; set; }
        public string? Rate { get; set; }
        public string? TotalAmount { get; set; }

        public string? ClaimRateDetailId { get; set; }
        public string? ServiceTicketId { get; set; }
        public string? IsConveyance { get; set; }
    }

    public class AsmServiceTicketClaimAmountDistanceEntity
    {
        public int? ServiceTicketId { get; set; }
        public int? ServiceTicketClaimId { get; set; }
        public decimal ClaimAmount { get; set; }
        public decimal CurrentDistance { get; set; }
        public decimal NoOfVisit { get; set; }

    }


    public class AsmIBNTicketClaimAmountEntity
    {
        public int? ServiceTicketId { get; set; }
        public int? ServiceTicketClaimId { get; set; }
        public decimal? ClaimAmount { get; set; }
        public decimal? ClaimAmountIBN { get; set; }
        public string? ASMApprovedBy { get; set; }

        public string? Remarks { get; set; }

    }



    public class ASMSpecialApprovalLineItemsEntity
    {
        public int? SpecialApprovalId { get; set; }
        public int? ServiceTicketId { get; set; }
        public string? ServiceTicketNo { get; set; }
        public string? ClaimAmount { get; set; }
        public string? Remarks { get; set; }
        // public bool? RSMIsApproved { get; set; }
        public string? ApprovalRemarks { get; set; }
        public string? ClaimNo { get; set; }
        public string? ApprovalStatus { get; set; }
        public string? ApprovedOn { get; set; }
        public string? SpecialApprovalCreatedOn { get; set; }
        public string? ASMResubmitRemarks { get; set; }
        public string? AscName { get; set; }
        public string? BranchName { get; set; }
        public string? AttachmentCount { get; set; }


    }
    public class RSMSpecialApprovalLineItemsEntity
    {
        public int? SpecialApprovalId { get; set; }
        public int? ServiceTicketId { get; set; }
        public string? ServiceTicketNo { get; set; }
        public string? ClaimNo { get; set; }
        public string? ClaimAmount { get; set; }
        public string? Remarks { get; set; }
        public string? ApprovalRemarks { get; set; } // approval remarks common for each level
        //public bool? RSMIsApproved { get; set; }
        public string? ASMResubmitRemarks { get; set; }
        public string? CreatedBy { get; set; }
        public string? SpecialApprovalCreatedOn { get; set; }
        public string? AscName { get; set; }
        public string? BranchName { get; set; }
        public string? ApprovalStatus { get; set; }  // Status will be shown for previous approver
        public string? AttachmentCount { get; set; }

    }

    public class UpdateRSMSpecialApprovalEntity
    {
        public int? SpecialApprovalId { get; set; }
        public int? ServiceTicketId { get; set; }
        public string? ApprovalRemarks { get; set; }
        public int IsApproved { get; set; }

    }

    public class UpdateASMAcceptRejectionResubmissionEntity
    {
        public bool? IsAccpetRejection { get; set; }
        public bool? IsClaimResubmission { get; set; }
        public int? SpecialApprovalId { get; set; }
        public string? ASMResubmitRemarks { get; set; }
        public decimal? ClaimAmount { get; set; }

    }

    public class SpecialApprovalClaimAttachmentListEntity
    {
        public string? ServiceTicketNumber { get; set; }
        public string? FilePath { get; set; }

    }

    public class ASCSpecialApprovalLineItemsEntity
    {
        public int? SpecialApprovalId { get; set; }
        public int? ServiceTicketId { get; set; }
        public string? ServiceTicketNo { get; set; }
        public string? ClaimAmount { get; set; }
        public string? Remarks { get; set; }
        public string? ApprovalRemarks { get; set; }
        //public string? ASMResubmitRemarks { get; set; }
        public string? CreatedBy { get; set; }
        public string? SpecialApprovalCreatedOn { get; set; }
        public string? ApprovalStatus { get; set; }

    }

}
