using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;
using System.Data;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class OEMRepository:IOEMRepository
    {
        private readonly ISqlDbContext _oemRepository;
        public OEMRepository(ISqlDbContext oemRepository)
        {
            _oemRepository = oemRepository;
        }
        public async Task<IList<OEMEntity>> GetOEMDataAsync(OEMFilter oemFilter)
        {
            var para = new DynamicParameters();

            para.Add("@DealerName", oemFilter.DealerName);
            para.Add("@DealerTypeId", oemFilter.DealerTypeId);
            
            var lstRegion = await _oemRepository.GetAllAsync<OEMEntity>(ReportQueries.GETOEMDATA, para, CommandType.StoredProcedure, 180);

            return lstRegion.ToList();
        }

        public async Task<string?> UpsertOEMAsync(int ServiceTicketID, string? OEM)
        {
            var para = new DynamicParameters();
            para.Add("@ServiceTicketID", ServiceTicketID);
            para.Add("@OEM",OEM);

            return await _oemRepository.ExecuteScalarAsync<string?>(ReportQueries.UpsertOEM, para);
        }
    }
}
