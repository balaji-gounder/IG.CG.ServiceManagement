namespace IG.CG.Core.Application.Models
{
    public class ProductGroupFilter :BaseFilter
    {

        public string? ProductLineCode { get; set; } = string.Empty;
        public string? DivisionCode { get; set; } = string.Empty;
        public string? ProductGroupName { get; set; } = string.Empty;

    }
}
