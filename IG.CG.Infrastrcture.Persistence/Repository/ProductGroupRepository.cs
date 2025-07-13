
using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class ProductGroupRepository : IProductGroupRepository
    {

        private readonly ISqlDbContext _productGroupRepository;
        public ProductGroupRepository(ISqlDbContext productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;
        }

        public async Task<string?> UpsertProductGroupAsync(ProductGroupEntity productGroupObj)
        {
            var para = new DynamicParameters();
            para.Add("@ProductGroupId", productGroupObj.ProductGroupId);
            para.Add("@ProductGroupName", productGroupObj.ProductGroupName);
            para.Add("@ProductGroupCode", productGroupObj.ProductGroupCode);
            para.Add("@DivisionCode", productGroupObj.DivisionCode);
            para.Add("@ProductLineCode", productGroupObj.ProductLineCode);
            para.Add("@ProductGroupDesc", productGroupObj.ProductGroupDesc);
            para.Add("@IsActive", productGroupObj.IsActive);
            para.Add("@UserId", productGroupObj.UserId);
            return await _productGroupRepository.ExecuteScalarAsync<string?>(ProductGroupQueries.UpsertProductGroup, para);
        }

        public async Task<string?> DeleteProductGroupAsync(int productGroupId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@ProductGroupId", productGroupId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _productGroupRepository.ExecuteScalarAsync<string?>(ProductGroupQueries.DeleteProductGroup, para);
        }


        public async Task<IList<ProductGroupDisplayEntity>> GetAllProductGroupAsync(ProductGroupFilter productGroupFilter)
        {
            var para = new DynamicParameters();
            para.Add("@ProductGroupName", productGroupFilter.ProductGroupName);
            para.Add("@DivisionCode", productGroupFilter.DivisionCode);
            para.Add("@ProductLineCode", productGroupFilter.ProductLineCode);
            para.Add("@PageSize", productGroupFilter.PageSize);
            para.Add("@PageNumber", productGroupFilter.PageNumber);
            var lstRegion = await _productGroupRepository.GetAllAsync<ProductGroupDisplayEntity>(ProductGroupQueries.AllProductGroup, para);
            return lstRegion.ToList();
        }

        public async Task<ProductGroupEntity?> GetProductGroupByIdAsync(int productGroupId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@ProductGroupId", productGroupId);
            return await _productGroupRepository.GetAsync<ProductGroupEntity>(ProductGroupQueries.GetProductGroupById, sp_params);
        }
    }
}
