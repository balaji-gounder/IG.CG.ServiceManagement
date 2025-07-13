using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class CustomerAssestService : ICustomerAssetsServices
    {
        private readonly IMapper _mapper;
        private readonly ICustomerAssestRepository _customerAssestRepository;

        public CustomerAssestService(IMapper mapper, ICustomerAssestRepository customerAssestRepository)
        {
            _mapper = mapper;
            this._customerAssestRepository = customerAssestRepository;
        }

        public async Task<string?> UpsertCutomerAssetsAsync(CustomerAssetModel model, string? userId)
        {
            CustomerAssestsEntity customerAssest = _mapper.Map<CustomerAssestsEntity>(model);
            customerAssest.UserId = userId;
            return await _customerAssestRepository.UpsertCutomerAssetsAsync(customerAssest);
        }

        public async Task<CustomerAssetModel> GetCustomerAssestByIdAsync(int CustWiseAssetId)
        {
            var customerAssest = await _customerAssestRepository.GetCustomerAssestByIdAsync(CustWiseAssetId);
            CustomerAssetModel customerAssestModel = _mapper.Map<CustomerAssetModel>(customerAssest);
            return customerAssestModel;
        }

        public async Task<IList<CustomerAssetDisplayModel>> GetAllCustomerAssetsAsync(CustomerAssetFilter customerAssestFilter)
        {
            var customerAssest = await _customerAssestRepository.GetAllCustomerAssetsAsync(customerAssestFilter);
            var customerAssestModel = _mapper.Map<List<CustomerAssetDisplayModel>>(customerAssest);
            return customerAssestModel;
        }

        public async Task<string?> DeleteCustomerAssestAsync(int CustWiseAssetId, string? userId, int isActive)
        {
            return await _customerAssestRepository.DeleteCustomerAssestAsync(CustWiseAssetId, userId, isActive);
        }


        public async Task<CustomerAssetModel> GetCustomerAssestBySAPSerialNoAsync(string SerialNo)
        {
            var customerAssest = await _customerAssestRepository.GetCustomerAssestBySAPSerialNoAsync(SerialNo);
            CustomerAssetModel customerAssestModel = _mapper.Map<CustomerAssetModel>(customerAssest);
            return customerAssestModel;
        }
    }
}
