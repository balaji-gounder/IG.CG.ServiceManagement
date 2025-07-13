using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IProductDeviationService
    {
        Task<IList<ProductDeviationDisplayModel>> GetAllProductDeviationAsync(ProductDeviationFilter productDeviationFilter);
        Task<ProductDeviationModel> GetProductDeviationByIdAsync(int productDeviationId);
        Task<string?> UpsertProductDeviationAsync(ProductDeviationModel productDeviationModel, string? userId);
        Task<string?> DeleteProductDeviationAsync(int productDeviationId, string? userId, int isActive);
    }
}
