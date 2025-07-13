using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IProductLineService
    {
        Task<IList<ProductLineDisplayModel>> GetAllProductLineAsync(ProductLineFilter productLineFilter);
        Task<ProductLineModel> GetProductLineByIdAsync(int ProductLineId);
        Task<string?> UpsertProductLineAsync(ProductLineModel ProductLineModel, string? userId);
        Task<string?> DeleteProductLineAsync(int ProductLineId, string? userId, int isActive);
        Task<IList<ProductLineDisplayModel>> GetProductLineByDivisionAsync(string divisionCode);
    }
}
