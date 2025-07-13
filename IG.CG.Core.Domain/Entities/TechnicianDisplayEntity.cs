

namespace IG.CG.Core.Domain.Entities
{
    public class TechnicianDisplayEntity : TechnicianEntity
    {

        public string? NoOfSkill { get; set; }
        public string? NoOfProductLine { get; set; }
        public string? NoOfDivision { get; set; }
        public List<ParaTypeEntity> DivisionCodeList { get; set; }
        public List<ParaTypeEntity> ProductLineCodeList { get; set; }
        public List<ParaTypeEntity> ProductGroupCodeList { get; set; }
        public List<ParaTypeEntity> SkillList { get; set; }
    }
}
