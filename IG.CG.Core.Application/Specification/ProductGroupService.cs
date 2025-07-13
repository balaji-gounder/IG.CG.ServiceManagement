using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class ProductGroupService : IProductGroupService
    {

        private readonly IMapper _mapper;
        private readonly IProductGroupRepository _productGroupRepository;
        public ProductGroupService(IMapper mapper, IProductGroupRepository productGroupRepository)
        {
            _mapper = mapper;
            _productGroupRepository = productGroupRepository;

        }

        public async Task<IList<ProductGroupDisplayModel>> GetAllProductGroupAsync(ProductGroupFilter productGroupFilter)
        {
            var productGroup = await _productGroupRepository.GetAllProductGroupAsync(productGroupFilter);
            var productGroupModel = _mapper.Map<List<ProductGroupDisplayModel>>(productGroup.ToList());
            return productGroupModel;
        }

        public async Task<ProductGroupModel> GetProductGroupByIdAsync(int productGroupId)
        {
            var productGroup = await _productGroupRepository.GetProductGroupByIdAsync(productGroupId);
            var productGroupModel = _mapper.Map<ProductGroupModel>(productGroup);
            return productGroupModel;
        }


        public async Task<string?> UpsertProductGroupAsync(ProductGroupModel productGroupModel, string? userId)
        {
            ProductGroupEntity productGroupObj = _mapper.Map<ProductGroupEntity>(productGroupModel);
            productGroupObj.UserId = userId;
            return await _productGroupRepository.UpsertProductGroupAsync(productGroupObj);
        }
        public async Task<string?> DeleteProductGroupAsync(int productGroupId, string? userId, int isActive)
        {
            return await _productGroupRepository.DeleteProductGroupAsync(productGroupId, userId, isActive);
        }
    }
}
