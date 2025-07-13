namespace IG.CG.Core.Application.Models
{
    public class BranchDisplayModel : BranchModel
    {
        public string? RegionName { get; set; }
        public string? StateName { get; set; }
        public string? CityName { get; set; }

        public string? TotalRows { get; set; }
    }
}
