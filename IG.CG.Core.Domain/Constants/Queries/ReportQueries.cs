namespace IG.CG.Core.Domain.Constants.Queries
{

    public class ReportQueries
    {
        public static string ClosureTATBranchWiseReport = "ClosureTATReport";

        public static string FIRCClosureTATBranchWiseReport = "FIRClosureTATReport";


        public static string PartConsumptionReport = "PartConsumptionReport";
        //  public static string CostingReport = "CostingReport"; 

        public static string AllServiceTicketClaimCostingReport = "ServiceTicketClaimCostingReport";
        public static string AllComplaintReport = "ComplaintReportGetAll";

        public static string AllCancelTicketReport = "ComplaintCancelReportGetAll";


        public static string AllDefectReport = "DefectReportGetALL";
        public static string AllComplaintDefectReport = "ComplaintDefectReportGetAll";
        public static string ASCDetails = "GetASC";

        //public static string DashboardDetails = "DashboardCountforService_Naveen";

        public static string DurationTicketTatDashboard = "DurationTicketTatDashboardGet";

        public static string DurationOpenTicketTatDashboard = "DurationOpenTicketTatDashboardGet";


        public static string DashboardDetails = "DashboardCountforService_LIVE";

        //by balaji gounder - universal search api
        public static string AllServiceTicketUniversalSearch = "proc_ServicePortal_GetUniversalSearchDetails";


        public static string DashboardClaimDetails = "DashboardClaimCountAndAmountforService";

        public static string AllRepeatedTicketsReport = "RepeatedTicketsReportGetAll";
        public static string AllRepeatedTicketsSummaryReport = "RepeatedTicketsCallsSummaryReportGetAll";

        public static string AllClaimApprovalTATReportReport = "ClaimApprovalTATReportGetAll";

        public static string UpsertOEM = "proc_CGCare_Trn_UpdateOEM";

        public static string GETOEMDATA = "proc_ServiceListing_AutoComplete_GetOEMData";

        public static string IBNManagment = "proc_CGCare_rpt_IBNReport";



    }
}
