
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface ISTSubStatusService
    {
        Task<string?> UpsertSTSubStatusAsync(STSubStatusModel stSubStatusModel, string? userId);
        Task<IList<STSubStatusModel>> GetAllSTSubStatusAsync(STSubStatusFilter stSubStatusFilter);
        Task<STSubStatusModel> GetSTSubStatusByIdAsync(int stSubStatusId);
        Task<string?> DeleteSTSubStatusAsync(int stSubStatusId, string? userId, int isActive);
        Task<IList<STSubStatusModel>> GetSTSubStatusByStatusAsync(int stStatusId);
        Task<IList<STSubStatusByTypeModel>> GetAllSTSubStatusByTypeAsync(string? StatusType, int? ActiveId);
        Task<IList<ServiceTicketStatusModel>> GetServiceTicketStatusAsync(int? SubStatusid);



    }
}
