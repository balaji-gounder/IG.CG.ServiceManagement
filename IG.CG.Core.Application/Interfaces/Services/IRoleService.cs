using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IRoleService
    {
        Task<IList<RoleModel>> GetAllRoleAsync(RoleFilter roleFilter);
        Task<RoleModel> GetRoleByIdAsync(int roleId);
        Task<string?> UpsertRoleAsync(RoleModel roleModel, string? userId);
        Task<string?> DeleteRoleAsync(int roleId, string? userId, int isActive);

        Task<IList<RoleModel>> GetAllRoleByUserTypeAsync(string UserTypeId);
    }
}
