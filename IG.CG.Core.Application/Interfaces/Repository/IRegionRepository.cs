using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IRegionRepository
    {
        Task<IList<RegionEntity>> GetAllRegionAsync(RegionFilter regionFilter);
        Task<RegionEntity?> GetRegionByIdAsync(int regionId);
        Task<string?> UpsertRegionAsync(RegionEntity regionObj);
        Task<string?> DeleteRegionAsync(int regionId, string? userId, int isActive);

        Task<IList<RegionEntity>> GetAllUserwiseRegionAsync(string? userId);
    }
}
