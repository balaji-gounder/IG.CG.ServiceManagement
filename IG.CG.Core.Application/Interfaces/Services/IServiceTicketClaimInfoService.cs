using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IServiceTicketClaimInfoService
    {
        Task<string?> UpsertServiceTicketClaimInfoAsync(List<ServiceTicketClaimInfoModel> lstStCliamModel, string? userId, string? ServiceTicketId);

        Task<string?> UpsertServiceTicketDeviationClaimInfoAsync(ServiceTicketDeviationClaimInfoModel lstStCliamModel, string? userId);


    }
}
