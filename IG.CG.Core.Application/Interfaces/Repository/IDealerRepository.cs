using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;


namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IDealerRepository
    {
        Task<string?> UpsertDealerAsync(DealerEntity dealerEntity);
        Task<DealerEntity?> GetDealerByIdAsync(int dealerId);
        Task<IList<DealerDisplayEntity>> GetAllDealerAsync(DealerFilter dealerFilter);
        Task<string?> DeleteDealerAsync(int dealerId, string? userId, int isActive);

        Task<DealerEntity?> GetDealerByCodeAsync(string? DealerCode);

        Task<string?> UpsertRetailerAsync(DealerEntity dealerEntity);

        Task<DealerEntity?> GetDealerByNameAsync(string? DealerName);

        Task<IList<DealerDisplayEntity>> GetDealerAndOEMAsync(string? DealerTypeId);
    }
}
