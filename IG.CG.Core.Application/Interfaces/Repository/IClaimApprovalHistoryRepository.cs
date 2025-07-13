using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IClaimApprovalHistoryRepository
    {
        Task<int?> UpsertClaimApprovalHistoryAsync(ClaimApprovalHistoryEntity lstClaimApprovalHistory, string? userId);
        Task<IList<ClaimApprovalHistoryDisplayEntity>> GetAllClaimApprovalHistoryAsync(int serviceTicketClaimId);
        Task<int?> UpsertSpecialApprovalHistoryAsync(SpecialApprovalHistoryEntity lstClaimApprovalHistory, string? userId);
        Task<IList<SpecialApprovalHistoryDisplayEntity>> GetAllSpecialApprovalHistoryAsync(int specialApprovalId);




    }
}

