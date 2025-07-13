using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Application.Models
{
    public class DashboardFilter
    {
        public string? vUserID { get; set; } = string.Empty;
        public string? FromDate { get; set; } = string.Empty;
        public string? ToDate { get; set; } = string.Empty;
        public string? DivisionCode { get; set; } = string.Empty;
        public string? RegionCode { get; set; } = string.Empty;
        public string? BranchCode { get; set; } = string.Empty;
        public string? ASC { get; set; } = string.Empty;
        public string? ProductLineCode { get; set; } = string.Empty;

    }
}
