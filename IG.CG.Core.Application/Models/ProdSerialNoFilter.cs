namespace IG.CG.Core.Application.Models
{
    public class ProdSerialNoFilter
    {
        public string? ProductSerialNo { get; set; } = string.Empty;
        public string? ProductCode { get; set; } = string.Empty;
        public string? DivisionCode { get; set; } = string.Empty;
        public string? ProductLineCode { get; set; } = string.Empty;
    }

    public class ProdSerialNoTelecallerFilter
    {
        public string? ProductSerialNo { get; set; } = string.Empty;
        public string? ProductCode { get; set; } = string.Empty;
        public string? DivisionCode { get; set; } = string.Empty;
        public string? ProductLineCode { get; set; } = string.Empty;
        public string? MobileNo { get; set; } = string.Empty;
    }
}
