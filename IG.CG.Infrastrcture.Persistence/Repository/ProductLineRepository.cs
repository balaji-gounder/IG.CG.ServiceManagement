using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;


namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class ProductLineRepository : IProductLineRepository
    {
        private readonly ISqlDbContext _productLineRepository;
        public ProductLineRepository(ISqlDbContext productLineRepository)
        {
            _productLineRepository = productLineRepository;
        }
        public async Task<string?> UpsertProductLineAsync(ProductLineEntity productLineObj)
        {
            var para = new DynamicParameters();
            para.Add("@ProductLineID", productLineObj.ProductLineID);
            para.Add("@ProductLineName", productLineObj.ProductLineName);
            para.Add("@ProductLineCode", productLineObj.ProductLineCode);
            para.Add("@DivisionCode", productLineObj.DivisionCode);
            para.Add("@ProductLineRemarks", productLineObj.ProductLineRemarks);
            para.Add("@IsActive", productLineObj.IsActive);
            para.Add("@UserId", productLineObj.UserId);
            para.Add("@IsProductGroupRequired", productLineObj.IsProductGroupRequired);

            return await _productLineRepository.ExecuteScalarAsync<string?>(ProductLineQueries.UpsertProductLine, para);
        }

        public async Task<string?> DeleteProductLineAsync(int productLineId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@ProductLineID", productLineId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _productLineRepository.ExecuteScalarAsync<string?>(ProductLineQueries.DeleteProductLine, para);
        }
        public async Task<IList<ProductLineDisplayEntity>> GetAllProductLineAsync(ProductLineFilter productLineFilter)
        {
            var para = new DynamicParameters();
            para.Add("@ProductLineName", productLineFilter.ProductLineName);
            para.Add("@DivisionCode", productLineFilter.DivisionCode);

            para.Add("@PageSize", productLineFilter.PageSize);
            para.Add("@PageNumber", productLineFilter.PageNumber);
            var lstRegion = await _productLineRepository.GetAllAsync<ProductLineDisplayEntity>(ProductLineQueries.AllProductLine, para);

            return lstRegion.ToList();
        }


        public async Task<ProductLineEntity?> GetProductLineByIdAsync(int productLineId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@ProductLineId", productLineId);
            return await _productLineRepository.GetAsync<ProductLineEntity>(ProductLineQueries.GetProductLineById, sp_params);
        }


        public async Task<IList<ProductLineDisplayEntity>> GetProductLineByDivisionAsync(string divisionCode)
        {
            var para = new DynamicParameters();
            para.Add("@divisionCode", divisionCode);

            var lstRegion = await _productLineRepository.GetAllAsync<ProductLineDisplayEntity>(ProductLineQueries.DivisionWiseProductLine, para);

            return lstRegion.ToList();
        }



    }
}
