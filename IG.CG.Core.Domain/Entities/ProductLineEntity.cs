
using System.Text.Json.Serialization;
namespace IG.CG.Core.Domain.Entities
{
    public class ProductLineEntity : BaseEntity
    {

        public int ProductLineID { get; set; }
        public string? DivisionCode { get; set; }
        public string? ProductLineCode { get; set; }
        public string? ProductLineName { get; set; }
        public string? ProductLineRemarks { get; set; }
        public bool IsActive { get; set; }
        public bool IsProductGroupRequired { get; set; }

        [JsonIgnore]
        public string? DivisionName { get; set; }


    }
}
