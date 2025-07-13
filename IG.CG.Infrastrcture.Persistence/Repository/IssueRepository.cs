
using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class IssueRepository : IIssueRepository
    {
        private readonly ISqlDbContext _issueRepository;
        public IssueRepository(ISqlDbContext issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public async Task<IList<IssueDisplayEntity>> GetAllIssueAsync(IssueFilter issueFilter)
        {
            var para = new DynamicParameters();
            para.Add("@DivisionCode", issueFilter.DivisionCode);
            para.Add("@ProductLineCode", issueFilter.ProductLineCode);
            var lstIssue = await _issueRepository.GetAllAsync<IssueDisplayEntity>(IssueQueries.AllIssue, para);

            return lstIssue.ToList();
        }

        public async Task<string?> UpsertIssueAsync(IssueEntity issueObj)
        {
            var para = new DynamicParameters();
            para.Add("@IssueTypeId", issueObj.IssueTypeId);
            para.Add("@DivisionCode", issueObj.DivisionCode);
            para.Add("@ProductLineCode", issueObj.ProductLineCode);
            para.Add("@IssueTypeName", issueObj.IssueTypeName);
            para.Add("@UserId", issueObj.UserId);
            para.Add("@IsActive", issueObj.IsActive);

            return await _issueRepository.ExecuteScalarAsync<string?>(IssueQueries.UpsertIssue, para);
        }

        public async Task<IssueEntity?> GetIssueByIdAsync(int issueTypeId)
        {
            var para = new DynamicParameters();
            para.Add("@IssueTypeId", issueTypeId);
            return await _issueRepository.GetAsync<IssueEntity>(IssueQueries.GetIssueById, para);

        }
        public async Task<string?> DeleteIssueAsync(int issueTypeId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@IssueTypeId", issueTypeId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _issueRepository.ExecuteScalarAsync<string?>(IssueQueries.DeleteIssue, para);
        }

    }
}
