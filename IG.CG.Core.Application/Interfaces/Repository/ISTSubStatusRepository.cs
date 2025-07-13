using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface ISTSubStatusRepository
    {
        Task<string?> UpsertSTSubStatusAsync(STSubStatusEntity stSubStatusObj);
        Task<IList<STSubStatusEntity>> GetAllSTSubStatusAsync(STSubStatusFilter stSubStatusFilter);
        Task<STSubStatusEntity?> GetSTSubStatusByIdAsync(int stSubStatusId);
        Task<string?> DeleteSTSubStatusAsync(int stSubStatusId, string? userId, int isActive);
        Task<IList<STSubStatusEntity>> GetSTSubStatusByStatusAsync(int stStatusId);
        Task<IList<STSubStatusByTypeEntity>> GetAllSTSubStatusByTypeAsync(string? StatusType, int? ActiveId);
        Task<IList<ServiceTicketStatusEntity>> GetServiceTicketStatusAsync(int? SubStatusid);


    }
}
