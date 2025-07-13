using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class AscModel : GSTModel
    {
        public int AscId { get; set; }

        [Required(ErrorMessage = "ASC Code is Required")]

        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Special character not allowed in ASC Code.")]
        public string? AscCode { get; set; }



        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Special character not allowed in SAP customer code.")]
        public string? CustCode { get; set; }

        [Required(ErrorMessage = "ASC Name is Required")]
        [StringLength(200, MinimumLength = 1,
                  ErrorMessage = "ASC Name should not greater than 200 characters")]

        public string? Name { get; set; }

        [Required(ErrorMessage = "ASC Email is Required")]
        [StringLength(100, MinimumLength = 1,
                  ErrorMessage = "ASC EmailId should not greater than 100 characters")]
        [EmailAddress]
        public string? EmailId { get; set; }

        [Required(ErrorMessage = "ASC Mobile is Required")]
        [RegularExpression("^(\\+\\d{1,3}[- ]?)?\\d{10}$", ErrorMessage = "Invalid Mobile Number.")]
        public string? MobileNo { get; set; }

        [Required(ErrorMessage = "Contact Person Name is Required")]
        [StringLength(200, MinimumLength = 1,
                  ErrorMessage = "Contact Person Name should not greater than 200 characters")]

        public string? ContactPersonName { get; set; }


        //[Required(ErrorMessage = "Aadhar No is Required")]
        // [RegularExpression(@"^([0-9]{4}[0-9]{4}[0-9]{4}$)|([0-9]{4}\s[0-9]{4}\s[0-9]{4}$)|([0-9]{4}-[0-9]{4}-[0-9]{4}$)", ErrorMessage = "Invalid Aadhaar Number.")]
        public string? AadharNo { get; set; }

        public bool IsGSTApplicable { get; set; }

        public string? PanNo { get; set; }

        public string? GstNo { get; set; }


        [Required(ErrorMessage = "City  is Required")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Pin  is Required")]
        public int PinId { get; set; }

        [Required(ErrorMessage = "Address  is Required")]
        public string? AscAddress { get; set; }

        [Required(ErrorMessage = "Agreement Start Date is Required")]
        public string? AgreementStartDate { get; set; }

        [Required(ErrorMessage = "Agreement End Date is Required")]
        public string? AgreementEndDate { get; set; }

        [Required(ErrorMessage = "Security Deposit is Required")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Invalid Security Deposit.")]

        public decimal SecurityDeposit { get; set; }

        [Required(ErrorMessage = "HYAudit Date is Required")]
        public string? HYAuditDate { get; set; }


        [RegularExpression("^[0-9]*$", ErrorMessage = "No.of.Technician must be numeric")]
        public int NoOfTechnicians { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "No.of.Available Machines must be numeric")]
        public int AvailableMachines { get; set; }
        public int DocumentType { get; set; }
        public List<IFormFile>? DocumentPath { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public string? ProductLineCode { get; set; }

        public string? DivisionCode { get; set; }

        public string? BranchCode { get; set; }

        public string? TypeOfTicketTobeHandeled { get; set; }


    }
}
