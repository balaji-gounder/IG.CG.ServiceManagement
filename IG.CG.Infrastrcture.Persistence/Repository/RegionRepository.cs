using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{

    public class RegionRepository : IRegionRepository
    {

        private readonly ISqlDbContext _regionRepository;
        public RegionRepository(ISqlDbContext rgionRepository)
        {
            _regionRepository = rgionRepository;
        }


        public async Task<string?> UpsertRegionAsync(RegionEntity regionObj)
        {
            var para = new DynamicParameters();
            para.Add("@RegionId", regionObj.RegionId);
            para.Add("@RegionName", regionObj.RegionName);
            para.Add("@RegionCode", regionObj.RegionCode);
            para.Add("@Remarks", regionObj.Remarks);
            para.Add("@IsActive", regionObj.IsActive);
            para.Add("@UserId", regionObj.UserId);
            return await _regionRepository.ExecuteScalarAsync<string?>(RegionQueries.UpsertRegion, para);
        }

        public async Task<string?> DeleteRegionAsync(int regionId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@RegionId", regionId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _regionRepository.ExecuteScalarAsync<string?>(RegionQueries.DeleteRegion, para);
        }

        public async Task<IList<RegionEntity>> GetAllRegionAsync(RegionFilter regionFilter)
        {
            var para = new DynamicParameters();
            para.Add("@RegionName", regionFilter.RegionName);
            para.Add("@PageSize", regionFilter.PageSize);
            para.Add("@PageNumber", regionFilter.PageNumber);
            var lstRegion = await _regionRepository.GetAllAsync<RegionEntity>(RegionQueries.AllRegion, para);

            return lstRegion.ToList();
        }

        public async Task<IList<RegionEntity>> GetAllUserwiseRegionAsync(string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@userId", userId);
            var lstRegion = await _regionRepository.GetAllAsync<RegionEntity>(RegionQueries.GetUserwiseRegion, para);
            return lstRegion.ToList();
        }


        public async Task<RegionEntity?> GetRegionByIdAsync(int regionId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@RegionId", regionId);
            return await _regionRepository.GetAsync<RegionEntity>(RegionQueries.GetRegionById, sp_params);
        }
    }

}
