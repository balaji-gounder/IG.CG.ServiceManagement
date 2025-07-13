
using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface ISTStatusService
    {
        Task<string?> UpsertSTStatusAsync(STStatusModel stStatusModel, string? userId);
        Task<IList<STStatusModel>> GetAllSTStatusAsync(STStatusFilter stStatusFilter);
        Task<STStatusModel> GetSTStatusByIdAsync(int stStatusId);
        Task<string?> DeleteSTStatusAsync(int stStatusId, string? userId, int isActive);

    }
}
