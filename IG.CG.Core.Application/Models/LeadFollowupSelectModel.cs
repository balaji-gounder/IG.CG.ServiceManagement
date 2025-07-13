using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Models
{
    public class LeadFollowupSelectModel
    {
        public int LeadId { get; set; }
        public string? LeadDate { get; set; }

        public string? TotalBudget { get; set; }
        public List<LeadContactEntity> LeadContactList { get; set; }
        public List<LeadFollowupDisplayModel> LeadFollowupList { get; set; }
    }
}
