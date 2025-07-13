using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class UAddRightsRepository : IUAddRightsRepository
    {
        private readonly ISqlDbContext _UAddRightRepository;
        public UAddRightsRepository(ISqlDbContext uAddRightRepository)
        {
            _UAddRightRepository = uAddRightRepository;
        }
        public async Task<string?> UpsertUAddRightsAsync(UserAdditionalRightsEntity uAddRightsObj)
        {
            var para = new DynamicParameters();
            para.Add("@UserCode", uAddRightsObj.UserCode);
            para.Add("@DivisionCode", uAddRightsObj.DivisionCode);
            para.Add("@PLCode", uAddRightsObj.PLCode);
            para.Add("@BranchCode", uAddRightsObj.BranchCode);
            para.Add("@IsActive", uAddRightsObj.IsActive);
            para.Add("@UserId", uAddRightsObj.UserId);
            return await _UAddRightRepository.ExecuteScalarAsync<string?>(UserQueries.UserAddRightsInsert, para);
        }
        public async Task<string?> DeleteUAddRightsAsync(int UAddAutoId, string? userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@UAddAutoId", UAddAutoId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _UAddRightRepository.ExecuteScalarAsync<string?>(UserQueries.UserAddRightsDelete, para);
        }
        public async Task<IList<UserAdditionalRightsEntity>> GetAllUAddRightsAsync(UAddRightsFilter uaddRightsFilter)
        {
            var para = new DynamicParameters();
            para.Add("@UserCode", uaddRightsFilter.UserCode);
            para.Add("@PageSize", uaddRightsFilter.PageSize);
            para.Add("@PageNumber", uaddRightsFilter.PageNumber);
            var lstuAddRights = await _UAddRightRepository.GetAllAsync<UserAdditionalRightsEntity>(UserQueries.UserAddRightsGetAll, para);
            return lstuAddRights.ToList();
        }


    }
}
