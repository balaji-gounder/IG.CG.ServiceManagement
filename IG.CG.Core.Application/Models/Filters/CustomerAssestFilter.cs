namespace IG.CG.Core.Application.Models.Filters
{
    public class CustomerAssetFilter : BaseFilter
    {
        public int CustAutoId { get; set; } = 0;
        public string? ProductSerialNo { get; set; } = string.Empty;


    }
}
