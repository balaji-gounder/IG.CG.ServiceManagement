using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class ServiceTicketClaimRateDetailRepository : IServiceTicketClaimRateDetailRepository
    {

        private readonly ISqlDbContext _SrclaimRepository;
        public ServiceTicketClaimRateDetailRepository(ISqlDbContext SrclaimRepository)
        {
            _SrclaimRepository = SrclaimRepository;
        }


        public async Task<IList<ServiceTicketClaimRateDetailEntity>> GetAllServiceTicketClaimRateDetailAsync(int serviceTicketId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", serviceTicketId);

            var lstTypeOfWorkDone = await _SrclaimRepository.GetAllAsync<ServiceTicketClaimRateDetailEntity>(ServiceTicketClaimRateQueries.AllServiceTicketClaimRateDetail, para);

            return lstTypeOfWorkDone.ToList();
        }
    }
}
