
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Models
{
    public class UserDisplayModel : UserModel
    {
        public string? NoOfBranch { get; set; }
        public string? NoOfDivision { get; set; }
        public string? NoOfProductLine { get; set; }
        public string? RoleName { get; set; }
        public string? UserTypeName { get; set; }
        public string? TotalRows { get; set; }
        public List<ParaTypeEntity> DivisionCodeList { get; set; }
        public List<ParaTypeEntity> ProductLineCodeList { get; set; }
        public List<ParaTypeEntity> BranchCodeList { get; set; }
    }
}
