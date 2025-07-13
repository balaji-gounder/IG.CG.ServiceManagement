namespace IG.CG.Core.Application.Models
{
    public class LeadFilter : BaseFilter
    {
        //public string? CompanyContactName { get; set; } = string.Empty;
        //public int LeadTypeId { get; set; } = 0;
        //public int CustomerTypeId { get; set; } = 0;
        //public int SourceId { get; set; } = 0;
        //public int CustomerCategoryId { get; set; } = 0;
        public string? BranchCode { get; set; } = string.Empty;
        public string? DivisionCode { get; set; } = string.Empty;
        public string? RegionCode { get; set; } = string.Empty;
        public string? FromDate { get; set; } = string.Empty;
        public string? ToDate { get; set; } = string.Empty;
        public int? StatusId { get; set; } = 0;
        public int? ActivityStatusId { get; set; } = 0;

        public string? IsStatus { get; set; } = string.Empty;
    }
}
