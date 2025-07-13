using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<IList<ProductDisplayModel>> GetAllProductAsync(ProductFilter productFilter);


        Task<IList<ProductDisplayModel>> GetAllProductListAsync(string? DivisionCode, string? ProductLineCode);

        Task<ProductDisplayModel> GetProductByIdAsync(int productId);
        Task<string?> UpsertProductAsync(ProductModel productModel, string? userId);
        Task<string?> DeleteProductAsync(int productId, string? userId, int isActive);
    }
}
