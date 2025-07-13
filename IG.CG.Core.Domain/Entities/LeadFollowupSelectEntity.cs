namespace IG.CG.Core.Domain.Entities
{
    public class LeadFollowupSelectEntity
    {
        public int LeadId { get; set; }
        public string? LeadDate { get; set; }

        public string? TotalBudget { get; set; }

        public List<LeadContactEntity> LeadContactList { get; set; }
        public List<LeadFollowupDisplayEntity> LeadFollowupList { get; set; }
    }
}
