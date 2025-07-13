namespace IG.CG.Core.Domain.Entities
{
    public class LeadDisplayEntity
    {
        public string? LeadsCode { get; set; }

        public string? DivisionName { get; set; }

        public string? BranchName { get; set; }

        public string? RegionName { get; set; }
        public string? CompanyContactName { get; set; }
        public string? SourceName { get; set; }
        public string? LeadTypeName { get; set; }
        public string? LeadDate { get; set; }
        public string? ExpectedConversionDate { get; set; }
        public string? nextFollowupDate { get; set; }

        public string? TotalBudget { get; set; }
        public string? ActualQuote { get; set; }
        public string? ReviseQuote { get; set; }
        public string? Status { get; set; }

        public string? leadStatus { get; set; }
        public string? ContactDetails { get; set; }

        public string? UserName { get; set; }
        public string? CustomerTypeName { get; set; }
        public string? CustomerCategoryName { get; set; }

        public string? LeadOverDueStatus { get; set; }

        public string? ActivityRemark { get; set; }


        public string? PurchaseNo { get; set; }

        public string? LostLeadReasonDetails { get; set; }


        public List<LeadsDivisionProductDisplayEntity> LeadsDivisionProductDisplay { get; set; }

        public int LeadId { get; set; }

        public int SourceId { get; set; }
        public int LeadTypeId { get; set; }
        public int SubLeadTypeId { get; set; }
        public int CustomerTypeId { get; set; }
        public int SegmentId { get; set; }


        public int CustomerCategoryId { get; set; }
        public string? ServiceTicketNo { get; set; }
        public string? ProductSrNo { get; set; }

        public bool IsActive { get; set; }

        public int ProjectStateId { get; set; }
        public int ProjectCityId { get; set; }
        public int ProjectPincodeId { get; set; }

        public string ProjectStateName { get; set; }
        public string ProjectCityIdName { get; set; }
        public string ProjectPincodeIdName { get; set; }
        public string? CustomerAddress { get; set; }

        public string? SegmentName { get; set; }
        public string? SubLeadTypeName { get; set; }
        

        // Other
        public string? Rating { get; set; }
        public int IsNewlead { get; set; }
        public string? ProbabilityOfWin { get; set; }

        public string? Conversation { get; set; }

        // BackEnd
        public string? BranchCode { get; set; }
        public string? DivisionCode { get; set; }
        public string? RegionCode { get; set; }
        public List<LeadsDivisionProductEntity> LeadsDivisionProductList { get; set; }

        public List<LeadContactEntity> LeadContactList { get; set; }

        public string? CreatedOn { get; set; }
        public string? DeleteRemark { get; set; }
        public string? FollowupConversationDetails { get; set; }



    }
}
