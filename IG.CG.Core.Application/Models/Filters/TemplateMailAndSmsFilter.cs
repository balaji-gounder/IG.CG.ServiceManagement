namespace IG.CG.Core.Application.Models.Filters
{


    public class TemplateMailAndSmsFilter : BaseFilter
    {
        public string? TypeId { get; set; } = string.Empty;
        public string? TemplateName { get; set; } = string.Empty;
    }
}
