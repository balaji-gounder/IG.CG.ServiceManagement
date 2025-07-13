using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Domain.Entities
{
    public class UserAdditionalRightsEntity : BaseEntity
    {
        public int UAddAutoId { get; set; }
        public string? UserCode { get; set; }
        public string? DivisionCode { get; set; }
        public string? PLCode { get; set; }
        public string? BranchCode { get; set; }
        public bool IsActive { get; set; }
    }
}
