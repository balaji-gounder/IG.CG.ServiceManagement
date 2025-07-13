using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IBranchRepository
    {
        Task<IList<BranchDisplayEntity>> GetAllBranchAsync(BranchFilter BranchFilter);
        Task<BranchEntity?> GetBranchByIdAsync(int branchId);
        Task<string?> UpsertBranchAsync(BranchEntity branchObj);
        Task<string?> DeleteBranchAsync(int branchId, string? userId, int isActive);

        Task<IList<BranchDisplayEntity>> GetAllUserWiseBranchAsync(BaseUserWishFilter BranchFilter, string? userId);



    }
}
