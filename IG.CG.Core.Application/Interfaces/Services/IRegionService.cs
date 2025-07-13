using IG.CG.Core.Application.Models;
namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IRegionService
    {
        Task<IList<RegionModel>> GetAllRegionAsync(RegionFilter regionFilter);
        Task<RegionModel> GetRegionByIdAsync(int regionId);
        Task<string?> UpsertRegionAsync(RegionModel regionModel, string? userId);
        Task<string?> DeleteRegionAsync(int regionId, string? userId, int isActive);
        Task<IList<RegionModel>> GetAllUserwiseRegionAsync(string? userId);
    }
}
