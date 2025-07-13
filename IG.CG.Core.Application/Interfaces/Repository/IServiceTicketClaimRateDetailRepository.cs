using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IServiceTicketClaimRateDetailRepository
    {
        Task<IList<ServiceTicketClaimRateDetailEntity>> GetAllServiceTicketClaimRateDetailAsync(int serviceTicketId);
    }
}
