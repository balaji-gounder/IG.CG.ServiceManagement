
using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class ServiceTicketDashboardRepository : IServiceTicketDashboardRepository
    {

        private readonly ISqlDbContext _serviceTicketDashboardRepository;
        public ServiceTicketDashboardRepository(ISqlDbContext serviceTicketDashboardRepository)
        {
            _serviceTicketDashboardRepository = serviceTicketDashboardRepository;
        }

        public async Task<ServiceTicketDashboardEntity> GetAllRolesServiceTicketDashboardAsync(ServiceTicketDashboardFilter serviceTicketDashboardFilter, string? UserId)
        {
            var para = new DynamicParameters();
            para.Add("@UserId", UserId);
            para.Add("@FromDate", serviceTicketDashboardFilter.FromDate);
            para.Add("@ToDate", serviceTicketDashboardFilter.ToDate);
            para.Add("@Mode", 1);
            para.Add("@AscCode", serviceTicketDashboardFilter.AscCode);
            para.Add("@AsmCode", serviceTicketDashboardFilter.AsmCode);
            para.Add("@BranchCode", serviceTicketDashboardFilter.BranchCode);
            para.Add("@RegionCode", serviceTicketDashboardFilter.RegionCode);
            para.Add("@DivisionCode", serviceTicketDashboardFilter.DivisionCode);
            return await _serviceTicketDashboardRepository.GetAsync<ServiceTicketDashboardEntity>(ServiceTicketDashboardQueries.GetServiceTicketDashboard, para);

        }

        public async Task<AscTatPerformanceEntity> GetAscTatPerformanceAsync(AscTatPerformanceFilter ascTatPerformanceFilter, string? UserId)
        {
            var para = new DynamicParameters();
            para.Add("@UserId", UserId);
            para.Add("@FromDate", ascTatPerformanceFilter.FromDate);
            para.Add("@ToDate", ascTatPerformanceFilter.ToDate);
            return await _serviceTicketDashboardRepository.GetAsync<AscTatPerformanceEntity>(ServiceTicketDashboardQueries.GetAscTatPerformance, para);

        }

    }
}
