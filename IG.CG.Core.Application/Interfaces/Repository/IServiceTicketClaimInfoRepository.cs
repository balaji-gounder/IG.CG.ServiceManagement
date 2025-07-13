using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IServiceTicketClaimInfoRepository
    {
        Task<string?> UpsertServiceTicketClaimInfoAsync(ServiceTicketClaimInfoEntity StClaimObj, string? userId);
        Task<string?> UpsertServiceTicketDeviationClaimInfoAsync(ServiceTicketDeviationClaimInfoEntity StClaimObj);

        Task<string?> UpsertClaimStatusAsync(string? ServiceTicketId, string? userId);
    }
}
