using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IClaimRateService
    {
        Task<string?> UpsertclaimRateAsync(ClaimRateModel branchModel, string? userId);
        Task<IList<ClaimRateDisplayModel>> GetAllclaimRateAsync(ClaimRateFilter ClaimRateFilter);

        Task<ClaimRateDisplayModel> GetclaimRateByIdAsync(int ClaimRateId);

        Task<string?> DeleteclaimRateinfoAsync(int ClaimRateId, string? userId, int isActive);

        Task<string?> DeleteclaimRateDetails(int? ClaimRateDetailId);
    }
}
