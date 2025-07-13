using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class CustomerAssestRepository : ICustomerAssestRepository
    {
        private readonly ISqlDbContext _dbContext;

        public CustomerAssestRepository(ISqlDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<string?> UpsertCutomerAssetsAsync(CustomerAssestsEntity customerAssest)
        {
            var para = new DynamicParameters();
            para.Add("@CustWiseAssetId", customerAssest.CustWiseAssetId);
            para.Add("@CustAutoId", customerAssest.CustAutoId);
            para.Add("@DivisionCode", customerAssest.DivisionCode);
            para.Add("@ProductLineCode", customerAssest.ProductLineCode);
            para.Add("@ProductGroupCode", customerAssest.ProductGroupCode);
            para.Add("@ProductCode", customerAssest.ProductCode);
            para.Add("@ProductSerialNo", customerAssest.ProductSerialNo);
            para.Add("@Batch", customerAssest.Batch);
            para.Add("@WarrantyStartDateBatch", customerAssest.WarrantyStartDateBatch);
            para.Add("@WarrantyEndDateBatch", customerAssest.WarrantyEndDateBatch);
            para.Add("@InvoiceNo", customerAssest.InvoiceNo);
            para.Add("@InvoiceDate", customerAssest.InvoiceDate);
            para.Add("@WarrantyStartDateInvoice", customerAssest.WarrantyStartDateInvoice);
            para.Add("@WarrantyEndDateInvoice", customerAssest.WarrantyEndDateInvoice);
            para.Add("@WarrantyStatus", customerAssest.WarrantyStatus);
            para.Add("@InformationSource", customerAssest.InformationSource);
            para.Add("@DealerInvoiceDate", customerAssest.DealerInvoiceDate);
            para.Add("@DealerInvoiceNo", customerAssest.DealerInvoiceNo);
            para.Add("@IsActive", customerAssest.IsActive);
            para.Add("@UserId", customerAssest.UserId);
            return await _dbContext.ExecuteScalarAsync<string?>(CustomerAssestQueries.UpsertCustomerAssest, para);
        }

        public async Task<CustomerAssestsEntity?> GetCustomerAssestByIdAsync(int CustWiseAssetId)
        {
            var para = new DynamicParameters();
            para.Add("@CustWiseAssetId", CustWiseAssetId);
            return await _dbContext.GetAsync<CustomerAssestsEntity>(CustomerAssestQueries.GetCustomerAssetsById, para);
        }

        public async Task<IList<CustomerAssestDisplayEntity>> GetAllCustomerAssetsAsync(CustomerAssetFilter customerAssestFilter)
        {
            var para = new DynamicParameters();
            para.Add("@CustAutoId", customerAssestFilter.CustAutoId);
            para.Add("@ProductSerialNo", customerAssestFilter.ProductSerialNo);
            para.Add("@PageSize", customerAssestFilter.PageSize);
            para.Add("@PageNumber", customerAssestFilter.PageNumber);
            var lstCustomerAssest = await _dbContext.GetAllAsync<CustomerAssestDisplayEntity>(CustomerAssestQueries.GetAllCustomerAssest, para);
            return lstCustomerAssest.ToList();
        }

        public async Task<string?> DeleteCustomerAssestAsync(int CustWiseAssetId, string UserId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@CustWiseAssetId", CustWiseAssetId);
            para.Add("@UserId", UserId);
            para.Add("@IsActive", isActive);
            return await _dbContext.ExecuteScalarAsync<string?>(CustomerAssestQueries.DeleteCustomerAssest, para);
        }

        public async Task<CustomerAssestsEntity?> GetCustomerAssestBySAPSerialNoAsync(string SerialNo)
        {
            var para = new DynamicParameters();
            para.Add("@SerialNo", SerialNo);
            return await _dbContext.GetAsync<CustomerAssestsEntity>(CustomerAssestQueries.GetCustomerSAPAssetsBySerialNo, para);
        }
    }
}
