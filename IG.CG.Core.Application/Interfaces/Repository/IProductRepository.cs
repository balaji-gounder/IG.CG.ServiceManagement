using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<IList<ProductDisplayEntity>> GetAllProductAsync(ProductFilter productFilter);

        Task<IList<ProductDisplayEntity>> GetAllProductListAsync(string? DivisionCode, string? ProductLineCode);

        Task<ProductDisplayEntity?> GetProductByIdAsync(int productId);
        Task<string?> UpsertProductAsync(ProductEntity productObj);
        Task<string?> DeleteProductAsync(int productId, string? userId, int isActive);
    }
}
