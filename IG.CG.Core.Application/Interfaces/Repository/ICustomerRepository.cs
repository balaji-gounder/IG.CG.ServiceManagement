using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        Task<IList<CustomerDisplayEntity>> GetAllCustomerAsync(CustomerFilter customerFilter);
        Task<CustomerEntity?> GetCustomerByIdAsync(int customerId);
        Task<string?> UpsertCustomerAsync(CustomerEntity customerObj);
        Task<string?> DeleteCustomerAsync(int customerId, string? userId, int isActive);
    }
}
