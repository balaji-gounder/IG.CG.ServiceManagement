using Microsoft.AspNetCore.Http;

namespace IG.CG.Core.Domain.Entities
{
    public class AscServiceTicketFirDisplayEntity
    {
        public int AscServiceTicketFIRId { get; set; }
        public int ServiceTicketId { get; set; }
        public string? SerialNo { get; set; }
        public string? ProductCode { get; set; }
        public string? BatchCode { get; set; }

        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductGroupName { get; set; }
        public string? DivisionName { get; set; }
        public string? ProductLineName { get; set; }
        public string? InvoiceNo { get; set; }
        public string? InvoiceDate { get; set; }
        public string? FailureObservation { get; set; }
        public string? DetailsOfWorkDone { get; set; }
        public string? ReplacementTagApplied { get; set; }
        public string? ClosureStatusName { get; set; }
        public string? TypeOfWorkDoneId { get; set; }
        public string? ReplacementTagFile { get; set; }
        public string? Frame { get; set; }
        public string? Kva { get; set; }
        public string? Hp { get; set; }
        public string? warrantyDate { get; set; }
        public string? InvoiceFile { get; set; }
        public string? TypeOfApplication { get; set; }
        public string? NoOfHours { get; set; }
        public List<FIRDefectListDisplayEntity>? DefectList { get; set; }
        public List<SpareDetailsDisplayEntity>? Sparelist { get; set; }

        //public List<FIRDocumentListModel>? DocumentList { get; set; }
        public bool IsActive { get; set; }

        public string? ManufacturingDate { get; set; }
        public string? DateOfDispatch { get; set; }
        public string? DateOfCommissioning { get; set; }
        public string? FailureReportedDate { get; set; }
        public string? ProductFailureDate { get; set; }
        public string? FrameSizeId { get; set; }
        public string? NoOfVisit { get; set; }

    }

    public class SpareDetailsDisplayEntity
    {
        public string SpareName { get; set; }
        public string quantity { get; set; }
        public string serialNumbers { get; set; }
        public string Remarks { get; set; }

    }

    public class FIRDefectListDisplayEntity
    {
        public string FIRDefectId { get; set; }
        public string defectCategoryItem { get; set; }
        public string defectItem { get; set; }

    }

    public class FIRDocumentListDisplayEntity
    {
        public string? Label { get; set; }
        public IFormFile File { get; set; }
        public bool IsMandatory { get; set; }

    }
}
