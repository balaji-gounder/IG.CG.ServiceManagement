
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IRewindingServicesService
    {
        Task<IList<RewindingServicesDisplayModel>> GetAllRewindingServicesAsync(RewindingServicesFilter rewindingServicesFilter);

    }
}
