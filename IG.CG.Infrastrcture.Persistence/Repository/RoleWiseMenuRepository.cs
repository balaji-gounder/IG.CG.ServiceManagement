using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class RoleWiseMenuRepository : IRoleWiseMenuRepository
    {
        private readonly ISqlDbContext _roleWiseMenuRepository;
        public RoleWiseMenuRepository(ISqlDbContext roleWiseMenuRepository)
        {
            _roleWiseMenuRepository = roleWiseMenuRepository;
        }

        public async Task<string?> DeleteRoleWiseMenu(string roleCode)
        {
            var para = new DynamicParameters();
            para.Add("@RoleCode", roleCode);
            var result = await _roleWiseMenuRepository.ExecuteScalarAsync<string?>(RoleWiseMenuQueries.RoleWiseMenuDelete, para);
            return result;
        }







        public async Task<IList<RoleWiseMenuEntity>> GetAllRoleWiseMenu(string roleCode, int parentId = 0)
        {
            var para = new DynamicParameters();
            para.Add("@RoleCode", roleCode);
            para.Add("@ParentId", parentId);
            var lstRoles = await _roleWiseMenuRepository.GetAllAsync<RoleWiseMenuEntity>(RoleWiseMenuQueries.RoleWiseMenuGetAll, para);
            return lstRoles.ToList();
        }
        public async Task<IList<RoleWiseMenuEntity>> GetRoleWiseMenuByUser(string roleCode, int parentId = 0)
        {
            var para = new DynamicParameters();
            para.Add("@RoleCode", roleCode);
            para.Add("@ParentId", parentId);
            para.Add("@Mode", "1");
            var lstRoles = await _roleWiseMenuRepository.GetAllAsync<RoleWiseMenuEntity>(RoleWiseMenuQueries.RoleWiseMenuByUser, para);
            return lstRoles.ToList();
        }

        public async Task<IList<RoleWiseMenuEntity>> GetRoleWiseMenuByUserSelect(string roleCode, int parentId = 0)
        {
            var para = new DynamicParameters();
            para.Add("@RoleCode", roleCode);
            para.Add("@ParentId", parentId);
            para.Add("@Mode", "2");
            var lstRoles = await _roleWiseMenuRepository.GetAllAsync<RoleWiseMenuEntity>(RoleWiseMenuQueries.RoleWiseMenuByUser, para);
            return lstRoles.ToList();
        }


        public async Task<int?> AddRoleWiseMenu(string roleCode, string? userId, RoleWiseMenuEntity roleWiseMenus)
        {


            var para = new DynamicParameters();
            para.Add("@RoleCode", roleCode);
            para.Add("@MenuCode", roleWiseMenus.MenuCode);
            para.Add("@IsAdd", roleWiseMenus.IsAdd);
            para.Add("@IsEdit", roleWiseMenus.IsEdit);
            para.Add("@IsDelete", roleWiseMenus.IsDelete);
            para.Add("@IsView", roleWiseMenus.IsView);
            para.Add("@IsDownload", roleWiseMenus.IsDownload);
            para.Add("@IsUpload", roleWiseMenus.IsUpload);
            para.Add("@IsApproved", roleWiseMenus.IsApproved);
            para.Add("@ParentId", roleWiseMenus.ParentId);
            para.Add("@UserId", userId);
            var result = await _roleWiseMenuRepository.ExecuteScalarAsync<int?>(RoleWiseMenuQueries.RoleWiseMenuInsertUpdate, para);
            return result;
        }
    }
}
