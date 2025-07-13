namespace IG.CG.Core.Application.Models
{
    public class ProductDeviationFilter : BaseFilter
    {
        public string? SerialNo { get; set; } = string.Empty;
        public string? DivisionCode { get; set; } = string.Empty;
        public string? ProductCode { get; set; } = string.Empty;
        public string? CustomerMobile { get; set; } = string.Empty;
        public string? FromDate { get; set; } = string.Empty;
        public string? ToDate { get; set; } = string.Empty;
        public string? ExtendedWarranty { get; set; } = string.Empty;
        public string? RoleCode { get; set; } = string.Empty;
    }
}
