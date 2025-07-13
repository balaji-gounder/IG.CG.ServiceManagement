using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IUserGetByUserTypeRepository
    {
        Task<IList<UserGetByUserTypeEntity>> GetAllUserGetByUserTypeAsync(UserGetByUserTypeFilter userTypeFilter);
    }
}
