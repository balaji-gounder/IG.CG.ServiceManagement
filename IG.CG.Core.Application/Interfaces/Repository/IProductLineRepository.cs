using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IProductLineRepository
    {
        Task<IList<ProductLineDisplayEntity>> GetAllProductLineAsync(ProductLineFilter productLineFilter);
        Task<ProductLineEntity?> GetProductLineByIdAsync(int productLineId);
        Task<string?> UpsertProductLineAsync(ProductLineEntity productLineObj);
        Task<string?> DeleteProductLineAsync(int productLineId, string? userId, int isActive);
        Task<IList<ProductLineDisplayEntity>> GetProductLineByDivisionAsync(string divisionCode);
    }
}
