using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class ParaValModel
    {
        public int ParameterValId { get; set; }
        [Required(ErrorMessage = "Parameter Type is Required")]
        public int ParameterTypeId { get; set; }
        [Required(ErrorMessage = "Parameter Text Required")]
        public string? ParameterText { get; set; }

        public string? ParameterCode { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sequence no must be numeric")]
        public int SequenceNo { get; set; }
        public bool IsActive { get; set; }
    }
}
