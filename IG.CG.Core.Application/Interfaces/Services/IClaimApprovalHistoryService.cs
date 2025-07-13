using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IClaimApprovalHistoryService
    {

        Task<int?> UpsertClaimApprovalHistoryAsync(List<ClaimApprovalHistoryModel> lstClaimApprovalHistory, string? userId);
        Task<IList<ClaimApprovalHistoryDisplayModel>> GetAllClaimApprovalHistoryAsync(int serviceTicketClaimId);
        Task<int?> UpsertSpecialApprovalHistoryAsync(List<SpecialApprovalHistoryModel> lstClaimApprovalHistory, string? userId);
        Task<IList<SpecialApprovalHistoryDisplayModel>> GetAllSpecialApprovalHistoryAsync(int specialApprovalId);

    }
}
