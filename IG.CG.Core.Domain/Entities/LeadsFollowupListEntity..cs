namespace IG.CG.Core.Domain.Entities
{
    public class LeadsFollowupListEntity
    {
        public string? RegionName { get; set; }
        public string? BranchName { get; set; }
        public string? UserName { get; set; }
        public string? LeadsCode { get; set; }
        public string? CompanyContactName { get; set; }

        public string? DivisionName { get; set; }
        public string? LeadTypeName { get; set; }
        public string? LeadDate { get; set; }
        public string? ExpectedConversionDate { get; set; }

        public string? NextDateOfFollowup { get; set; }

        public string? TotalBudget { get; set; }
        public string? ActualQuote { get; set; }
        public string? ReviseQuote { get; set; }

        public string? StatusName { get; set; }
        public string? leadStatus { get; set; }

        public string? LeadOverDueStatus { get; set; }
        public int? IsOverdue { get; set; }
        public string? ActivityRemark { get; set; }

        public string? ActivityFollowupDate { get; set; }


        public string? PurchaseNo { get; set; }
        public string? LostLeadReasonDetails { get; set; }

        public string? ContactDetails { get; set; }

        public int LeadId { get; set; }

        public string? ServiceTicketNo { get; set; }


        public string? CustomerCategoryName { get; set; }
        public string? CustomerType { get; set; }

        public string? Address { get; set; }
        public string? NoOfDayold { get; set; }


        public List<LeadsFollowupExcelEntity> LeadFollowupList { get; set; }
        public List<LeadContactEntity> LeadContactList { get; set; }


    }


    public class LeadsFollowupExcelEntity
    {
        public string? RegionName { get; set; }
        public string? BranchName { get; set; }
        public string? UserName { get; set; }
        public string? LeadsCode { get; set; }
        public string? CompanyContactName { get; set; }

        public string? DivisionName { get; set; }
        public string? LeadTypeName { get; set; }
        public string? LeadDate { get; set; }
        public string? ExpectedConversionDate { get; set; }

        public string? NextDateOfFollowup { get; set; }

        public string? TotalBudget { get; set; }
        public string? ActualQuote { get; set; }
        public string? ReviseQuote { get; set; }

        public string? StatusName { get; set; }
        public string? leadStatus { get; set; }

        public string? LeadOverDueStatus { get; set; }
        public int? IsOverdue { get; set; }
        public string? ActivityRemark { get; set; }

        public string? ActivityFollowupDate { get; set; }


        public string? PurchaseNo { get; set; }
        public string? LostLeadReasonDetails { get; set; }

        public string? ContactDetails { get; set; }

        public int LeadId { get; set; }

        public string? ServiceTicketNo { get; set; }


        public string? CustomerCategoryName { get; set; }
        public string? CustomerType { get; set; }

        public string? Address { get; set; }
        public string? NoOfDayold { get; set; }




    }


}
