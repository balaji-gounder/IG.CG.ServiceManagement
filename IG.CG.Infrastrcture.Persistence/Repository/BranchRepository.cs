using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;


namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class BranchRepository : IBranchRepository
    {

        private readonly ISqlDbContext _branchRepository;
        public BranchRepository(ISqlDbContext branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<string?> UpsertBranchAsync(BranchEntity branchObj)
        {
            var para = new DynamicParameters();
            para.Add("@BranchId", branchObj.BranchId);
            para.Add("@BranchName", branchObj.BranchName);
            para.Add("@BranchCode", branchObj.BranchCode);
            para.Add("@RegionCode", branchObj.RegionCode);
            para.Add("@BranchAddress", branchObj.BranchAddress);
            para.Add("@StateId", branchObj.StateId);
            para.Add("@CityId", branchObj.CityId);
            para.Add("@CountryId", branchObj.CountryId);
            para.Add("@PinCode", branchObj.PinCode);
            para.Add("@Phone", branchObj.Phone);
            para.Add("@Email", branchObj.Email);
            para.Add("@Remarks", branchObj.Remarks);
            para.Add("@IsActive", branchObj.IsActive);
            para.Add("@UserId", branchObj.UserId);
            return await _branchRepository.ExecuteScalarAsync<string?>(BranchQueries.UpsertBranch, para);
        }

        public async Task<string?> DeleteBranchAsync(int branchId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@BranchId", branchId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _branchRepository.ExecuteScalarAsync<string?>(BranchQueries.DeleteBranch, para);
        }

        public async Task<IList<BranchDisplayEntity>> GetAllBranchAsync(BranchFilter branchFilter)
        {
            var para = new DynamicParameters();
            para.Add("@BranchName", branchFilter.BranchName);
            para.Add("@StateId", branchFilter.StateId);
            para.Add("@CityId", branchFilter.CityId);
            para.Add("@RegionCode", branchFilter.RegionCode);
            para.Add("@PageSize", branchFilter.PageSize);
            para.Add("@PageNumber", branchFilter.PageNumber);
            var lstRegion = await _branchRepository.GetAllAsync<BranchDisplayEntity>(BranchQueries.AllBranch, para);

            return lstRegion.ToList();
        }

        public async Task<BranchEntity?> GetBranchByIdAsync(int branchId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@BranchId", branchId);
            return await _branchRepository.GetAsync<BranchEntity>(BranchQueries.GetBranchById, sp_params);
        }


        public async Task<IList<BranchDisplayEntity>> GetAllUserWiseBranchAsync(BaseUserWishFilter branchFilter, string? userId)
        {
            var para = new DynamicParameters();
            para.Add("@RegionCode", branchFilter.Code);
            para.Add("@UserId", userId);

            var lstRegion = await _branchRepository.GetAllAsync<BranchDisplayEntity>(BranchQueries.AllUserWiseBranch, para);

            return lstRegion.ToList();
        }

    }
}
