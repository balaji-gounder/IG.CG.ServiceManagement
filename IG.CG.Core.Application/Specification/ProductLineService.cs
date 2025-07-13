using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class ProductLineService : IProductLineService
    {
        private readonly IMapper _mapper;
        private readonly IProductLineRepository _productLineRepository;
        public ProductLineService(IMapper mapper, IProductLineRepository productLineRepository)
        {
            _mapper = mapper;
            _productLineRepository = productLineRepository;

        }

        public async Task<IList<ProductLineDisplayModel>> GetAllProductLineAsync(ProductLineFilter productLineFilter)
        {
            var productLine = await _productLineRepository.GetAllProductLineAsync(productLineFilter);
            var productLineModel = _mapper.Map<List<ProductLineDisplayModel>>(productLine.ToList());
            return productLineModel;
        }


        public async Task<ProductLineModel> GetProductLineByIdAsync(int productLineId)
        {
            var productLine = await _productLineRepository.GetProductLineByIdAsync(productLineId);
            var productLineModel = _mapper.Map<ProductLineModel>(productLine);
            return productLineModel;
        }

        public async Task<string?> UpsertProductLineAsync(ProductLineModel productLineModel, string? userId)
        {
            ProductLineEntity productLineObj = _mapper.Map<ProductLineEntity>(productLineModel);
            productLineObj.UserId = userId;
            return await _productLineRepository.UpsertProductLineAsync(productLineObj);
        }
        public async Task<string?> DeleteProductLineAsync(int productLineId, string? userId, int isActive)
        {
            return await _productLineRepository.DeleteProductLineAsync(productLineId, userId, isActive);
        }


        public async Task<IList<ProductLineDisplayModel>> GetProductLineByDivisionAsync(string divisionCode)
        {
            var productLine = await _productLineRepository.GetProductLineByDivisionAsync(divisionCode);
            var productLineModel = _mapper.Map<List<ProductLineDisplayModel>>(productLine.ToList());
            return productLineModel;
        }

    }
}
