
namespace IG.CG.Core.Application.Models.Filters
{
    public class ServiceTicketDashboardFilter 
    {
      public string? FromDate { get; set; } 
        public string? ToDate { get; set; } 
        public string? AscCode {  get; set; } = string.Empty;
        public string? AsmCode {  get; set; } = string.Empty;
        public string? BranchCode { get; set; } = string.Empty;
        public string? RegionCode { get; set; } = string.Empty;
        public string? DivisionCode { get; set; } = string.Empty;
       
    }

    public class AscTatPerformanceFilter
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }

    }
}
