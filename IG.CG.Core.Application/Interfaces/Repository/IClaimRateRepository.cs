using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IClaimRateRepository
    {
        Task<string?> UpsertclaimRateAsync(string? userId, ClaimRateEntity claimObj);

        Task<string?> UpsertclaimRateDetailsAsync(string? userId, string? ClaimRateId, ClaimRateDetailsEntity claimObj);

        Task<IList<ClaimRateDisplayEntity>> GetAllclaimRateAsync(ClaimRateFilter ClaimRateFilter);

        Task<ClaimRateDisplayEntity?> GetclaimRateByIdAsync(int ClaimRateId);

        Task<string?> DeleteclaimRateDetails(int? ClaimRateDetailId);

        Task<string?> DeleteclaimRateinfoAsync(int ClaimRateId, string? userId, int isActive);
    }
}
