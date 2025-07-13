
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface ISpareService
    {

        Task<string?> UpsertSpareAsync(SpareModel spareModel, string? userId);
        Task<SpareModel?> GetSpareByIdAsync(int SpareId);
        Task<IList<SpareDisplayModel>> GetAllSpareAsync(SpareFilter spareFilter);
        Task<string?> DeleteSpareAsync(int SpareId, string? userId, int isActive);


    }
}
