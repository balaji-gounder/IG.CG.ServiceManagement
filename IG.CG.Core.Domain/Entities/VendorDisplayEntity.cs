namespace IG.CG.Core.Domain.Entities
{
    public class VendorDisplayEntity : VendorEntity
    {
        public string? CityName { get; set; }
        public string? StateName { get; set; }
        public string? PinCode { get; set; }
        public string? NoOfDivision { get; set; }
        public string? NoOfProductLine { get; set; }
        public string? NoOfProductGroup { get; set; }

        public List<ParaTypeEntity> DivisionCodeList { get; set; }
        public List<ParaTypeEntity> ProductLineCodeList { get; set; }
        public List<ParaTypeEntity> ProductGroupCodeList { get; set; }


    }
}
