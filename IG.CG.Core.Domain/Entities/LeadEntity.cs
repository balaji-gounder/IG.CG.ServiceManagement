

namespace IG.CG.Core.Domain.Entities
{
    public class LeadEntity : BaseEntity
    {
        public int LeadId { get; set; }
        public string? LeadsCode { get; set; }
        public int SourceId { get; set; }
        public int LeadTypeId { get; set; }
        public int SubLeadTypeId { get; set; }
        public int CustomerTypeId { get; set; }
        public int SegmentId { get; set; }


        public int CustomerCategoryId { get; set; }
        public string? ServiceTicketNo { get; set; }
        public string? ProductSrNo { get; set; }
        public string? LeadDate { get; set; }
        public string? CompanyContactName { get; set; }
        public bool IsActive { get; set; }

        public int ProjectStateId { get; set; }
        public int ProjectCityId { get; set; }
        public int ProjectPincodeId { get; set; }
        public string? CustomerAddress { get; set; }





        // Other
        public string? Rating { get; set; }
        public string? TotalBudget { get; set; }
        public string? ProbabilityOfWin { get; set; }
        public string? ExpectedConversionDate { get; set; }

        public int IsNewlead { get; set; }

        public string? Conversation { get; set; }

        // BackEnd
        public string? BranchCode { get; set; }
        public string? DivisionCode { get; set; }
        public string? RegionCode { get; set; }
        public List<LeadsDivisionProductEntity> LeadsDivisionProductList { get; set; }

        public List<LeadContactEntity> LeadContactList { get; set; }


    }
}
