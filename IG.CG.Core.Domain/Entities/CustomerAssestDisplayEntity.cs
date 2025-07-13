namespace IG.CG.Core.Domain.Entities
{
    public class CustomerAssestDisplayEntity : CustomerAssestsEntity
    {
        public string? DivisionName { get; set; }
        public string? ProductLineName { get; set; }
        public string? ProductGroupName { get; set; }
        public string? ProductName { get; set; }
    }
}
