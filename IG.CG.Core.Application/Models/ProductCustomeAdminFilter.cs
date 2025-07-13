namespace IG.CG.Core.Application.Models
{
    public class ProductCustomeAdminFilter : BaseFilter
    {
        public string? SerialNo { get; set; } = string.Empty;
        public string? ProductCode { get; set; } = string.Empty;
        public string? CustomerMobile { get; set; } = string.Empty;
        public string? FromDate { get; set; } = string.Empty;
        public string? ToDate { get; set; } = string.Empty;
        public string? Division { get; set; } = string.Empty;



    }
}
