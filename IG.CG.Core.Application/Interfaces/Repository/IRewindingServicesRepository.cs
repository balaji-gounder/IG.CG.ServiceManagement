using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IRewindingServicesRepository
    {
        Task<IList<RewindingServicesDisplayEntity>> GetAllRewindingServicesAsync(RewindingServicesFilter rewindingServicesFilter);

    }
}
