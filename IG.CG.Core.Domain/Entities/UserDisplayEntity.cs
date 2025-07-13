

namespace IG.CG.Core.Domain.Entities
{
    public class UserDisplayEntity : UserEntity
    {

        public string? NoOfBranch { get; set; }
        public string? NoOfDivision { get; set; }
        public string? NoOfProductLine { get; set; }
        public string? RoleName { get; set; }
        public string? UserTypeName { get; set; }


        public List<ParaTypeEntity> DivisionCodeList { get; set; }
        public List<ParaTypeEntity> ProductLineCodeList { get; set; }
        public List<ParaTypeEntity> BranchCodeList { get; set; }
    }
}
