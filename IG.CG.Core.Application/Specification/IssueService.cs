
using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class IssueService : IIssueService
    {
        private readonly IMapper _mapper;
        private readonly IIssueRepository _issueRepository;
        public IssueService(IMapper mapper, IIssueRepository issueRepository)
        {
            _mapper = mapper;
            _issueRepository = issueRepository;

        }

        public async Task<IList<IssueDisplayModel>> GetAllIssueAsync(IssueFilter issueFilter)
        {
            var issue = await _issueRepository.GetAllIssueAsync(issueFilter);
            var issueModel = _mapper.Map<List<IssueDisplayModel>>(issue.ToList());
            return issueModel;
        }

        public async Task<string?> UpsertIssueAsync(IssueModel issueModel, string? userId)
        {
            IssueEntity issueObj = _mapper.Map<IssueEntity>(issueModel);
            issueObj.UserId = userId;
            return await _issueRepository.UpsertIssueAsync(issueObj);
        }

        public async Task<IssueModel> GetIssueByIdAsync(int issueTypeId)
        {
            var Issue = await _issueRepository.GetIssueByIdAsync(issueTypeId);
            var issueModel = _mapper.Map<IssueModel>(Issue);
            return issueModel;
        }

        public async Task<string?> DeleteIssueAsync(int issueTypeId, string? userId, int isActive)
        {
            return await _issueRepository.DeleteIssueAsync(issueTypeId, userId, isActive);
        }

    }
}
