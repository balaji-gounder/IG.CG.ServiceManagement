using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Domain.Entities
{
    public class DefectCatDispEntity:DefectCategoryEntity
    {
        public string? DivisionName { get; set; }
        public string? ProductLineName { get; set; }
        public string? ProductGroupName { get; set; }
    }
}
