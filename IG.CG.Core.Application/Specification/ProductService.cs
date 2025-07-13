using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;

        }

        public async Task<IList<ProductDisplayModel>> GetAllProductAsync(ProductFilter productFilter)
        {
            var product = await _productRepository.GetAllProductAsync(productFilter);
            var productModel = _mapper.Map<List<ProductDisplayModel>>(product.ToList());
            return productModel;
        }


        public async Task<IList<ProductDisplayModel>> GetAllProductListAsync(string? DivisionCode, string? ProductLineCode)
        {
            var product = await _productRepository.GetAllProductListAsync(DivisionCode, ProductLineCode);
            var productModel = _mapper.Map<List<ProductDisplayModel>>(product.ToList());
            return productModel;
        }




        public async Task<ProductDisplayModel> GetProductByIdAsync(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            var productModel = _mapper.Map<ProductDisplayModel>(product);
            return productModel;
        }


        public async Task<string?> UpsertProductAsync(ProductModel productModel, string? userId)
        {
            ProductEntity productObj = _mapper.Map<ProductEntity>(productModel);
            productObj.UserId = userId;
            return await _productRepository.UpsertProductAsync(productObj);
        }
        public async Task<string?> DeleteProductAsync(int productId, string? userId, int isActive)
        {
            return await _productRepository.DeleteProductAsync(productId, userId, isActive);
        }

    }
}
