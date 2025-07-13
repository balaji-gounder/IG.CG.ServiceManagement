using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Domain.Entities
{
    public class CostingReportEntity
    {
        public string? TotalRows { get; set; }
        public string? Region { get; set; }
        public string? Branch { get; set; }
        public string? ProductDivision { get; set; }
        public string? ProductLine { get; set; }
        public string? ProductGroup { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductDescription { get; set; }
        public string? TicketMonth { get; set; }
        public string? AuthorisedServiceContractor { get; set; }
        public string? TicketNumber { get; set; }
        public string? TicketDate { get; set; }
        public string? FinalClaimApprovedDate { get; set; }
        public string? DistanceType { get; set; }
        public string? RepairType { get; set; }
        public string? ServiceCharges { get; set; }
        public string? Conveyance { get; set; }
        public string? LodgingDAFood { get; set; }
        public string? Rewinding { get; set; }

        public string? RepairCharges { get; set; }
        public string? SpecialApprovalCost { get; set; }
        public string? SundryCharges { get; set; }
        public string? TotalAmount { get; set; }
        public string? IBNNO { get; set; }
        public string? IBNGeneratedDate { get; set; }
    }
}
