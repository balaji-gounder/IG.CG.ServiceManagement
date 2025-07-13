using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface ILeadsFollowupListRepository
    {
        Task<IList<LeadsFollowupListEntity>> GetAllLeadFollowuplistAsync(LeadFilter leadFilter, string? userId);
        Task<string?> UpsertleadFollowupAsync(LeadFollowupEntity leadObj);
        Task<LeadFollowupSelectEntity?> GetAllLeadFollowupByIdAsync(int leadId);
        Task<IList<LeadActivityEntity>> GetAllLeadActivityAsync(int ActivityId);
    }
}
