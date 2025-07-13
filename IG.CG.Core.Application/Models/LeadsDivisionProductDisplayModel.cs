using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Models
{
    public class LeadsDivisionProductDisplayModel : LeadsDivisionProductModel
    {
        public string? DivisionName { get; set; }
        public string? ProductGroupName { get; set; }
        public string? ProductLineName { get; set; }
        public string? ServiceOfferingName { get; set; }

        public List<ParaTypeEntity> ProductLineCodeList { get; set; }
    }
}
