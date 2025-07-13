using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly ISqlDbContext _customerRepository;
        public CustomerRepository(ISqlDbContext customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<string?> UpsertCustomerAsync(CustomerEntity customerEntity)
        {

            var para = new DynamicParameters();
            para.Add("@CustAutoId", customerEntity.CustAutoId);
            para.Add("@CustName", customerEntity.CustName);
            para.Add("@CustPhone", customerEntity.CustPhone);
            para.Add("@CustPhone2", customerEntity.CustPhone2);
            para.Add("@CustEmail", customerEntity.CustEmail);
            para.Add("@CustAddess", customerEntity.CustAddess);
            para.Add("@StateId", customerEntity.StateId);
            para.Add("@CityId", customerEntity.CityId);
            para.Add("@TalukaId", customerEntity.TalukaId);
            para.Add("@AreaId", customerEntity.AreaId);
            para.Add("@PinId", customerEntity.PinId);
            para.Add("@IsActive", customerEntity.IsActive);
            para.Add("@UserId", customerEntity.UserId);
            return await _customerRepository.ExecuteScalarAsync<string?>(CustomerQueries.AddCutomer, para);

        }

        public async Task<CustomerEntity?> GetCustomerByIdAsync(int custAutoId)
        {
            var para = new DynamicParameters();
            para.Add("@CustAutoId", custAutoId);
            return await _customerRepository.GetAsync<CustomerEntity>(CustomerQueries.GetCustomer, para);
        }

        public async Task<IList<CustomerDisplayEntity>> GetAllCustomerAsync(CustomerFilter customerFilter)
        {
            var para = new DynamicParameters();
            para.Add("@CustName", customerFilter.CustName);
            para.Add("@CityId", customerFilter.CityId);
            para.Add("@StateId", customerFilter.StateId);
            para.Add("@PageSize", customerFilter.PageSize);
            para.Add("@PageNumber", customerFilter.PageNumber);
            var lstCustomer = await _customerRepository.GetAllAsync<CustomerDisplayEntity>(CustomerQueries.AllCustomer, para);
            return lstCustomer.ToList();
        }

        public async Task<string?> DeleteCustomerAsync(int custAutoId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@CustAutoId", custAutoId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _customerRepository.ExecuteScalarAsync<string?>(CustomerQueries.DeleteCustomer, para);
        }
    }
}
