using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface IServiceTicketDashboardRepository
    {
        Task<ServiceTicketDashboardEntity> GetAllRolesServiceTicketDashboardAsync(ServiceTicketDashboardFilter serviceTicketDashboardFilter, string? UserId);
        Task<AscTatPerformanceEntity> GetAscTatPerformanceAsync(AscTatPerformanceFilter ascTatPerformanceFilter, string? UserId);

    }
}
