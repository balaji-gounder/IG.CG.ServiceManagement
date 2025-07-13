using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;
using System.Data;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class CostingReportRepository : ICostingReportRepository
    {
        private readonly ISqlDbContext _costingReportRepository;
        public CostingReportRepository(ISqlDbContext costingReportRepository)
        {
            _costingReportRepository = costingReportRepository;
        }

        public async Task<IList<CostingReportEntity>> GetCostingReportAsync(CostingReportFilter costingReportFilter)
        {
            var para = new DynamicParameters();

            para.Add("@RegionCode", costingReportFilter.RegionCode);
            para.Add("@BranchCode", costingReportFilter.BranchCode);
            para.Add("@ASC", costingReportFilter.ASC);
            para.Add("@ProductDivisionCode", costingReportFilter.ProductDivisionCode);
            para.Add("@ProductLine", costingReportFilter.ProductLine);
            para.Add("@FromDate", costingReportFilter.FromDate);
            para.Add("@ToDate", costingReportFilter.ToDate);
            para.Add("@PageSize", costingReportFilter.PageSize);
            para.Add("@PageNumber", costingReportFilter.PageNumber);
            para.Add("@UserID", costingReportFilter.UserID);
            var lstRegion = await _costingReportRepository.GetAllAsync<CostingReportEntity>(ReportQueries.AllServiceTicketClaimCostingReport, para, CommandType.StoredProcedure, 180);

            return lstRegion.ToList();
        }
    }
}
