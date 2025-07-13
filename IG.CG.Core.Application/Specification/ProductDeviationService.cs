using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class ProductDeviationService : IProductDeviationService
    {
        private readonly IMapper _mapper;
        private readonly IProductDeviationRepository _productDeviationRepository;
        public ProductDeviationService(IMapper mapper, IProductDeviationRepository productDeviationRepository)
        {
            _mapper = mapper;
            _productDeviationRepository = productDeviationRepository;

        }
        public async Task<IList<ProductDeviationDisplayModel>> GetAllProductDeviationAsync(ProductDeviationFilter productDeviationFilter)
        {
            var productDeviation = await _productDeviationRepository.GetAllProductDeviationAsync(productDeviationFilter);
            var productDeviationModel = _mapper.Map<List<ProductDeviationDisplayModel>>(productDeviation.ToList());
            return productDeviationModel;
        }


        public async Task<ProductDeviationModel> GetProductDeviationByIdAsync(int productDeviationId)
        {
            var productDeviation = await _productDeviationRepository.GetProductDeviationByIdAsync(productDeviationId);
            var productDeviationModel = _mapper.Map<ProductDeviationModel>(productDeviation);
            return productDeviationModel;
        }

        public async Task<string?> UpsertProductDeviationAsync(ProductDeviationModel productDeviationModel, string? userId)
        {
            ProductDeviationEntity productDeviationEntityObj = _mapper.Map<ProductDeviationEntity>(productDeviationModel);
            productDeviationEntityObj.UserId = userId;
            return await _productDeviationRepository.UpsertProductDeviationAsync(productDeviationEntityObj);
        }
        public async Task<string?> DeleteProductDeviationAsync(int productDeviationId, string? userId, int isActive)
        {
            return await _productDeviationRepository.DeleteProductDeviationAsync(productDeviationId, userId, isActive);
        }
    }
}
