using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IServiceTicketCommenInfoRepository
    {
        Task<string?> UpsertServiceTicketCommenInfoAsync(ServiceTicketCommenInfoEntitys CommentObj);
        Task<IList<ServiceTicketCommenInfoListEntitys>> GetAllServiceTicketCommenInfoAsync(string? ServiceTicketId);

        Task<string?> UpsertServiceTicketEscalationInfoAsync(ServiceTicketCommenInfoEntitys CommentObj);
        Task<IList<ServiceTicketCommenInfoListEntitys>> GetAllServiceTicketEscalationInfoAsync(string? ServiceTicketId);
    }
}
