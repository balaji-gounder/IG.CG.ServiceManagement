

using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<IList<UserDisplayEntity>> GetAllUserAsync(UserFilter userFilter);
        Task<UserDisplayEntity?> GetUserByIdAsync(string userId);
        Task<IList<MasterEntity>> GetAllUserWishMstByUserIdAsync(MasterFilter userFilter);
        Task<string?> UpsertUserAsync(UserEntity userObj);
        Task<string?> DeleteUserAsync(int userAutoId, string userId, int isActive);
    }
}
