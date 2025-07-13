using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IRoleWiseMenuRepository
    {
        Task<IList<RoleWiseMenuEntity>> GetAllRoleWiseMenu(string roleCode, int parentId = 0);
        Task<string?> DeleteRoleWiseMenu(string roleCode);
        Task<int?> AddRoleWiseMenu(string roleCode, string? userId, RoleWiseMenuEntity roleWiseMenus);
        Task<IList<RoleWiseMenuEntity>> GetRoleWiseMenuByUser(string roleCode, int parentId = 0);

        Task<IList<RoleWiseMenuEntity>> GetRoleWiseMenuByUserSelect(string roleCode, int parentId = 0);
    }
}
