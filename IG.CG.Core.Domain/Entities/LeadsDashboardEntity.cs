namespace IG.CG.Core.Domain.Entities
{
    public class LeadsDashboardEntity
    {

        public int TotalLeads { get; set; }
        public int TotalCancelLeads { get; set; }
        public int TotalNewLeads { get; set; }
        public int TotalConvertedLeads { get; set; }
        public int TotalPendingLeads { get; set; }
        public int TotalFollowupLeads { get; set; }
        public int TotalInProgressLeads { get; set; }
        public int TotalTodaysLeads { get; set; }
        public int TotalTodaysFollowupLeads { get; set; }
        public int TotalLostLeads { get; set; }
        public int TotalCloseLeads { get; set; }
        public int TotalOverdueLeads { get; set; }
        public int TotalCustomers { get; set; }
        public decimal TotalQuotationValueSubmitted { get; set; }
        public decimal TotalOpportunityWonQuote { get; set; }
        public decimal TotalOpportunityLostQuote { get; set; }
        public decimal TotalQuotationValueFollowupAndInprogress { get; set; }
    }
}
