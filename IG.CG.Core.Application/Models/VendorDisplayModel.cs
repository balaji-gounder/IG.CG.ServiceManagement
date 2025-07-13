namespace IG.CG.Core.Application.Models
{
    public class VendorDisplayModel : VendorModel
    {
        public string? CityName { get; set; }
        public string? StateName { get; set; }
        public string? PinCode { get; set; }
        public string? NoOfDivision { get; set; }
        public string? NoOfProductLine { get; set; }
        public string? TotalRows { get; set; }

        public List<ParaTypeModel> DivisionCodeList { get; set; }
        public List<ParaTypeModel> ProductLineCodeList { get; set; }
        public List<ParaTypeModel> ProductGroupCodeList { get; set; }
    }
}
