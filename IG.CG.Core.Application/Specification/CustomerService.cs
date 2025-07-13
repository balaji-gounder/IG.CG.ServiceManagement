using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<IList<CustomerDisplayModel>> GetAllCustomerAsync(CustomerFilter customerFilter)
        {
            var customer = await _customerRepository.GetAllCustomerAsync(customerFilter);
            var customerModel = _mapper.Map<List<CustomerDisplayModel>>(customer.ToList());
            return customerModel;
        }


        public async Task<CustomerModel> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
            var branchModel = _mapper.Map<CustomerModel>(customer);
            return branchModel;
        }

        public async Task<string?> UpsertCustomerAsync(CustomerModel customerModel, string? userId)
        {
            CustomerEntity customerObj = _mapper.Map<CustomerEntity>(customerModel);
            customerObj.UserId = userId;
            return await _customerRepository.UpsertCustomerAsync(customerObj);
        }
        public async Task<string?> DeleteCustomerAsync(int customerId, string? userId, int isActive)
        {
            return await _customerRepository.DeleteCustomerAsync(customerId, userId, isActive);
        }

    }
}
