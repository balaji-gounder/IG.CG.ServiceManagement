using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IServiceTicketClaimRateDetailService
    {
        Task<IList<ServiceTicketClaimRateDetailModel>> GetAllServiceTicketClaimRateDetailAsync(int serviceTicketId);
    }
}
