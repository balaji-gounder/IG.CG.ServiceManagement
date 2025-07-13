namespace IG.CG.Core.Domain.Entities
{
    public class ASCWisePinCodeEntity : BaseEntity
    {
        public int AscId { get; set; }
        public string? AscCode { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }
        public bool IsActive { get; set; }
        public List<ParaTypeEntity> PincodeList { get; set; }
    }
}
