using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class ApprovalLevelRepository : IApprovalLevelRepository
    {
        private readonly ISqlDbContext _approvalLevelRepository;
        public ApprovalLevelRepository(ISqlDbContext approvalLevelRepository)
        {
            _approvalLevelRepository = approvalLevelRepository;
        }

        public async Task<string?> UpsertApprovalLevelAsync(ApprovalLevelEntity approvalLevelObj)
        {
            var para = new DynamicParameters();
            para.Add("@ApprovalLevelId", approvalLevelObj.ApprovalLevelId);
            para.Add("@BranchCode", approvalLevelObj.BranchCode);
            para.Add("@DivisionCode", approvalLevelObj.DivisionCode);
            para.Add("@Level1Approver", approvalLevelObj.Level1ApproverCode);
            para.Add("@Level2Approver", approvalLevelObj.Level2ApproverCode);
            para.Add("@Level3Approver", approvalLevelObj.Level3ApproverCode);
            para.Add("@UserId", approvalLevelObj.UserId);

            return await _approvalLevelRepository.ExecuteScalarAsync<string?>(ApprovalLevelQueries.UpsertApprovalLevel, para);
        }

        public async Task<IList<ApprovalLevelDisplayEntity>> GetAllApprovalLevelAsync(ApprovalLevelFilter approvalLevelFilter)
        {
            var para = new DynamicParameters();
            para.Add("@DivisionCode", approvalLevelFilter.DivisionCode);
            para.Add("@BranchCode", approvalLevelFilter.BranchCode);
            var lstApprovalLevel = await _approvalLevelRepository.GetAllAsync<ApprovalLevelDisplayEntity>(ApprovalLevelQueries.AllApprovalLevel, para);

            return lstApprovalLevel.ToList();
        }

        public async Task<IList<ApprovalLevelUsersEntity>> GetAllApprovalLevelUsersAsync(ApprovalLevelFilter approvalLevelFilter)
        {
            var para = new DynamicParameters();
            para.Add("@DivisionCode", approvalLevelFilter.DivisionCode);
            para.Add("@BranchCode", approvalLevelFilter.BranchCode);
            var lstApprovalLevelUsers = await _approvalLevelRepository.GetAllAsync<ApprovalLevelUsersEntity>(ApprovalLevelQueries.AllApprovalLevelUsers, para);

            return lstApprovalLevelUsers.ToList();
        }

    }
}