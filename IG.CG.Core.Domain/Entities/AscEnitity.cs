namespace IG.CG.Core.Domain.Entities
{

    public class AscEntity : BaseEntity
    {
        public int AscId { get; set; }

        public string? AscCode { get; set; }

        public string? CustCode { get; set; }

        public string? Name { get; set; }

        public string? EmailId { get; set; }

        public string? MobileNo { get; set; }

        public string? ContactPersonName { get; set; }

        public string? AadharNo { get; set; }

        public bool IsGSTApplicable { get; set; }

        public string? PanNo { get; set; }

        public string? GstNo { get; set; }

        public string AgreementStartDate { get; set; }

        public string AgreementEndDate { get; set; }

        public decimal SecurityDeposit { get; set; }

        public string HYAuditDate { get; set; }

        public int NoOfTechnicians { get; set; }

        public int AvailableMachines { get; set; }

        public int DocumentType { get; set; }

        public int StateId { get; set; }

        public int CityId { get; set; }

        public int PinId { get; set; }

        public string? AscAddress { get; set; }

        public string? DocumentPath { get; set; }

        public bool IsActive { get; set; }

        public string? ProductLineCode { get; set; }
        public string? DivisionCode { get; set; }
        public string? BranchCode { get; set; }
        public string? TypeOfTicketTobeHandeled { get; set; }

    }
}
