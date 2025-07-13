using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Domain.Entities
{
    public class ProductDeviationDisplayEntity : ProductDeviationEntity
    {
        public string? DivisionName { get; set; }
        public string? ProductDescription { get; set; }
        public string? RoleName { get; set; }
    }
}
