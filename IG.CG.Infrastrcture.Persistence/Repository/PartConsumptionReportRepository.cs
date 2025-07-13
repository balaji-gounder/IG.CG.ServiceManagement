using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class PartConsumptionReportRepository:IPartConsumptionReportRepository
    {
        private readonly ISqlDbContext _PartConsumptionReportRepository;
        public PartConsumptionReportRepository(ISqlDbContext PartConsumptionReportRepository)
        {
            _PartConsumptionReportRepository = PartConsumptionReportRepository;
        }
        public async Task<IList<PartConsumptionReportEntity>> GetPartConsumptionReportAsync(PartConsumptionReportFilter partconsumptionreportFilter)
        {
            var para = new DynamicParameters();

            para.Add("@RegionCode", partconsumptionreportFilter.RegionCode);
            para.Add("@BranchCode", partconsumptionreportFilter.BranchCode);
            para.Add("@ASC", partconsumptionreportFilter.ASC);
            para.Add("@BusinessLine", partconsumptionreportFilter.BusinessLine);
            para.Add("@ProductDivisionCode", partconsumptionreportFilter.ProductDivisionCode);
            para.Add("ProductLineCode", partconsumptionreportFilter.ProductLineCode);
            para.Add("@FromDate", partconsumptionreportFilter.FromDate);
            para.Add("@ToDate", partconsumptionreportFilter.ToDate);
            para.Add("@PageSize", partconsumptionreportFilter.PageSize);
            para.Add("@PageNumber", partconsumptionreportFilter.PageNumber);
            para.Add("@UserID", partconsumptionreportFilter.UserID);
            var lstRegion = await _PartConsumptionReportRepository.GetAllAsync<PartConsumptionReportEntity>(ReportQueries.PartConsumptionReport, para);

            return lstRegion.ToList();
        }
    }
}
