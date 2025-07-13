
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IIssueService
    {
        Task<IList<IssueDisplayModel>> GetAllIssueAsync(IssueFilter issueFilter);
        Task<string?> UpsertIssueAsync(IssueModel issueModel, string? userId);
        Task<IssueModel> GetIssueByIdAsync(int issueTypeId);
        Task<string?> DeleteIssueAsync(int issueTypeId, string? userId, int isActive);

    }
}
