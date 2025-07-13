using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IDashboardRepository
    {
        Task<IList<DashboardEntity>> GetDashBoardDetailsAsync(DashboardFilter dashboardFilter);

        Task<IList<DashboardClaimEntity>> GetDashBoardClaimDetailsAsync(DashboardFilter dashboardFilter);
    }
}
