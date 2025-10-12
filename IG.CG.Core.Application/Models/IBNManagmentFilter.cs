using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Application.Models
{
    public class IBNManagmentFilter:BaseFilter
    {
        public string? Region { get; set; } = string.Empty;
        public string? Branch { get; set; } = string.Empty;
        public string? DivCode { get; set; } = string.Empty;
        public string? ProductLineCode { get; set; } = string.Empty;
        public string? IBNNumber { get; set; } = string.Empty;
        public string? BusinessCallID { get; set; } = string.Empty;
        public string? FromDate { get; set; } = string.Empty;
        public string? ToDate { get; set; } = string.Empty;
    }
}
