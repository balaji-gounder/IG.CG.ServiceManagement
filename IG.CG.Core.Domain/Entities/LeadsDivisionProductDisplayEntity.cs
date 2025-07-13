namespace IG.CG.Core.Domain.Entities
{
    public class LeadsDivisionProductDisplayEntity : LeadsDivisionProductEntity
    {
        public string? DivisionName { get; set; }
        public string? ProductGroupName { get; set; }
        public string? ProductLineName { get; set; }
        public List<ParaTypeEntity> ProductLineCodeList { get; set; }
        public string? ServiceOfferingName { get; set; }
    }
}
