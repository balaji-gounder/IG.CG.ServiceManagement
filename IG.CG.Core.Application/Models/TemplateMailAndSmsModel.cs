using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class TemplateMailAndSmsModel
    {
        public int TemplateId { get; set; }

        [Required(ErrorMessage = "Type is Required")]
        public int TypeId { get; set; }

        [Required(ErrorMessage = "Template Name is Required")]
        public string? TemplateName { get; set; }
        [Required(ErrorMessage = "Template Subject is Required")]
        public string? TemplateSubject { get; set; }
        [Required(ErrorMessage = "Template Body is Required")]
        public string? TemplateBody { get; set; }
        public string? Remarks { get; set; }
        public bool IsHTML { get; set; }

        public bool IsActive { get; set; }
        public string? TypeName { get; set; }
    }
}
