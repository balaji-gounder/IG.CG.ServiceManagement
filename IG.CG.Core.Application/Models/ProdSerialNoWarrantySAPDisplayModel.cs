namespace IG.CG.Core.Application.Models
{
    public class ProdSerialNoWarrantySAPDisplayModel
    {
        public string? MsgCode { get; set; }
        public string? msg { get; set; }
        public List<ProdSerialNoWarrantySAPModel> ProdSerialNoWarrantyList { get; set; }
    }
}
