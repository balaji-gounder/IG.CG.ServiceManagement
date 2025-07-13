namespace IG.CG.Core.Domain.Entities
{
    public class TemplateMailAndSmsEntity : BaseEntity
    {

        public int TemplateId { get; set; }
        public int TypeId { get; set; }
        public string? TemplateName { get; set; }
        public string? TemplateSubject { get; set; }
        public string? TemplateBody { get; set; }
        public string? Remarks { get; set; }

        public bool IsHTML { get; set; }
        public bool IsActive { get; set; }

        public string? TypeName { get; set; }

    }
}
