using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Application.Models
{
    public class UniversalSearchModel
    {
        public string? serviceRequestNo { get; set; }
        public string? requestDate { get; set; }
        public string? branch { get; set; }
        public string? ascName { get; set; }
        public string? division { get; set; }
        public string? productLine { get; set; }
        public string? natureOfComplaint { get; set; }
        public string? customerFirmName { get; set; }
        public string? siteLocation { get; set; }
        public string? customerContactNo { get; set; }
        public string? complaintStatus { get; set; }
        public string? closureDate { get; set; }
        public string? closureTime { get; set; }
        public string? latestClosureRemarks { get; set; }
    }
}
