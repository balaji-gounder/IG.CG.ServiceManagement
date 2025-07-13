namespace IG.CG.Core.Domain.Entities
{
    public class ASCWisePinCodeDisplayEntity : ASCWisePinCodeEntity
    {
        public List<ParaTypeEntity> ProductLineNameList { get; set; }
        public string? AscName { get; set; }

        public string? AscCode { get; set; }
        public string? DivisionName { get; set; }
        public string? ProductLineName { get; set; }
        public string? PincodeName { get; set; }

    }
}
