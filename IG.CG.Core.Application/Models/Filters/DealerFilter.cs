namespace IG.CG.Core.Application.Models.Filters
{
    public class DealerFilter : BaseFilter
    {
        public string? DealerName { get; set; } = String.Empty;

        public int DealerTypeId { get; set; } = 0;
    }
}
