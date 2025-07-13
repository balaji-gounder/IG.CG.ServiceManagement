using IG.CG.Core.Application.Models;
using System.ComponentModel.DataAnnotations;

namespace IG.CG.ServiceManagement.WebApi.Extensions
{
    public class GSTWithPanAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            var gstModel = (GSTModel)validationContext.ObjectInstance;
            if (gstModel == null)
            {
                return new ValidationResult("GST Model can not an empty.");
            }
            else if (gstModel.IsGSTApplicable)
            {
                if (gstModel.GstNo is not null)
                {
                    if (gstModel.PanNo is not null && isGSTValidWithPAN(gstModel.GstNo, gstModel.PanNo))
                        return ValidationResult.Success;
                    else
                        return new ValidationResult("Pan number does not match with GST pan number.");
                }
                else
                {
                    return new ValidationResult("GST number can not an empty.");
                }
            }
            else
            {
                return ValidationResult.Success;
            }
        }
        bool isGSTValidWithPAN(string gstNumber, string panNumber)
        {
            string panPart = gstNumber.Substring(2, 10);
            return panNumber.Equals(panPart);
        }
    }
}
