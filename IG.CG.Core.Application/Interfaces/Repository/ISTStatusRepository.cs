

using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface ISTStatusRepository
    {
        Task<string?> UpsertSTStatusAsync(STStatusEntity stStatusObj);
        Task<IList<STStatusEntity>> GetAllSTStatusAsync(STStatusFilter stStatusFilter);
        Task<STStatusEntity?> GetSTStatusByIdAsync(int stStatusId);
        Task<string?> DeleteSTStatusAsync(int stStatusId, string? userId, int isActive);



    }
}
