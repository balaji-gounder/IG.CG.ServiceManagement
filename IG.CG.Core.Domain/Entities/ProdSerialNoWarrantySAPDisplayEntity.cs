namespace IG.CG.Core.Domain.Entities
{
    public class ProdSerialNoWarrantySAPDisplayEntity
    {
        public string? MsgCode { get; set; }
        public string? msg { get; set; }
        public List<ProdSerialNoWarrantySAPEntity> ProdSerialNoWarrantyList { get; set; }

    }
}
