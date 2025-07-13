using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ISqlDbContext _DashboardRepository;
        public DashboardRepository(ISqlDbContext dashboardRepository)
        {
            _DashboardRepository = dashboardRepository;
        }
        public async Task<IList<DashboardEntity>> GetDashBoardDetailsAsync(DashboardFilter dashboardfilter)
        {
            var para = new DynamicParameters();
            para.Add("@vUserID", dashboardfilter.vUserID);
            para.Add("@FromDate", dashboardfilter.FromDate);
            para.Add("@ToDate", dashboardfilter.ToDate);
            para.Add("@DivisionCode", dashboardfilter.DivisionCode);
            para.Add("@RegionCode", dashboardfilter.RegionCode);
            para.Add("@BranchCode", dashboardfilter.BranchCode);
            para.Add("@ASC", dashboardfilter.ASC);
            para.Add("@ProductLine", dashboardfilter.ProductLineCode);

            var lstRegion = await _DashboardRepository.GetAllAsync<DashboardEntity>(ReportQueries.DashboardDetails, para);

            return lstRegion.ToList();
        }

        public async Task<IList<DashboardClaimEntity>> GetDashBoardClaimDetailsAsync(DashboardFilter dashboardfilter)
        {
            var para = new DynamicParameters();
            para.Add("@vUserID", dashboardfilter.vUserID);
            para.Add("@FromDate", dashboardfilter.FromDate);
            para.Add("@ToDate", dashboardfilter.ToDate);
            para.Add("@DivisionCode", dashboardfilter.DivisionCode);
            para.Add("@RegionCode", dashboardfilter.RegionCode);
            para.Add("@BranchCode", dashboardfilter.BranchCode);
            para.Add("@ASC", dashboardfilter.ASC);
            para.Add("@ProductLine", dashboardfilter.ProductLineCode);
            var lstRegion = await _DashboardRepository.GetAllAsync<DashboardClaimEntity>(ReportQueries.DashboardClaimDetails, para);

            return lstRegion.ToList();
        }


    }
}
