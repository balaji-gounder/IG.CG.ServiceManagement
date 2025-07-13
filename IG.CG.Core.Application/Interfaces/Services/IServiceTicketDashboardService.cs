
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface IServiceTicketDashboardService
    {
        Task<ServiceTicketDashboardModel> GetAllRolesServiceTicketDashboardAsync(ServiceTicketDashboardFilter serviceTicketDashboardFilter, string? UserId);
        Task<AscTatPerformanceModel> GetAscTatPerformanceAsync(AscTatPerformanceFilter ascTatPerformanceFilter, string? UserId);

    }
}
