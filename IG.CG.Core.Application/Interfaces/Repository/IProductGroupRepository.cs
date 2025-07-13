using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IProductGroupRepository
    {
        Task<IList<ProductGroupDisplayEntity>> GetAllProductGroupAsync(ProductGroupFilter productGroupFilter);
        Task<ProductGroupEntity?> GetProductGroupByIdAsync(int productGroupLineId);
        Task<string?> UpsertProductGroupAsync(ProductGroupEntity productGroupObj);
        Task<string?> DeleteProductGroupAsync(int productGroupId, string? userId, int isActive);
    }
}
