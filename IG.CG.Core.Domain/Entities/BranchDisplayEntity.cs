namespace IG.CG.Core.Domain.Entities
{
    public class BranchDisplayEntity : BranchEntity
    {
        public string? RegionName { get; set; }
        public string? StateName { get; set; }
        public string? CityName { get; set; }
    }
}
