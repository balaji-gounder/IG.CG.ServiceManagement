using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ISqlDbContext _roleRepository;
        public RoleRepository(ISqlDbContext roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<string?> UpsertRoleAsync(RoleEntity roleObj)
        {
            var para = new DynamicParameters();
            para.Add("@RoleId", roleObj.RoleId);
            para.Add("@RoleCode", roleObj.RoleCode);
            para.Add("@RoleName", roleObj.RoleName);
            para.Add("@RoleDesc", roleObj.RoleDesc);
            para.Add("@ReportingTo", roleObj.ReportingTo);
            para.Add("@IsActive", roleObj.IsActive);
            para.Add("@RightTypeId", roleObj.RightTypeId);
            para.Add("@UserTypeId", roleObj.UserTypeId);
            para.Add("@IsMultipleBranch", roleObj.IsMultipleBranch);
            para.Add("@IsMultipleDivision", roleObj.IsMultipleDivision);
            para.Add("@IsDeviation", roleObj.IsDeviation);

            para.Add("@UserId", roleObj.UserId);
            return await _roleRepository.ExecuteScalarAsync<string?>(RoleQueries.UpsertRole, para);
        }
        public async Task<string?> DeleteRoleAsync(int roleId, string? userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@RoleId", roleId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _roleRepository.ExecuteScalarAsync<string?>(RoleQueries.DeleteRole, para);
        }
        public async Task<IList<RoleEntity>> GetAllRoleAsync(RoleFilter roleFilter)
        {
            var para = new DynamicParameters();
            para.Add("@ReportingTo", roleFilter.ReportingTo);
            para.Add("@RoleName", roleFilter.RoleName);
            para.Add("@RightTypeId", roleFilter.RightTypeId);
            para.Add("@PageSize", roleFilter.PageSize);
            para.Add("@PageNumber", roleFilter.PageNumber);
            var lstRoles = await _roleRepository.GetAllAsync<RoleEntity>(RoleQueries.AllRoles, para);
            return lstRoles.ToList();
        }
        public async Task<RoleEntity?> GetRoleByIdAsync(int roleId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@RoleId", roleId);
            return await _roleRepository.GetAsync<RoleEntity>(RoleQueries.GetRoleById, sp_params);
        }


        public async Task<IList<RoleEntity>> GetAllRoleByUserTypeAsync(string UserTypeId)
        {
            var para = new DynamicParameters();
            para.Add("@UserTypeId", UserTypeId);

            var lstRoles = await _roleRepository.GetAllAsync<RoleEntity>(RoleQueries.AllRolesByUserType, para);
            return lstRoles.ToList();
        }
    }
}
