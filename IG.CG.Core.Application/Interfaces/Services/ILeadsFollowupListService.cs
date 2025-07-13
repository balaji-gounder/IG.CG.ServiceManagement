using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface ILeadsFollowupListService
    {
        Task<IList<LeadsFollowupListModel>> GetAllLeadFollowuplistAsync(LeadFilter branchFilter, string? userId);
        Task<string?> UpsertleadFollowupAsync(LeadFollowupModel leadModel, string? userId, string? UploadDocuments);
        Task<LeadFollowupSelectModel> GetAllLeadFollowupByIdAsync(int leadId);
        Task<IList<LeadActivityModel>> GetAllLeadActivityAsync(int ActivityId);
    }
}
