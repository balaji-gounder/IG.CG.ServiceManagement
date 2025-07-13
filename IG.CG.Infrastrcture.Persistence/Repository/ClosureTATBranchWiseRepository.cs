using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class ClosureTATBranchWiseRepository : IClosureTATBranchWiseRepository
    {
        private readonly ISqlDbContext _ClosureTATBranchWiseRepository;
        public ClosureTATBranchWiseRepository(ISqlDbContext ClosureTATBranchWiseRepository)
        {
            _ClosureTATBranchWiseRepository = ClosureTATBranchWiseRepository;
        }
        public async Task<IList<ClosureTATBranchWiseEntity>> GetClosureTATBranchWiseReportAsync(ClosureTATBranchWiseFilter closureTATBranchWiseFilter)
        {
            var para = new DynamicParameters();

            para.Add("@RegionCode", closureTATBranchWiseFilter.RegionCode);
            para.Add("@BranchCode", closureTATBranchWiseFilter.BranchCode);
            para.Add("@ProductDivisionCode", closureTATBranchWiseFilter.ProductDivisionCode);
            para.Add("@ProductLineCode", closureTATBranchWiseFilter.ProductLineCode);
            para.Add("@FromDate", closureTATBranchWiseFilter.FromDate);
            para.Add("@ToDate", closureTATBranchWiseFilter.ToDate);
            para.Add("@UserID", closureTATBranchWiseFilter.UserID);

            var lstRegion = await _ClosureTATBranchWiseRepository.GetAllAsync<ClosureTATBranchWiseEntity>(ReportQueries.ClosureTATBranchWiseReport, para);

            return lstRegion.ToList();
        }


        public async Task<IList<ClosureTATBranchWiseEntity>> GetFIRClosureTATBranchWiseReportAsync(ClosureTATBranchWiseFilter closureTATBranchWiseFilter)
        {
            var para = new DynamicParameters();

            para.Add("@RegionCode", closureTATBranchWiseFilter.RegionCode);
            para.Add("@BranchCode", closureTATBranchWiseFilter.BranchCode);
            para.Add("@ProductDivisionCode", closureTATBranchWiseFilter.ProductDivisionCode);
            para.Add("@ProductLineCode", closureTATBranchWiseFilter.ProductLineCode);
            para.Add("@FromDate", closureTATBranchWiseFilter.FromDate);
            para.Add("@ToDate", closureTATBranchWiseFilter.ToDate);
            para.Add("@UserID", closureTATBranchWiseFilter.UserID);

            var lstRegion = await _ClosureTATBranchWiseRepository.GetAllAsync<ClosureTATBranchWiseEntity>(ReportQueries.FIRCClosureTATBranchWiseReport, para);

            return lstRegion.ToList();
        }


    }
}
