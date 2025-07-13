using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IAddRightsService
    {
        Task<string?> InsertUAddRightsAsync(UserAdditionalRightsModel userAddRightsModel, string? userId);
        Task<string?> DeleteUAddRightsAsync(int UAddAutoId, string? userId, int isActive); 
        Task<IList<UserAdditionalRightsModel>> GetAllUAddRightsAsync(UAddRightsFilter uaddRightsFilter);
    }
}
