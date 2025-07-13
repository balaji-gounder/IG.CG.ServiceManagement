namespace IG.CG.Core.Application.Models
{
    public class CustomerAssetDisplayModel : CustomerAssetModel
    {
        public string? DivisionName { get; set; }
        public string? ProductLineName { get; set; }
        public string? ProductGroupName { get; set; }
        public string? ProductName { get; set; }
        public string? TotalRows { get; set; }
    }
}
