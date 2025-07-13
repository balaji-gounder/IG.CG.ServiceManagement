using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;


namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IDealerService
    {
        Task<string?> UpsertDealerAsync(DealerModel dealerModel, string? userId);
        Task<DealerModel> GetDealerByIdAsync(int dealerId);
        Task<IList<DealerDisplayModel>> GetAllDealerAsync(DealerFilter dealerFilter);
        Task<string?> DeleteDealerAsync(int dealerId, string? userId, int isActive);
        Task<DealerModel> GetDealerByCodeAsync(string? DealerCode);
        Task<DealerModel> GetDealerByNameAsync(string? DealerName);
        Task<string?> UpsertRetailerAsync(DealerModel dealerModel, string? userId);

        Task<IList<DealerDisplayModel>> GetDealerAndOEMAsync(string? DealerTypeId);
    }
}
