using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IUserGetByUserTypeService
    {
        Task<IList<UserGetByUserTypeModel>> GetAllUserGetByUserTypeAsync(UserGetByUserTypeFilter userTypeFilter);
    }
}
