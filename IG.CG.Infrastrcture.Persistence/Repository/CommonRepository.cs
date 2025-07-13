using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class CommonRepository : ICommonRepository
    {
        private readonly ISqlDbContext _commonRepository;
        public CommonRepository(ISqlDbContext commonRepository)
        {
            _commonRepository = commonRepository;
        }

        public async Task<IList<ParaTypeEntity>> GetAllCommonAsync(int mode, int Id, string Code)
        {
            var para = new DynamicParameters();
            para.Add("@Mode", mode);
            para.Add("@Id", Id);
            para.Add("@Code", Code);
            var lstType = await _commonRepository.GetAllAsync<ParaTypeEntity>(CommonQueries.GetAllData, para);
            return lstType.ToList();
        }

        public async Task<IList<ParaTypeEntity>> GetAllActivityStatusAsync(int ServiceTicketId, int ActivityType, string DivisionCode)
        {
            var para = new DynamicParameters();
            para.Add("@DivisionCode", DivisionCode);
            para.Add("@ActivityType", ActivityType);
            para.Add("@ServiceTicketId", ServiceTicketId);
            var lstType = await _commonRepository.GetAllAsync<ParaTypeEntity>(CommonQueries.ActivityStatusGetAll, para);
            return lstType.ToList();
        }

        public async Task<IList<ParaTypeEntity>> GetAllActivitySubStatusAsync(int ServiceTicketId, int ActivityStatusId)
        {
            var para = new DynamicParameters();

            para.Add("@ActivityStatusId", ActivityStatusId);
            para.Add("@ServiceTicketId", ServiceTicketId);
            var lstType = await _commonRepository.GetAllAsync<ParaTypeEntity>(CommonQueries.ActivitySubStatusGetAll, para);
            return lstType.ToList();
        }

        public async Task<IList<ParaTypeEntity>> GetAllClaimDeviationAsync(int ServiceTicketId, string DivisionCode)
        {
            var para = new DynamicParameters();

            para.Add("@ServiceTicketId", ServiceTicketId);
            para.Add("@DivisionCode", DivisionCode);
            var lstType = await _commonRepository.GetAllAsync<ParaTypeEntity>(CommonQueries.ActivityClaimDeviationGetAll, para);
            return lstType.ToList();
        }


        public async Task<IList<ProductLineFrontEntity>> GetAllProductLineFrontAsync(int? ProductLineFrontId)
        {
            var para = new DynamicParameters();
            para.Add("@ProductLineFrontId", ProductLineFrontId);
            var lstType = await _commonRepository.GetAllAsync<ProductLineFrontEntity>(CommonQueries.ProductLineFrontGetAll, para);
            return lstType.ToList();
        }

    }
}
