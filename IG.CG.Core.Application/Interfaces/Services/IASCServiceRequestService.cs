
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IASCServiceRequestService
    {
        Task<IList<ASCServiceRequestModel>> GetAllASCServiceRequestAsync(ASCServiceRequestFilter ascServiceRequestFilter, string? userId);
        Task<IList<ASCServiceRequestModel>> GetAllASMServiceRequestAsync(ASCServiceRequestFilter ascServiceRequestFilter, string? userId);
        Task<IList<ASCServiceRequestModel>> GetAllASCServiceRequestViewAsync(ASCServiceRequestViewAllFilter ascServiceRequestFilter);
        Task<IList<ASCServiceRequestModel>> GetAllASCServiceRequestCancelledAsync(ASCServiceRequestFilter ascServiceRequestFilter, string? userId);

        Task<IList<ASCServiceRequestTotalCountModel>> GetAllASCServiceRequestTotalCountAsync(ASCServiceRequestFilter ascServiceRequestFilter, string? userId);

        Task<IList<ASCServiceRequestModel>> GetAllCallCenterRequestOpenTicketAsync(CallCenterRequestOpenTicketFilter ascServiceRequestFilter, string? userId);

        Task<IList<SerialNoWiseTicketModel>> GetAlSerialNoWiseTicketAsync(string? seSrNo,string? ServiceTicketNumber);
    }
}
