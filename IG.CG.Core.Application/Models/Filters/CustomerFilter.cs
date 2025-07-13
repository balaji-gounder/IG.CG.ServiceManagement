namespace IG.CG.Core.Application.Models.Filters
{
    public class CustomerFilter : BaseFilter
    {
        public string? CustName { get; set; } = string.Empty;
        public int StateId { get; set; } = 0;
        public int CityId { get; set; } = 0;

    }
}
