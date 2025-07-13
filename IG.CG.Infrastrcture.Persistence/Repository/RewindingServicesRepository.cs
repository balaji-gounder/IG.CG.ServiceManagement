using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class RewindingServicesRepository : IRewindingServicesRepository
    {
        private readonly ISqlDbContext _rewindingServicesRepository;
        public RewindingServicesRepository(ISqlDbContext rewindingServicesRepository)
        {
            _rewindingServicesRepository = rewindingServicesRepository;
        }

        public async Task<IList<RewindingServicesDisplayEntity>> GetAllRewindingServicesAsync(RewindingServicesFilter rewindingServicesFilter)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceClaimTypeId", rewindingServicesFilter.ServiceClaimTypeId);
            var lstRewindingServices = await _rewindingServicesRepository.GetAllAsync<RewindingServicesDisplayEntity>(RewindingServicesQueries.AllRewindingServices, para);

            return lstRewindingServices.ToList();
        }

    }
}
