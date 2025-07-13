using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IDealerSAPService
    {
        Task<IList<DealerSAPModel>> GetAllDealerSAPAsync(DealerSAPFilter dealerFilter);
    }
}
