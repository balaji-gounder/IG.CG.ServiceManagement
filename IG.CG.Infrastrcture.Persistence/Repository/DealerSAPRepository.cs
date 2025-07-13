using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class DealerSAPRepository : IDealerSAPRepository
    {
        private readonly ISqlDbContext _dbContext;

        public DealerSAPRepository(ISqlDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IList<DealerSAPEntity>> GetAllDealerSAPAsync(DealerSAPFilter dealerFilter)
        {
            var para = new DynamicParameters();
            para.Add("@Name", dealerFilter.Name);

            var lstDealer = await _dbContext.GetAllAsync<DealerSAPEntity>(DealerSAPQueries.GetAllSAPDealer, para);
            return lstDealer.ToList();
        }
    }
}
