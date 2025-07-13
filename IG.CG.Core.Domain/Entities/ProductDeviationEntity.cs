using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Domain.Entities
{
    public class ProductDeviationEntity : BaseEntity
    {
        public int ProdDevAutoId { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductCode { get; set; }
        public string? RoleCode { get; set; }
        public int NoOfDevMonth { get; set; }
        public bool IsActive { get; set; }
    }
}
