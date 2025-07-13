using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Specification
{
    public class DashboardService : IDashboardService
    {
        private readonly IMapper _mapper;
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardService(IMapper mapper, IDashboardRepository dashboardreportrepository)
        {
            _mapper = mapper;
            _dashboardRepository = dashboardreportrepository;

        }
        public async Task<IList<DashboardModel>> GetDashBoardDetailsAsync(DashboardFilter dashboardfilter)
        {
            var dashboard = await _dashboardRepository.GetDashBoardDetailsAsync(dashboardfilter);
            var dashboardmodel = _mapper.Map<List<DashboardModel>>(dashboard.ToList());
            return dashboardmodel;
        }


        public async Task<IList<DashboardClaimModel>> GetDashBoardClaimDetailsAsync(DashboardFilter dashboardfilter)
        {
            var dashboard = await _dashboardRepository.GetDashBoardClaimDetailsAsync(dashboardfilter);
            var dashboardmodel = _mapper.Map<List<DashboardClaimModel>>(dashboard.ToList());
            return dashboardmodel;
        }


    }
}
