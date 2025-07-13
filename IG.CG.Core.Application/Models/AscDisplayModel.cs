using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Models
{
    public class AscDisplayModel : AscModel
    {
        public string? PinCode { get; set; }
        public string? StateName { get; set; }
        public string? CityName { get; set; }
        public string? Address { get; set; }
        public string? DocumentPath { get; set; }

        public int NoOfProductLine { get; set; }
        public int NoOfDivision { get; set; }
        public int NoOfBranch { get; set; }
        public string? TotalRows { get; set; }

        public List<ParaTypeModel> DivisionCodeList { get; set; }
        public List<ParaTypeModel> ProductLineCodeList { get; set; }

        public List<ParaTypeEntity> BranchCodeList { get; set; }

        public string? WorkFlowStatus { get; set; }

        public string? ApprovalRoleCode { get; set; }

        public string? BranchName { get; set; }
        public string? RegionName { get; set; }
        public int WFAutoId { get; set; }
    }

    public class AscListModel
    {
        public string? AscId { get; set; }
        public string? AscCode { get; set; }
        public string? Name { get; set; }

    }

    public class AscWiseProductLineModel
    {
        public string? ProductLineCode { get; set; }
        public string? ProductLineName { get; set; }

    }

    public class UserWiseDivisionModel
    {
        public string? DivisionCode { get; set; }
        public string? DivisionName { get; set; }

    }
    public class DivisionWiseProductLineModel
    {
        public string? ProductLineCode { get; set; }
        public string? ProductLineName { get; set; }

    }
}
