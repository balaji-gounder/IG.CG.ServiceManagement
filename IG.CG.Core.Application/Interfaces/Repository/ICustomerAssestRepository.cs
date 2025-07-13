using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface ICustomerAssestRepository
    {
        Task<string?> UpsertCutomerAssetsAsync(CustomerAssestsEntity customerAssests);
        Task<CustomerAssestsEntity?> GetCustomerAssestByIdAsync(int CustWiseAssetId);
        Task<IList<CustomerAssestDisplayEntity>> GetAllCustomerAssetsAsync(CustomerAssetFilter customerAssestFilter);
        Task<string?> DeleteCustomerAssestAsync(int CustWiseAssetId, string? userId, int isActive);

        Task<CustomerAssestsEntity?> GetCustomerAssestBySAPSerialNoAsync(string? SerialNo);
    }
}
