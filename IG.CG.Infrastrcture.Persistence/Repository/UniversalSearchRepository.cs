using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class UniversalSearchRepository : IUniversalSearchRepository
    {
        private readonly ISqlDbContext _universalSearchRepository;
        public UniversalSearchRepository(ISqlDbContext universalSearchRepository)
        {
            _universalSearchRepository = universalSearchRepository;
        }

        public async Task<IList<UniversalSearchEntity>> GetUniversalSearchAsync(UniversalSearchFilter universalSearchFilter)
        {
            var para = new DynamicParameters();

            para.Add("@vServiceTicketNumber", universalSearchFilter.ticketNumber);
            para.Add("@vMobileNumber", universalSearchFilter.mobile);

            var lstUnivSrch = await _universalSearchRepository.GetAllAsync<UniversalSearchEntity>(ReportQueries.AllServiceTicketUniversalSearch, para);

            return lstUnivSrch.ToList();
        }
    }
}
