using Microsoft.AspNetCore.Http;

namespace IG.CG.Core.Application.Models
{
    public class AsmServiceTicketCancellationApprovalModel
    {
        public int AscCustomerContactedId { get; set; }
        public int ServiceTicketId { get; set; }
        public string? ApprovedBy { get; set; }
        public string? ApprovedComments { get; set; }
        public string? ApprovedDate { get; set; }

    }

    public class AsmServiceTicketCancellationRejectedModel
    {
        public int AscCustomerContactedId { get; set; }
        public int ServiceTicketId { get; set; }
        public string? RejectedBy { get; set; }
        public string? RejectedComments { get; set; }
        public string? RejectedDate { get; set; }

    }

    public class AscListByTicketCountModel
    {
        public string? AscCode { get; set; }
        public string? AscTicketCount { get; set; }

    }

    public class AscServiceTicketFirModel
    {
        public int AscServiceTicketFIRId { get; set; }
        public int ServiceTicketId { get; set; }
        public string? SerialNo { get; set; }
        public string? ProductCode { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }
        public string? InvoiceNo { get; set; }
        public string? InvoiceDate { get; set; }
        public string? FailureObservation { get; set; }
        public string? DetailsOfWorkDone { get; set; }
        public string? ReplacementTagApplied { get; set; }
        public int? ClosureStatusId { get; set; }
        public string? TypeOfWorkDoneId { get; set; }
        public string? ReplacementTagFile { get; set; }

        public string? TypeOfApplication { get; set; }
        public string? NoOfHours { get; set; }
        public string? Frame { get; set; }
        public string? Kva { get; set; }
        public string? Hp { get; set; }
        public string? warrantyDate { get; set; }
        public string? InvoiceFile { get; set; }
        public string? FrameSizeId { get; set; }
        public List<FIRDefectListModel>? DefectList { get; set; }
        public List<SpareDetailsModel>? Sparelist { get; set; }

        //public List<FIRDocumentListModel>? DocumentList { get; set; }
        public bool IsActive { get; set; }
        //public List<IFormFile>? DocumentWithType { get; set; }

        public string? TypeOfFrame { get; set; }
        public string? TypeOfKVA { get; set; }
        public string? NoOfVisit { get; set; }
    }



    public class AscServiceTicketFirDefectModel
    {

        public string? FailureObservation { get; set; }
        public int ServiceTicketId { get; set; }
        public List<FIRDefectListModel>? DefectList { get; set; }

    }


    public class AscServiceTicketFirDefectOneModel
    {
        public int ServiceTicketId { get; set; }
        public string? FailureObservation { get; set; }
        public int DefectCategoryId { get; set; }
        public int DefectId { get; set; }

    }



    public class AscServiceTicketProductFirModel
    {
        public int AscServiceTicketFIRId { get; set; }
        public int ServiceTicketId { get; set; }
        public string? SerialNo { get; set; }
        public string? ProductCode { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }
        public string? InvoiceNo { get; set; }
        public string? InvoiceDate { get; set; }
        public string? TypeOfApplication { get; set; }
        public string? NoOfHours { get; set; }
        public string? Frame { get; set; }
        public string? Kva { get; set; }
        public string? Hp { get; set; }
        public string? warrantyDate { get; set; }

        public string? ManufacturingDate { get; set; }
        public string? DateOfDispatch { get; set; }
        public string? DateOfCommissioning { get; set; }
        public string? FailureReportedDate { get; set; }
        public string? ProductFailureDate { get; set; }
        public string? FrameSizeId { get; set; }
        public List<IFormFile>? InvoiceFile { get; set; }
        public bool IsActive { get; set; }


    }



    public class FIRDefectListModel
    {
        public int DefectCategoryId { get; set; }
        public int DefectId { get; set; }

    }

    public class SpareDetailsModel
    {
        public int Spareid { get; set; }
        public int quantity { get; set; }
        public string serialNumbers { get; set; }
        public string Remarks { get; set; }
    }



    public class FIRDocumentListModel
    {
        public string? FIRDocumentId { get; set; }
        public string? AscServiceTicketFIRId { get; set; }
        public string? ServiceTicketId { get; set; }
        public string? DocumentType { get; set; }
        public IFormFile? DocumentPath { get; set; }
        public bool IsMandatory { get; set; }

    }



    public class FIRDocumentListDisplaynModel
    {
        public string? FIRDocumentId { get; set; }
        public string? AscServiceTicketFIRId { get; set; }
        public string? ServiceTicketId { get; set; }
        public string? DocumentName { get; set; }
        public string? CreateOn { get; set; }
        public int? IsMandatory { get; set; }
        public string? DocPath { get; set; }

    }


    public class FIRDocumentWithTypeModel
    {

        public string? AscServiceTicketFIRId { get; set; }
        public string? DocumentId { get; set; }
        public string? DocumentName { get; set; }
        public string? ServiceTicketId { get; set; }
        public List<IFormFile>? DocumentWithType { get; set; }
        public bool IsMandatory { get; set; }
        public string? DocPath { get; set; }
    }

    public class CancellationRemarksModel
    {
        public int ServiceTicketId { get; set; }
        public int AscCustomerContactedId { get; set; }
        public string? Remarks { get; set; }

    }

    public class InternalEngineerASMListModel
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }

    }
}
