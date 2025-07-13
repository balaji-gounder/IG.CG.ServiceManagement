using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class VendorModel
    {

        public int VendorId { get; set; }
        public string? VendorCode { get; set; }
        public string? SAPVendorCode { get; set; }


        [StringLength(200, MinimumLength = 1,
                 ErrorMessage = "Vendor Name should not greater than 200 characters")]
        public string? VendorName { get; set; }

        public string? InitialBatch { get; set; }

        public string? MobileNo { get; set; }

        [StringLength(100, MinimumLength = 1,
                  ErrorMessage = "Vendor EmailId should not greater than 100 characters")]

        public string? EmailId { get; set; }

        [RegularExpression("^([A-Za-z]){5}([0-9]){4}([A-Za-z]){1}$", ErrorMessage = "Invalid PAN Number")]
        public string? PanNo { get; set; }

        public bool IsGstApplicable { get; set; }
        [RegularExpression(@"^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$", ErrorMessage = "Invalid GST Number.")]
        public string? GstNo { get; set; }

        public bool IsMSME { get; set; }

        public string? MsmeCode { get; set; }

        public string? VendorAddress { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }

        public string? ProductGroupCode { get; set; }

        public int StateId { get; set; }

        public int CityId { get; set; }
        public int PinId { get; set; }
        public bool IsActive { get; set; }
    }
}
