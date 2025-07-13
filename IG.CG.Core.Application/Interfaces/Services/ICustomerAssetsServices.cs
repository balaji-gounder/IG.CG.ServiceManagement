using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface ICustomerAssetsServices
    {
        Task<string?> UpsertCutomerAssetsAsync(CustomerAssetModel model, string? userId);
        Task<CustomerAssetModel> GetCustomerAssestByIdAsync(int CustWiseAssetId);
        Task<IList<CustomerAssetDisplayModel>> GetAllCustomerAssetsAsync(CustomerAssetFilter customerAssestFilter);
        Task<string?> DeleteCustomerAssestAsync(int CustWiseAssetId, string? userId, int isActive);

        Task<CustomerAssetModel?> GetCustomerAssestBySAPSerialNoAsync(string? SerialNo);
    }
}
