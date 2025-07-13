using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Application.Models.Filters;

namespace IG.CG.Core.Application.Specification
{
    public class ServiceTicketDashboardService : IServiceTicketDashboardService
    {
        private readonly IMapper _mapper;
        private readonly IServiceTicketDashboardRepository _serviceTicketDashboardRepository;
        public ServiceTicketDashboardService(IMapper mapper, IServiceTicketDashboardRepository serviceTicketDashboardRepository)
        {
            _mapper = mapper;
            _serviceTicketDashboardRepository = serviceTicketDashboardRepository;

        }

        public async Task<ServiceTicketDashboardModel> GetAllRolesServiceTicketDashboardAsync(ServiceTicketDashboardFilter serviceTicketDashboardFilter, string? UserId)
        {
            var Dashboard = await _serviceTicketDashboardRepository.GetAllRolesServiceTicketDashboardAsync(serviceTicketDashboardFilter,UserId);
            var DashboardModel = _mapper.Map<ServiceTicketDashboardModel>(Dashboard);
            return DashboardModel;
        }

        public async Task<AscTatPerformanceModel> GetAscTatPerformanceAsync(AscTatPerformanceFilter ascTatPerformanceFilter, string? UserId)
        {
            var AscTatPerfomance = await _serviceTicketDashboardRepository.GetAscTatPerformanceAsync(ascTatPerformanceFilter, UserId);
            var AscTatPerfomanceModel = _mapper.Map<AscTatPerformanceModel>(AscTatPerfomance);
            return AscTatPerfomanceModel;
        }

    }
}
