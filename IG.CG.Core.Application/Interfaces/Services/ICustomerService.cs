using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<IList<CustomerDisplayModel>> GetAllCustomerAsync(CustomerFilter customerFilter);
        Task<CustomerModel> GetCustomerByIdAsync(int customerId);
        Task<string?> UpsertCustomerAsync(CustomerModel customerModel, string? userId);
        Task<string?> DeleteCustomerAsync(int customerId, string? userId, int isActive);
    }
}
