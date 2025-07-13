namespace IG.CG.Core.Domain.Entities
{
    public class AscServiceTicketCustomerEntity : BaseEntity
    {
        public int? AscCustomerContactedId { get; set; }
        public int? ServiceTicketId { get; set; }
        public string? ComplainType { get; set; }
        public string? ContactDate { get; set; }
        public string? SerialNo { get; set; }
        public string? ProductCode { get; set; }
        public string? Frame { get; set; }
        public string? KW { get; set; }
        public string? KVA { get; set; }
        public string? EFFE { get; set; }
        public string? FLPS { get; set; }
        public string? HP { get; set; }
        public string? InvoiceDate { get; set; }
        public string? InvoiceNo { get; set; }
        public string? Remarks { get; set; }
        public string? ServiceRequestSubStatusId { get; set; }
        public string? ServiceRequestCustStatusid { get; set; }

        public string? ProductRquestDate { get; set; }
        public string? TechnicianId { get; set; }

        public string? WarrantyDateStatus { get; set; }
        public string? AppointmentTime { get; set; }
        public string? InvoiceDateStatus { get; set; }

    }

    public class AscServiceTicketInfoReportEntity
    {
        public string? TotalRows { get; set; }
        public string? SerialNo { get; set; }
        public string? ProductCode { get; set; }
        public string? InvoiceDate { get; set; }
        public string? InvoiceNo { get; set; }
        public string? Frame { get; set; }
        public string? KW { get; set; }
        public string? KVA { get; set; }
        public string? EFFE { get; set; }
        public string? FLPS { get; set; }
        public string? HP { get; set; }
        public string? ProductName { get; set; }
        public string? ProductLineName { get; set; }
        public string? ProductGroupName { get; set; }
        public string? InvoiceFilePath { get; set; }
        public string? DivisionName { get; set; }
        public string? BatchStartDate { get; set; }
        public string? BatchEndDate { get; set; }
        public string? ManufacturingDate { get; set; }
        public string? DateOfDispatch { get; set; }
        public string? DateOfCommissioning { get; set; }
        public string? ProductFailureDate { get; set; }


        public string? CustomerName { get; set; }
        public string? ContactPerson { get; set; }
        public string? PrimaryMobileNo { get; set; }
        public string? EmailId { get; set; }
        public string? AltContactNo { get; set; }
        public string? SiteAddress { get; set; }


        // public string? DefectName { get; set; }
        public string? RequestDate { get; set; }
        public string? ASCName { get; set; }
        public string? ASMName { get; set; }
        public string? Distance { get; set; }
        public string? ServiceTicketNumber { get; set; }
        public string? TicketStatusName { get; set; }
        public string? SourceName { get; set; }
        public string? SourceTypeName { get; set; }
        public string? CallModeName { get; set; }
        public string? BranchName { get; set; }
        public string? WarrantyDateStatus { get; set; }
        public string? InvoiceDateStatus { get; set; }

        public string? ActualStatusOfComplaint { get; set; }
        public string? PendingWithWhom { get; set; }
        public string? ActionRequired { get; set; }
        public string? PendencyRemarks { get; set; }
        public string? SpecialApprovalStatus { get; set; }
        public string? PendencyReasonUpdatedOn { get; set; }
        public string? BusinessCall { get; set; }



        //----
        public string? LoggedDate { get; set; }
        public string? LoggedTime { get; set; }
        public string? LoggedMonth { get; set; }
        public string? RegionName { get; set; }
        public string? DefectName { get; set; }
        public string? DefectCategoryName { get; set; }
        public string? PinCode { get; set; }
        public string? CityName { get; set; }
        public string? StateName { get; set; }
        public string? Quantity { get; set; }
        public string? Distanc { get; set; }
        public string? ComplainType { get; set; }
        public string? TechnicianName { get; set; }
        public string? STSubStatusName { get; set; }
        public string? ClosureStatus { get; set; }

        public string? ComplaintCurrentStatus { get; set; }
        public string? ReplacementTagApplied { get; set; }
        public string? ClosureRemarks { get; set; }
        public string? LatestComment { get; set; }
        public string? WebClosureDate { get; set; }
        public string? ClosureTime { get; set; }
        public string? ClosureTat { get; set; }
        public string? ComplaintAgedays { get; set; }
        public string? InternalEmployeeDrivesAndLRM { get; set; }
        public string? ModeOfReceipt { get; set; }
        public string? FileCountAttached { get; set; }
        public string? DealerName { get; set; }
        public string? OEMName { get; set; }
        public string? ClaimStatus { get; set; }

        public string? IBNNumber { get; set; }

        public string? ApplicationType { get; set; }
        public string? ServiceCost { get; set; }
        public string? SpecialApprovalCost { get; set; }
        public string? MaterialCost { get; set; }
        public string? TotalCost { get; set; }

        public string? VendorName { get; set; }

        public string? PartConsumptionCost { get; set; }

        public string? DistanceType { get; set; }
        public string? NatureOfComplaint { get; set; }

        public string? UserType { get; set; }
        public string? ReplacementTag { get; set; }
        public string? HappyCode { get; set; }
    }

    public class AscServiceTicketInfoComplaintReportEntity
    {
        public string? RegionName { get; set; }
        public string? BranchName { get; set; }
        public string? ServiceTicketNumber { get; set; }
        public string? LoggedDate { get; set; }
        public string? LoggedTime { get; set; }
        public string? LoggedMonth { get; set; }
        public string? Distanc { get; set; }
        public string? DistanceType { get; set; }
        public string? NatureOfComplaint { get; set; }
        public string? CustomerName { get; set; }
        public string? ContactPerson { get; set; }
        public string? SiteAddress { get; set; }
        public string? CityName { get; set; }
        public string? StateName { get; set; }
        public string? PinCode { get; set; }
        public string? PrimaryMobileNo { get; set; }
        public string? AltContactNo { get; set; }
        public string? Quantity { get; set; }
        public string? ComplainType { get; set; }
        public string? WarrantyDateStatus { get; set; }
        public string? BusinessCall { get; set; }
        public string? DivisionName { get; set; }
        public string? ProductLineName { get; set; }
        public string? ProductGroupName { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? SerialNo { get; set; }
        public string? ASCName { get; set; }
        public string? TechnicianName { get; set; }
        public string? STSubStatusName { get; set; }
        public string? ClosureStatus { get; set; }
        public string? ComplaintCurrentStatus { get; set; }
        public string? ReplacementTagApplied { get; set; }
        public string? ClosureRemarks { get; set; }
        public string? LatestComment { get; set; }
        public string? ComplaintAgedays { get; set; }
        public string? ClosureTat { get; set; }
        public string? ClosureTime { get; set; }
        public string? InternalEmployeeDrivesAndLRM { get; set; }
        public string? ModeOfReceipt { get; set; }
        public string? SourceName { get; set; }
        public string? CallModeName { get; set; }
        public string? FileCountAttached { get; set; }
        public string? OEMName { get; set; }
        public string? DealerName { get; set; }
        public string? PendencyRemarks { get; set; }
        public string? PendencyReasonUpdatedOn { get; set; }
        public string? ActualStatusOfComplaint { get; set; }
        public string? PendingWithWhom { get; set; }
        public string? ActionRequired { get; set; }
        public string? ClaimStatus { get; set; }
        public string? IBNNumber { get; set; }
        public string? DefectName { get; set; }
        public string? DefectCategoryName { get; set; }
        public string? TotalRows { get; set; }
        public string? ServiceRequestType { get; set; }
        public string? ASMName { get; set; }
        public string? ClousureDate { get; set; }
        public string? InvoiceDateStatus { get; set; }
        public string? IBN { get; set; }
        public string? PurchaseFrom { get; set; }
        public string? WebClosureDate { get; set; }
    }



    public class ClaimApprovalTATReportEntity
    {
        public string? TotalRows { get; set; }
        public string? Region { get; set; }
        public string? Branch { get; set; }
        public string? ServiceRequestNumber { get; set; }
        public string? TicketCreationDate { get; set; }
        public string? TicketClosureDate { get; set; }
        public string? ClaimGenerationDate { get; set; }
        public string? PartnerName { get; set; }



        public string? Division { get; set; }
        public string? ProductLine { get; set; }
        public string? Activity { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductSerialNo { get; set; }
        public string? Parameter { get; set; }
        public string? PossibleValue { get; set; }
        public string? TotalAmount { get; set; }

        public string? ClaimRemarkbyASC { get; set; }
        public string? ASMName { get; set; }
        public string? ClaimStatusASM { get; set; }
        public string? ASMClaimApprovalDate { get; set; }
        public string? ASMApprovedRemarks { get; set; }
        public string? DaysTakenbyASM { get; set; }
        public string? RSMName { get; set; }

        public string? ClaimStatusRSM { get; set; }
        public string? RSMClaimApprovalDate { get; set; }
        public string? RSMApprovedRemarks { get; set; }
        public string? DaysTakenbyRSM { get; set; }
        public string? IBNNo { get; set; }
        public string? IBNGenerationDate { get; set; }

    }



    public class AscServiceTicketInfoDefetReportEntity
    {
        public string? RegionName { get; set; }
        public string? BranchName { get; set; }
        public string? ServiceTicketNumber { get; set; }
        public string? Distanc { get; set; }
        public string? DistanceType { get; set; }
        public string? LoggedDate { get; set; }
        public string? LoggedMonth { get; set; }
        public string? LoggedTime { get; set; }
        public string? ComplaintAgedays { get; set; }
        public string? ClosureTat { get; set; }

        public string? WebClosureDate { get; set; }
        public string? ASCName { get; set; }


        public string? BusinessCall { get; set; }

        public string? ApplicationType { get; set; }

        public string? DivisionName { get; set; }
        public string? ProductLineName { get; set; }
        public string? ProductGroupName { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? SerialNo { get; set; }
        public string? BatchNo { get; set; }
        public string? InvoiceNo { get; set; }
        public string? InvoiceDate { get; set; }

        public string? InvoiceDateStatus { get; set; }
        public string? WarrantyDateStatus { get; set; }

        public string? CustomerName { get; set; }
        public string? ContactPerson { get; set; }
        public string? SiteAddress { get; set; }
        public string? CityName { get; set; }
        public string? StateName { get; set; }
        public string? PinCode { get; set; }
        public string? PrimaryMobileNo { get; set; }
        public string? NatureOfComplaint { get; set; }

        public string? ClosureStstaus { get; set; }
        public string? ClosureRemarks { get; set; }

        public string? NoOfdefect { get; set; }

        public string? ServiceCost { get; set; }

        public string? SpecialApprovalCost { get; set; }
        public string? MaterialCost { get; set; }
        public string? TotalCost { get; set; }

        public string? PartConsumptionCost { get; set; }
        public string? OEMName { get; set; }

        public string? DealerName { get; set; }
        public string? VendorName { get; set; }
        public string? ComplainType { get; set; }
        public string? ReplacementTagApplied { get; set; }

        //public string? DefectCategoryName { get; set; }

        //public string? DefectName { get; set; }

        public string? DefectName1 { get; set; }
        public string? DefectName2 { get; set; }
        public string? DefectName3 { get; set; }
        public string? DefectName4 { get; set; }
        public string? DefectCategoryName1 { get; set; }
        public string? DefectCategoryName2 { get; set; }
        public string? DefectCategoryName3 { get; set; }
        public string? DefectCategoryName4 { get; set; }

        public string? TotalRows { get; set; }
        public string? TechnicianName { get; set; }
        public string? IBNNumber { get; set; }
    }


    public class AscServiceTicketCustomerReportEntity
    {
        public int? AscCustomerContactedId { get; set; }
        public int? ServiceTicketId { get; set; }
        public string? ComplainType { get; set; }
        public string? ContactDate { get; set; }
        public string? Remarks { get; set; }
        public string? STSubStatusName { get; set; }
        public string? ServiceTicketStatusName { get; set; }
        public string? TechnicianName { get; set; }
        public string? ApprovedName { get; set; }
        public string? ApprovedDate { get; set; }
        public string? ApprovedComments { get; set; }
        public string? RejectName { get; set; }
        public string? RejectedDate { get; set; }
        public string? RejectedComments { get; set; }
        public string? CreatedUser { get; set; }
        public string? AppointmentTime { get; set; }
        public string? CreatedOn { get; set; }
        public string? VisitDate { get; set; }


    }








    public class ASCSiteVisitAndProductReceivedEntity : BaseEntity
    {
        public int AscActivitiesId { get; set; }
        public string? ServiceTicketId { get; set; }
        public string? ComplainType { get; set; }
        public string? Date { get; set; }
        public string? SubStatusName { get; set; }

        public string? StatusName { get; set; }
        public string? ActivityName { get; set; }
        public string? IsSubmited { get; set; }
        public string? Remarks { get; set; }

    }






    public class AscServiceTicketCustomerDisplayEntity
    {
        public int AscCustomerContactedId { get; set; }
        public string? ServiceTicketId { get; set; }
        public string? TypeService { get; set; }
        public string? ContactDate { get; set; }
        public string? SerialNo { get; set; }
        public string? ProductCode { get; set; }
        public string? InvoiceDate { get; set; }
        public string? InvoiceNo { get; set; }
        public string? Remarks { get; set; }
        public string? ServiceRequestStatusId { get; set; }
        public string? ServiceRequestSubStatusId { get; set; }
        public string? InvoiceDocFile { get; set; }
        public string? ServiceTicketStatus { get; set; }
        //  public List<AscActivitiesEntity> AscActivitiesList { get; set; }
    }


    public class ASCSiteVisitAndProductReceivedDisplayEntity
    {
        public int ASCSiteVisitAndProductReceivedId { get; set; }
        public string? ServiceTicketId { get; set; }
        public string? TypeService { get; set; }
        public string? ServiceDate { get; set; }
        public string? AssignTechician { get; set; }
        public string? ProductReceivedDate { get; set; }
        public string? ProductReceviedASCDate { get; set; }

        public string? ProductReceviedType { get; set; }
        public string? Remarks { get; set; }

        // public List<AscActivitiesEntity> AscActivitiesList { get; set; }


    }


    public class ServiceTicketTaskDetailsEntity
    {
        public string? ServiceTicketId { get; set; }
        public string? ServiceTicketNo { get; set; }
        public List<AscServiceTicketCustomerEntity> AscServiceTicketCustomer { get; set; }
        public List<ASCSiteVisitAndProductReceivedEntity> ASCSiteVisitAndProductReceived { get; set; }

        public List<AscServiceTicketFirDisplayEntity> AscServiceTicketFirlist { get; set; }
        //public List<ServiceTicketPendencyReasonHistoryEntity> AscServiceTicketPendencyHistory { get; set; }

    }





    public class ServiceTicketTaskDetailsReportEntity
    {
        public string? ServiceTicketId { get; set; }
        public string? ServiceTicketNo { get; set; }

        public List<AscServiceTicketInfoReportEntity> ServiceTicketInfo { get; set; }
        public List<AscServiceTicketActivitiesEntity> ServiceTicketActivities { get; set; }
        public List<AscServiceTicketCustomerReportEntity> AscServiceTicketCustomer { get; set; }
        public List<ASCSiteVisitAndProductReceivedEntity> ASCSiteVisitAndProductReceived { get; set; }
        public List<AscServiceTicketFirDisplayEntity> AscServiceTicketFirlist { get; set; }
        public List<ServiceTicketPendencyReasonHistoryEntity> AscServiceTicketPendencyHistory { get; set; }

    }


    public class ServiceTicketDefectReportEntity
    {

        public List<AscServiceTicketInfoDefetReportEntity> AscServiceTicketlist { get; set; }
        public List<AscDefectlistEntity> AscDefectlist { get; set; }



    }


    public class AscDefectlistEntity
    {
        public string? DivisionName { get; set; }
        public string? ProductLineName { get; set; }
        public string? DefectCategoryName { get; set; }
        public string? DefectDesc { get; set; }
        public string? DefectCount { get; set; }


    }

    public class AscServiceTicketActivitiesEntity
    {
        public string? UserName { get; set; }
        public string? StatusName { get; set; }
        public string? CreateDate { get; set; }
        public string? Remarks { get; set; }
        public string? TypeOfSteps { get; set; }


    }
    public class AscActivitiesEntity
    {
        public string? AscActivitiesName { get; set; }
        public string? AscActivitiesId { get; set; }
    }

    public class ServiceTicketPendencyReasonEntity : BaseEntity
    {
        public int PendencyReasonId { get; set; }
        public int ServiceTicketId { get; set; }
        public int ActualStatusOfComplaintId { get; set; }
        public int PendingWithWhomId { get; set; }
        public int ActionRequiredId { get; set; }
        public string? PendencyRemarks { get; set; }
        public bool IsActive { get; set; }

    }

    public class ServiceTicketPendencyReasonDisplayEntity
    {
        public int PendencyReasonId { get; set; }
        public int ServiceTicketId { get; set; }
        public string? ActualStatusOfComplaint { get; set; }
        public string? PendingWithWhom { get; set; }
        public string? ActionRequired { get; set; }
        public string? PendencyRemarks { get; set; }
        public string? PendencyReasonUpdatedOn { get; set; }
        public bool IsActive { get; set; }

    }

    public class PendingWithWhomEntity
    {
        public int PendingWithWhomId { get; set; }
        public string? PendingWithWhomName { get; set; }

    }

    public class PendencyActionRequiredEntity
    {
        public int ActionRequiredId { get; set; }
        public string? ActionRequired { get; set; }

    }

    public class DurationTicketTatDashboardEntity
    {
        public string DivName { get; set; }
        public string? DivCode { get; set; }
        public int? TotalTicket { get; set; }
        public decimal? OneDay { get; set; }
        public decimal? ThreeDay { get; set; }
        public decimal? Delayed { get; set; }
        public decimal? Total { get; set; }
    }
    public class ServiceTicketPendencyReasonHistoryEntity
    {

        public string? ActualStatusOfComplaint { get; set; }
        public string? PendingWithWhom { get; set; }
        public string? PendencyReasonUpdatedOn { get; set; }
        public string? PendencyRemarks { get; set; }

    }

    public class ComplaintCancelReportEntity
    {
        public string? TotalRows { get; set; }
        public string? RegionName { get; set; }
        public string? BranchName { get; set; }
        public string? ServiceTicketNumber { get; set; }
        public string? DivisionName { get; set; }
        public string? CGServiceEngineer { get; set; }
        public string? AscName { get; set; }
        public string? TicketCreationDate { get; set; }


        public string? RequestCancellationDate { get; set; }
        public string? RequestCancellationTime { get; set; }
        public string? AgeOfPendency { get; set; }
        public string? Status { get; set; }
        public string? ActionTakenASM { get; set; }
        public string? ActionDate { get; set; }

        public string? ActionTime { get; set; }
        public string? ActionAge { get; set; }
        public string? CancellationStatus { get; set; }
    }



    //----------------------------------  RepeatedTickets

    public class RepeatedTicketsReportEntity
    {

        public List<RepeatedTicketsCallsEntity> RepeatedTicketsCallslist { get; set; }
        public List<RepeatedTicketsCallsSummaryEntity> RepeatedTicketsCallsSummarylist { get; set; }



    }

    public class RepeatedTicketsCallsSummaryEntity
    {
        public string? TotalRows { get; set; }
        public string? Region { get; set; }
        public string? Branch { get; set; }
        public string? ProductDivision { get; set; }
        public string? ProductLine { get; set; }
        public string? ProductGroup { get; set; }
        public string? ProductCode { get; set; }
        public string? SerialNo { get; set; }
        public string? RepeatedCalls { get; set; }

    }


    public class RepeatedTicketsCallsEntity
    {

        public string? TotalRows { get; set; }
        public string? Region { get; set; }
        public string? Branch { get; set; }
        public string? ProductDivision { get; set; }
        public string? ProductLine { get; set; }
        public string? ProductGroup { get; set; }
        public string? ProductCode { get; set; }
        public string? SerialNo { get; set; }
        public string? RepeatedCalls { get; set; }
        public string? CustomerMobileNumber { get; set; }
        public string? TicketNo { get; set; }
        public string? TicketCreationDate { get; set; }
        public string? TicketClosureDate { get; set; }
        public string? AssignedASC { get; set; }
        public string? MobileNumberDiscripancy { get; set; }

    }


}
