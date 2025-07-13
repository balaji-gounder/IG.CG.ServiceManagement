namespace IG.CG.Core.Domain.Entities
{

    public class AscDisplayEntity : AscEntity
    {

        public string? Pincode { get; set; }

        public string? StateName { get; set; }
        public string? Address { get; set; }
        public string? CityName { get; set; }

        public int NoOfProductLine { get; set; }
        public int NoOfDivision { get; set; }
        public int NoOfBranch { get; set; }
        public string? WorkFlowStatus { get; set; }

        public int WFAutoId { get; set; }
        public string? BranchName { get; set; }
        public string? RegionName { get; set; }
        public string? ApprovalRoleCode { get; set; }
        public List<ParaTypeEntity> DivisionCodeList { get; set; }
        public List<ParaTypeEntity> ProductLineCodeList { get; set; }
        public List<ParaTypeEntity> BranchCodeList { get; set; }
    }
    public class AscListEntity
    {
        public string? AscId { get; set; }
        public string? AscCode { get; set; }
        public string? Name { get; set; }

    }


    public class AscWiseProductLineEntity
    {
        public string? ProductLineCode { get; set; }
        public string? ProductLineName { get; set; }

    }

    public class UserWiseDivisionEntity
    {
        public string? DivisionCode { get; set; }
        public string? DivisionName { get; set; }

    }

    public class DivisionWiseProductLineEntity
    {
        public string? ProductLineCode { get; set; }
        public string? ProductLineName { get; set; }

    }

}
