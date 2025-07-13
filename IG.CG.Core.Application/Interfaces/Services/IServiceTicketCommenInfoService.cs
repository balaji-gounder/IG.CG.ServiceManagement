using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IServiceTicketCommenInfoService
    {
        Task<string?> UpsertServiceTicketCommenInfoAsync(ServiceTicketCommenInfoModel regionObj, string? userId);
        Task<IList<ServiceTicketCommenInfoListModel>> GetAllServiceTicketCommenInfoAsync(string? ServiceTicketId);

        Task<string?> UpsertServiceTicketEscalationInfoAsync(ServiceTicketCommenInfoModel regionObj, string? userId);
        Task<IList<ServiceTicketCommenInfoListModel>> GetAllServiceTicketEscalationInfoAsync(string? ServiceTicketId);

    }
}
