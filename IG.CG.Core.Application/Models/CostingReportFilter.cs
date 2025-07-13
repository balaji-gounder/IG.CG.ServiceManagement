using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Application.Models
{
    public class CostingReportFilter:BaseFilter
    {
        public string? RegionCode { get; set; } = string.Empty;
        public string? BranchCode { get; set; } = string.Empty;
        public string? ProductDivisionCode { get; set; } = string.Empty;
        public string? ProductLine { get; set; } = string.Empty;
        public string? ASC { get; set; } = string.Empty;
        public string? FromDate { get; set; } = string.Empty;
        public string? ToDate { get; set; } = string.Empty;
        public string? UserID { get; set; } = string.Empty;
    }
}
