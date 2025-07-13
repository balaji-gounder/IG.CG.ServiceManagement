
namespace IG.CG.Core.Application.Models
{
    public class SpareModel
    {
        public int Spareid { get; set; }
        public string? SpareCode { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }
        public string? ProductCode   { get; set; }
        public string? ProductGroupCode {  get; set; }
        public string? SpareDescription { get; set; }
        public decimal SparePrice { get; set; }
        public bool IsActive { get; set; }

    }

    public class SpareDisplayModel
    { 
        public int Spareid { get; set; }
        public string? SpareCode { get;set; }
        public string? DivisionName { get; set; }
        public string? ProductLineName { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? ProductGroupName { get; set; }
        public string? SpareDescription { get; set; }
        public decimal SparePrice { get; set; }
        public bool IsActive { get; set; }
        public string? TotalRows { get; set; }


    }

}
