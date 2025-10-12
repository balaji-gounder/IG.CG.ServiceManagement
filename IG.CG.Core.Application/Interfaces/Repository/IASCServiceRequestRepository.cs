using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IASCServiceRequestRepository
    {
        Task<IList<ASCServiceRequestEntity>> GetAllASCServiceRequestAsync(ASCServiceRequestFilter ascServiceRequestFilter, string? userId);
        Task<IList<ASCServiceRequestEntity>> GetAllASMServiceRequestAsync(ASCServiceRequestFilter asmServiceRequestFilter, string? userId);
        Task<IList<ASCServiceRequestEntity>> GetAllASCServiceRequestViewAsync(ASCServiceRequestViewAllFilter ascServiceRequestFilter);
        Task<IList<ASCServiceRequestEntity>> GetAllASCServiceRequestCancelledAsync(ASCServiceRequestFilter ascServiceRequestFilter, string? userId);

        Task<IList<ASCServiceRequestTotalCountEntity>> GetAllASCServiceRequestTotalCountAsync(ASCServiceRequestFilter ascServiceRequestFilter, string? userId);

        Task<IList<ASCServiceRequestEntity>> GetAllCallCenterRequestOpenTicketAsync(CallCenterRequestOpenTicketFilter ascServiceRequestFilter, string? userId);

        Task<IList<SerialNoWiseTicketEntity>> GetAlSerialNoWiseTicketAsync(string? seSrNo, string? ServiceTicketNumber);
    }
}
