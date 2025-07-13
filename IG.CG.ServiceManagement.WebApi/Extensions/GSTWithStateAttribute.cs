using IG.CG.Core.Application.Models;
using System.ComponentModel.DataAnnotations;

namespace IG.CG.ServiceManagement.WebApi.Extensions
{
    public class GSTWithStateAttribute : ValidationAttribute
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
                    if (gstModel.StateId != 0 && IsGSTValidWithState(gstModel.GstNo, gstModel.StateId))
                        return ValidationResult.Success;
                    else
                        return new ValidationResult("State does not match with GST state.");
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
        bool IsGSTValidWithState(string gstNumber, int stateId)
        {
            string panPart = gstNumber.Substring(2, 10);
            int? gstStateId = Convert.ToInt16(gstNumber.Substring(0, 2));
            return gstStateId.Equals(stateId);

        }
    }
}
