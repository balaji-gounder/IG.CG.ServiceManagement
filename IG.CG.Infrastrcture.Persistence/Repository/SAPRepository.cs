using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class SAPRepository : ISAPRepository
    {
        private readonly ISqlDbContext _sapRepository;
        public SAPRepository(ISqlDbContext sapRepository)
        {
            _sapRepository = sapRepository;
        }



        public async Task<IList<SAPDataEnitity>> GetAllSAPAsync(SAPCommonFilter SapFilter)
        {
            var para = new DynamicParameters();
            para.Add("@Id", SapFilter.Id);
            para.Add("@Name", SapFilter.Name);
            para.Add("@Mode", SapFilter.Mode);
            var lstRegion = await _sapRepository.GetAllAsync<SAPDataEnitity>(SAPQueries.SAPData, para);
            return lstRegion.ToList();
        }
    }
}
