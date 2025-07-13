using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface ISpareRepository
    {
        Task<string?> UpsertSpareAsync(SpareEntity spareObj);
        Task<SpareEntity?> GetSpareByIdAsync(int SpareId);
        Task<IList<SpareDisplayEntity>> GetAllSpareAsync(SpareFilter spareFilter);
        Task<string?> DeleteSpareAsync(int SpareId, string? userId, int isActive);


    }
}
