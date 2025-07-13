using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Application.Models
{
    public class ActivityDisplayModel : ActivityModel
    {
        public string? DivisionName { get; set; }
        public string? ProductLineName { get; set; }
        public string? ActivityType { get; set; }
    }
}
