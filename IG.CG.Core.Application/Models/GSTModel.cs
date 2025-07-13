using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CG.Core.Application.Models
{
    public class GSTModel
    {
        public bool IsGSTApplicable { get; set; }

        [Required(ErrorMessage = "PAN is Required")]
        [RegularExpression("^([A-Za-z]){5}([0-9]){4}([A-Za-z]){1}$", ErrorMessage = "Invalid PAN Number")]
        public string? PanNo { get; set; }

        [Required(ErrorMessage = "State  is Required")]
        public int StateId { get; set; }

        [RegularExpression(@"^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$", ErrorMessage = "Invalid GST Number.")]
        public string? GstNo { get; set; }
    }
}
