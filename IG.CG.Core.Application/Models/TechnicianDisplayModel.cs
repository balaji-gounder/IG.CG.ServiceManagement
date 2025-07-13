
namespace IG.CG.Core.Application.Models
{
    public class TechnicianDisplayModel : TechnicianModel
    {
        public string? NoOfSkill { get; set; }

        public string? NoOfProductLine { get; set; }
        public string? NoOfDivision { get; set; }
        public string? DivisionName { get; set; }
        public string? ProductLineName { get; set; }
        public string? AscName { get; set; }
        public string? TotalRows { get; set; }

        public List<ParaTypeModel> DivisionCodeList { get; set; }
        public List<ParaTypeModel> ProductLineCodeList { get; set; }
        public List<ParaTypeModel> ProductGroupCodeList { get; set; }
        public List<ParaTypeModel> SkillList { get; set; }
    }
}
