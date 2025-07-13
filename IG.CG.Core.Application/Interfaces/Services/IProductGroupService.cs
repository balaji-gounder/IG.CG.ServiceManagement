using IG.CG.Core.Application.Models;
namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IProductGroupService
    {
        Task<IList<ProductGroupDisplayModel>> GetAllProductGroupAsync(ProductGroupFilter productGroupFilter);
        Task<ProductGroupModel> GetProductGroupByIdAsync(int productGroupId);
        Task<string?> UpsertProductGroupAsync(ProductGroupModel productGroupModel, string? userId);
        Task<string?> DeleteProductGroupAsync(int productGroupId, string? userId, int isActive);

    }
}
