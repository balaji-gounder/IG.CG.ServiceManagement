

namespace IG.CG.Core.Application.Models
{
    public class ParaTypeModel
    {
        public string? ParameterTypeId { get; set; }
        public string? ParameterType { get; set; }
        public string? IsRequired { get; set; }
    }

    public class ProductLineFrontModel
    {
        public string? ProductLineFrontId { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }
        public string? ProductLineName { get; set; }
    }
}
