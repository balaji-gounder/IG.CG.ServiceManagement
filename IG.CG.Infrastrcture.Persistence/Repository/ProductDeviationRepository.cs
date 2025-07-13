using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;


namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class ProductDeviationRepository : IProductDeviationRepository
    {
        private readonly ISqlDbContext _productDeviationRepository;
        public ProductDeviationRepository(ISqlDbContext productDeviationRepository)
        {
            _productDeviationRepository = productDeviationRepository;
        }

        public async Task<IList<ProductDeviationDisplayEntity>> GetAllProductDeviationAsync(ProductDeviationFilter productDeviationFilter)
        {
            var para = new DynamicParameters();
            para.Add("@DivisionCode", productDeviationFilter.DivisionCode);
            para.Add("@ProductCode", productDeviationFilter.ProductCode);
            para.Add("@RoleCode", productDeviationFilter.RoleCode);
            para.Add("@PageSize", productDeviationFilter.PageSize);
            para.Add("@PageNumber", productDeviationFilter.PageNumber);
            var ProductDeviation = await _productDeviationRepository.GetAllAsync<ProductDeviationDisplayEntity>(ProductDeviationQueries.ProductDeviationAll, para);

            return ProductDeviation.ToList();
        }

        public async Task<ProductDeviationEntity?> GetProductDeviationByIdAsync(int productDeviationId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@ProductDeviationId", productDeviationId);
            return await _productDeviationRepository.GetAsync<ProductDeviationEntity>(ProductDeviationQueries.GetProductDeviationById, sp_params);
        }

        public async Task<string?> UpsertProductDeviationAsync(ProductDeviationEntity productDeviationObj)
        {
            var para = new DynamicParameters();
            para.Add("@ProductDeviationId", productDeviationObj.ProdDevAutoId);
            para.Add("@DivisionCode", productDeviationObj.DivisionCode);
            para.Add("@ProductCode", productDeviationObj.ProductCode);
            para.Add("@RoleCode", productDeviationObj.RoleCode);
            para.Add("@NoOfDevMonth", productDeviationObj.NoOfDevMonth);
            para.Add("@IsActive", productDeviationObj.IsActive);
            para.Add("@UserId", productDeviationObj.UserId);
            return await _productDeviationRepository.ExecuteScalarAsync<string?>(ProductDeviationQueries.UpsertProductDeviation, para);
        }
        public async Task<string?> DeleteProductDeviationAsync(int productDeviationId, string? userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@ProductDeviationId", productDeviationId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _productDeviationRepository.ExecuteScalarAsync<string?>(ProductDeviationQueries.DeleteProductDeviation, para);
        }
    }
}
