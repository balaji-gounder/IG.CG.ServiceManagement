using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Models
{
    public class ParaValDispModel
    {
        public string? ParameterType { get; set; }
        public int? ParameterTypeId { get; set; }
        public string? NoOfParameterValues { get; set; }
        public List<ParaValEntity> ParaValList { get; set; }
        public string? TotalRows { get; set; }
        public bool IsActive { get; set; }
    }
}
