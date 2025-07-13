using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Models
{
    public class ASCWisePinCodeDisplayModel : ASCWisePinCodeModel
    {
        public List<ParaTypeEntity> ProductLineNameList { get; set; }
        public string? AscName { get; set; }

        public string? AscCode { get; set; }
        public string? DivisionName { get; set; }
        public string? ProductLineName { get; set; }
        public string? PincodeName { get; set; }
    }
}
