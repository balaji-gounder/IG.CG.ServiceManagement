using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Domain.Entities
{
    public class PartConsumptionReportEntity
    {
        public string? TotalRows { get; set; }
        public string? Region { get; set; }
        public string? Branch { get; set; }
        public string? TicketMonth { get; set; }
        public string? TicketNumber { get; set; }

        public string? LoggedDate { get; set; }
        public string? ClosedDate { get; set; }

        public string? WarrantyStatus { get; set; }

        public string? Natureofcomplaint { get; set; }

        public string? ProductDivisionDesc { get; set; }
        public string? ProductLineDesc { get; set; }
        public string? ProductGroup { get; set; }
        public string? ProductCode { get; set; }

        public string? ProductSerialNumber { get; set; }

        public string? AuthorisedServiceContractor { get; set; }

        public string? ComplaintAge { get; set; }
        public string? CustomerFirstName { get; set; }

        public string? CustomerContactNo { get; set; }

        public string? ClosureStatus { get; set; }
        public string? ClosureRemarks { get; set; }
        public string? SpareCode { get; set; }
        public string? SpareDescription { get; set; }

        public string? SpareSerialNumber { get; set; }
        public string? Quantity { get; set; }
        public string? Rate { get; set; }
        public string? Total { get; set; }
    }
}
