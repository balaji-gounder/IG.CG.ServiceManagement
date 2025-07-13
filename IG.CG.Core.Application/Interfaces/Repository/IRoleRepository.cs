using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IRoleRepository
    {
        Task<IList<RoleEntity>> GetAllRoleAsync(RoleFilter roleFilter);

        Task<IList<RoleEntity>> GetAllRoleByUserTypeAsync(string UserTypeId);
        Task<RoleEntity?> GetRoleByIdAsync(int roleId);
        Task<string?> UpsertRoleAsync(RoleEntity roleObj);
        Task<string?> DeleteRoleAsync(int roleId, string? userId, int isActive);
    }
}
