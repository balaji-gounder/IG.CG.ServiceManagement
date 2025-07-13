
using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IPincodeMappingUserService
    {
        Task<IList<PincodeMappingUserDisplayModel>> GetAllPincodeMappingUserAsync(BaseFilter baseFilter);

    }
}
