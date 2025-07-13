namespace IG.CG.Core.Domain.Entities
{
    public class ParaValEntity : BaseEntity
    {
        public int ParameterValId { get; set; }
        public int ParameterTypeId { get; set; }
        public string? ParameterText { get; set; }
        public string? ParameterCode { get; set; }
        public int SequenceNo { get; set; }
        public bool IsActive { get; set; }
    }
}
