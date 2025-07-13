

using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IUserService
    {

        Task<IList<UserDisplayModel>> GetAllUserAsync(UserFilter userFilter);
        Task<UserDisplayModel> GetUserByIdAsync(string userId);

        Task<IList<MasterModel>> GetAllUserWishMstByUserIdAsync(MasterFilter userFilter);
        Task<string?> UpsertUserAsync(UserModel userModel, string? userId);
        Task<string?> DeleteUserAsync(int userAutoId, string? userId, int isActive);


    }
}
