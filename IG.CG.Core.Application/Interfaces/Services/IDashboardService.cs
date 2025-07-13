using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IDashboardService
    {
        Task<IList<DashboardModel>> GetDashBoardDetailsAsync(DashboardFilter dashboardFilter);

        Task<IList<DashboardClaimModel>> GetDashBoardClaimDetailsAsync(DashboardFilter dashboardFilter);
    }
}
