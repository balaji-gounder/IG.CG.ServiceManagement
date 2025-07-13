using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IRoleWiseMenuService
    {
        Task<IList<RoleWiseMenuModel>> GetAllRoleWiseMenu(string roleCode, int parentId = 0);
        Task<int?> AddRoleWiseMenu(string roleCode, string? userId, List<RoleWiseMenuModel> lstroleWiseMenus);
        Task<IList<RoleWiseMenuModel>> GetRoleWiseMenuByUser(string roleCode, int parentId = 0);

        Task<IList<RoleWiseMenuModel>> GetRoleWiseMenuByUserSelect(string roleCode, int parentId = 0);

    }
}
