namespace IG.CG.Core.Application.Models
{
    public class ASCWisePinCodeModel
    {

        public int AscId { get; set; }
        public string? AscCode { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }
        public bool IsActive { get; set; }
        public List<ParaTypeModel> PincodeList { get; set; }
    }
}
