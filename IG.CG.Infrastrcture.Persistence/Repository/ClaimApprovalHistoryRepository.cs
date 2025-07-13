using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class ClaimApprovalHistoryRepository : IClaimApprovalHistoryRepository
    {
        private readonly ISqlDbContext _claimApprovalHistoryRepository;
        public ClaimApprovalHistoryRepository(ISqlDbContext claimApprovalHistoryRepository)
        {
            _claimApprovalHistoryRepository = claimApprovalHistoryRepository;
        }

        public async Task<int?> UpsertClaimApprovalHistoryAsync(ClaimApprovalHistoryEntity lstClaimApprovalHistory, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@ClaimApprovalHistoryId", lstClaimApprovalHistory.ClaimApprovalHistoryId);
            para.Add("@ServiceTicketId", lstClaimApprovalHistory.ServiceTicketId);
            para.Add("@ServiceTicketClaimId", lstClaimApprovalHistory.ServiceTicketClaimId);
            para.Add("@ClaimStatus", lstClaimApprovalHistory.ClaimStatus);
            para.Add("@ApprovedBy", lstClaimApprovalHistory.ApprovedBy);
            para.Add("@ApprovedOn", lstClaimApprovalHistory.ApprovedOn);
            para.Add("@AmountBefore", lstClaimApprovalHistory.AmountBefore);
            para.Add("@AmountAfter", lstClaimApprovalHistory.AmountAfter);
            para.Add("@DistanceBefore", lstClaimApprovalHistory.DistanceBefore);
            para.Add("@DistanceAfter", lstClaimApprovalHistory.DistanceAfter);
            para.Add("@Remarks", lstClaimApprovalHistory.Remarks);
            para.Add("@UserId", userId);
            para.Add("@Qty", lstClaimApprovalHistory.Qty);
            var result = await _claimApprovalHistoryRepository.ExecuteScalarAsync<int?>(ClaimApprovalHistoryQueries.ClaimApprovalHistoryInsert, para);
            return result;
        }

        public async Task<IList<ClaimApprovalHistoryDisplayEntity>> GetAllClaimApprovalHistoryAsync(int serviceTicketClaimId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketClaimId", serviceTicketClaimId);

            var ClaimApprovalHistory = await _claimApprovalHistoryRepository.GetAllAsync<ClaimApprovalHistoryDisplayEntity>(ClaimApprovalHistoryQueries.GetAllClaimApprovalHistory, para);

            return ClaimApprovalHistory.ToList();
        }

        public async Task<int?> UpsertSpecialApprovalHistoryAsync(SpecialApprovalHistoryEntity lstClaimApprovalHistory, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@ClaimApprovalHistoryId", lstClaimApprovalHistory.ClaimApprovalHistoryId);
            para.Add("@ServiceTicketId", lstClaimApprovalHistory.ServiceTicketId);
            para.Add("@SpecialApprovalId", lstClaimApprovalHistory.SpecialApprovalId);
            para.Add("@ClaimStatus", lstClaimApprovalHistory.ClaimStatus);
            para.Add("@ApprovedBy", lstClaimApprovalHistory.ApprovedBy);
            para.Add("@ApprovedOn", lstClaimApprovalHistory.ApprovedOn);
            para.Add("@AmountBefore", lstClaimApprovalHistory.AmountBefore);
            para.Add("@AmountAfter", lstClaimApprovalHistory.AmountAfter);
            para.Add("@Remarks", lstClaimApprovalHistory.Remarks);
            para.Add("@UserId", userId);
            var result = await _claimApprovalHistoryRepository.ExecuteScalarAsync<int?>(ClaimApprovalHistoryQueries.SpecialApprovalHistoryInsert, para);
            return result;
        }
        public async Task<IList<SpecialApprovalHistoryDisplayEntity>> GetAllSpecialApprovalHistoryAsync(int specialApprovalId)
        {
            var para = new DynamicParameters();
            para.Add("@SpecialApprovalId", specialApprovalId);

            var SpecialApprovalHistory = await _claimApprovalHistoryRepository.GetAllAsync<SpecialApprovalHistoryDisplayEntity>(ClaimApprovalHistoryQueries.GetAllSpecialApprovalHistory, para);

            return SpecialApprovalHistory.ToList();
        }

    }
}
