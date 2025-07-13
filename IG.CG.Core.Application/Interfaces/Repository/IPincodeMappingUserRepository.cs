using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IPincodeMappingUserRepository
    {
        Task<IList<PincodeMappingUserDisplayEntity>> GetAllPincodeMappingUserAsync(BaseFilter baseFilter);
        Task<int?> AddPincodeMappingUser(string jsonData);

    }
}
