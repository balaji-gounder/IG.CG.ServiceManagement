using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Domain.Entities
{
    public class IBNManagmentEntity
    {
        public string? TotalRows { get; set; }
        public string? RegionName { get; set; }
        public string? BranchName { get; set; }
        public string? ServiceTicketNumber { get; set; }
        public string? TicketLoggedDate { get; set; }
        public string? TicketLoggedTime { get; set; }
        public string? WebClosureDate { get; set; }
        public int ComplaintAgeDays { get; set; }
        public string? DivisionName { get; set; }
        public string? ProductLineName { get; set; }
        public string? ProductCode { get; set; }
        public string? SerialNo { get; set; }
        public string? BusinessCall { get; set; }
        public string? WarrantyStatusAsPerBatch { get; set; }
        public string? WarrantyStatusAsPerInvoiceDate { get; set; }
        public string? ClosureStatus { get; set; }
        public string? ClosureRemarks { get; set; }
        public string? ASCName { get; set; }
        public decimal ServiceCost { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal SpecialApprovalCost { get; set; }
        public decimal TotalCost { get; set; }
        public string? IBNNumber { get; set; }
        public string? IBNGeneratedDate { get; set; }
        public decimal IBMAmount { get; set; }
        public string? IBNMonth { get; set; }
        public string? ASMName { get; set; }
        public string? ASMClaimApprovedDate { get; set; }
        public string? RSMName { get; set; }
        public string? RSMClaimApprovedDate { get; set; }
        public string? NoOfdefect { get; set; }
        public string? DefectName1 { get; set; }
        public string? DefectCategoryName1 { get; set; }
        public string? DefectName2 { get; set; }
        public string? DefectCategoryName2 { get; set; }
        public string? DefectName3 { get; set; }
        public string? DefectCategoryName3 { get; set; }
        public string? DefectName4 { get; set; }
        public string? DefectCategoryName4 { get; set; }
        public string? PartConsumptionCost { get; set; }
    }
}
