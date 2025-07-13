using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class DealerRepository : IDealerRepository
    {
        private readonly ISqlDbContext _dbContext;

        public DealerRepository(ISqlDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<string?> UpsertDealerAsync(DealerEntity dealerEntity)
        {

            var para = new DynamicParameters();
            para.Add("@DealerId", dealerEntity.DealerId);
            para.Add("@DealerCode", dealerEntity.DealerCode);
            para.Add("@DealerTypeId", dealerEntity.DealerTypeId);
            para.Add("@DealerName", dealerEntity.DealerName);
            para.Add("@DealerEmail", dealerEntity.DealerEmail);
            para.Add("@MobileNo", dealerEntity.MobileNo);
            para.Add("@IsIndustryCustomer", dealerEntity.IsIndustryCustomer);
            para.Add("@isGSTApplicable", dealerEntity.isGSTApplicable);
            para.Add("@IsActive", dealerEntity.IsActive);
            para.Add("@GSTNo", dealerEntity.GSTNo);
            para.Add("@WorkingDays", dealerEntity.WorkingDays);
            para.Add("@Address", dealerEntity.Address);
            para.Add("@StateId", dealerEntity.StateId);
            para.Add("@CityId", dealerEntity.CityId);
            para.Add("@PinCode", dealerEntity.PinCode);
            para.Add("@UserId", dealerEntity.UserId);
            return await _dbContext.ExecuteScalarAsync<string>(DealerQueries.UpsertDealer, para);
        }
        public async Task<DealerEntity?> GetDealerByIdAsync(int dealerId)
        {
            var para = new DynamicParameters();
            para.Add("@DealerId", dealerId);
            return await _dbContext.GetAsync<DealerEntity>(DealerQueries.GetDealerById, para);
        }
        public async Task<IList<DealerDisplayEntity>> GetAllDealerAsync(DealerFilter baseFilter)
        {
            var para = new DynamicParameters();
            para.Add("@DealerName", baseFilter.DealerName);
            para.Add("@DealerTypeId", baseFilter.DealerTypeId);
            para.Add("@PageSize", baseFilter.PageSize);
            para.Add("@PageNumber", baseFilter.PageNumber);
            var lstDealer = await _dbContext.GetAllAsync<DealerDisplayEntity>(DealerQueries.GetAllDealer, para);
            return lstDealer.ToList();
        }

        public async Task<string?> DeleteDealerAsync(int dealerId, string? userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@DealerId", dealerId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _dbContext.ExecuteScalarAsync<string?>(DealerQueries.DeleteDealer, para);
        }

        public async Task<DealerEntity?> GetDealerByCodeAsync(string? DealerCode)
        {
            var para = new DynamicParameters();
            para.Add("@DealerCode", DealerCode);
            return await _dbContext.GetAsync<DealerEntity>(DealerQueries.GetDealerByCode, para);
        }


        public async Task<DealerEntity?> GetDealerByNameAsync(string? DealerName)
        {
            var para = new DynamicParameters();
            para.Add("@DealerName", DealerName);
            return await _dbContext.GetAsync<DealerEntity>(DealerQueries.GetDealerByName, para);
        }


        public async Task<string?> UpsertRetailerAsync(DealerEntity dealerEntity)
        {

            var para = new DynamicParameters();
            para.Add("@DealerId", dealerEntity.DealerId);
            para.Add("@DealerCode", dealerEntity.DealerCode);
            para.Add("@DealerTypeId", dealerEntity.DealerTypeId);
            para.Add("@DealerName", dealerEntity.DealerName);
            para.Add("@DealerEmail", dealerEntity.DealerEmail);
            para.Add("@MobileNo", dealerEntity.MobileNo);
            para.Add("@IsIndustryCustomer", dealerEntity.IsIndustryCustomer);
            para.Add("@isGSTApplicable", dealerEntity.isGSTApplicable);
            para.Add("@IsActive", dealerEntity.IsActive);
            para.Add("@GSTNo", dealerEntity.GSTNo);
            para.Add("@WorkingDays", dealerEntity.WorkingDays);
            para.Add("@Address", dealerEntity.Address);
            para.Add("@StateId", dealerEntity.StateId);
            para.Add("@CityId", dealerEntity.CityId);
            para.Add("@PinCode", dealerEntity.PinCode);
            para.Add("@UserId", dealerEntity.UserId);


            return await _dbContext.ExecuteScalarAsync<string>(DealerQueries.UpsertRetailer, para);
        }


        public async Task<IList<DealerDisplayEntity>> GetDealerAndOEMAsync(string DealerTypeId)
        {
            var para = new DynamicParameters();
            para.Add("@DealerTypeId", DealerTypeId);
            var lstDealer = await _dbContext.GetAllAsync<DealerDisplayEntity>(DealerQueries.GetAllDealerAndOEMGetAll, para);
            return lstDealer.ToList();
        }
    }
}
