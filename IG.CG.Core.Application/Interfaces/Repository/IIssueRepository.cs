
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IIssueRepository
    {
        Task<IList<IssueDisplayEntity>> GetAllIssueAsync(IssueFilter issueFilter);
        Task<string?> UpsertIssueAsync(IssueEntity issueObj);
        Task<IssueEntity?> GetIssueByIdAsync(int issueTypeId);
        Task<string?> DeleteIssueAsync(int issueTypeId, string? userId, int isActive);


    }
}
