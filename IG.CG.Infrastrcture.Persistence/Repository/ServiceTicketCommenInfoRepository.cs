using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class ServiceTicketCommenInfoRepository : IServiceTicketCommenInfoRepository
    {
        private readonly ISqlDbContext _SqlRepository;
        public ServiceTicketCommenInfoRepository(ISqlDbContext SqlRepository)
        {
            _SqlRepository = SqlRepository;
        }

        public async Task<string?> UpsertServiceTicketCommenInfoAsync(ServiceTicketCommenInfoEntitys regionObj)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", regionObj.ServiceTicketId);
            para.Add("@IsSendMailCustomer", regionObj.IsSendMailCustomer);
            para.Add("@Comment", regionObj.Comment);
            para.Add("@UserId", regionObj.UserId);
            return await _SqlRepository.ExecuteScalarAsync<string?>(ServiceTicketCommenQueries.UpsertServiceTicketCommenInfo, para);
        }

        public async Task<IList<ServiceTicketCommenInfoListEntitys>> GetAllServiceTicketCommenInfoAsync(string? ServiceTicketId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", ServiceTicketId);
            var lstRegion = await _SqlRepository.GetAllAsync<ServiceTicketCommenInfoListEntitys>(ServiceTicketCommenQueries.AllServiceTicketCommenInfoGet, para);
            return lstRegion.ToList();
        }


        public async Task<string?> UpsertServiceTicketEscalationInfoAsync(ServiceTicketCommenInfoEntitys regionObj)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", regionObj.ServiceTicketId);
            para.Add("@Comment", regionObj.Comment);
            para.Add("@UserId", regionObj.UserId);
            return await _SqlRepository.ExecuteScalarAsync<string?>(ServiceTicketCommenQueries.UpsertServiceTicketEscalationInfo, para);
        }

        public async Task<IList<ServiceTicketCommenInfoListEntitys>> GetAllServiceTicketEscalationInfoAsync(string? ServiceTicketId)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketId", ServiceTicketId);
            var lstRegion = await _SqlRepository.GetAllAsync<ServiceTicketCommenInfoListEntitys>(ServiceTicketCommenQueries.AllServiceTicketEscalationInfoGet, para);
            return lstRegion.ToList();
        }


    }
}
