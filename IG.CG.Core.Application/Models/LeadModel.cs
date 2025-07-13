

using IG.CG.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class LeadModel
    {
        public int? LeadId { get; set; }
        public string? LeadsCode { get; set; }
        [Required(ErrorMessage = "Please Select Source")]
        public int SourceId { get; set; }
        [Required(ErrorMessage = "Please Select LeadType")]
        public int LeadTypeId { get; set; }
        public int SubLeadTypeId { get; set; }
        [Required(ErrorMessage = "Please Select CustomerType")]

        public int CustomerTypeId { get; set; }
        [Required(ErrorMessage = "Please Select Segment")]
        public int SegmentId { get; set; }
        [Required(ErrorMessage = "Please Select Customer Category")]
        public int CustomerCategoryId { get; set; }

        public string? ProductSrNo { get; set; }
        public string? ServiceTicketNo { get; set; }
        [Required(ErrorMessage = "Please Enter Lead Date")]
        public string? LeadDate { get; set; }
        [Required(ErrorMessage = "Please Enter Customer Name")]
        public string? CompanyContactName { get; set; }
        public bool IsActive { get; set; }

        public string? CustomerAddress { get; set; }
        public int ProjectStateId { get; set; }
        public int ProjectCityId { get; set; }
        public int ProjectPincodeId { get; set; }


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
