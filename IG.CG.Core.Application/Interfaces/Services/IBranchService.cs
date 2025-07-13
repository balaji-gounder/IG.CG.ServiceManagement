using IG.CG.Core.Application.Models;


namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IBranchService
    {
        Task<IList<BranchDisplayModel>> GetAllBranchAsync(BranchFilter branchFilter);
        Task<BranchModel> GetBranchByIdAsync(int branchId);
        Task<string?> UpsertBranchAsync(BranchModel branchModel, string? userId);
        Task<string?> DeleteBranchAsync(int branchId, string? userId, int isActive);

        Task<IList<BranchDisplayModel>> GetAllUserWiseBranchAsync(BaseUserWishFilter BranchFilter, string? userId);

    }
}
