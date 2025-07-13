
using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class STSubStatusRepository : ISTSubStatusRepository
    {
        private readonly ISqlDbContext _stSubStatusRepository;
        public STSubStatusRepository(ISqlDbContext stSubStatusRepository)
        {
            _stSubStatusRepository = stSubStatusRepository;

        }

        public async Task<string?> UpsertSTSubStatusAsync(STSubStatusEntity stSubStatusObj)
        {
            var para = new DynamicParameters();
            para.Add("@STSubStatusId", stSubStatusObj.STSubStatusId);
            para.Add("@STStatusId", stSubStatusObj.STStatusId);
            para.Add("@STSubStatusName", stSubStatusObj.STSubStatusName);
            para.Add("@UserId", stSubStatusObj.UserId);
            para.Add("@IsActive", stSubStatusObj.IsActive);

            return await _stSubStatusRepository.ExecuteScalarAsync<string?>(STSubStatusQueries.UpsertSTSubStatus, para);
        }

        public async Task<IList<STSubStatusEntity>> GetAllSTSubStatusAsync(STSubStatusFilter stSubStatusFilter)
        {
            var para = new DynamicParameters();
            para.Add("@STSubStatusName", stSubStatusFilter.STSubStatusName);
            para.Add("@PageSize", stSubStatusFilter.PageSize);
            para.Add("@PageNumber", stSubStatusFilter.PageNumber);
            var lstSTSubStatus = await _stSubStatusRepository.GetAllAsync<STSubStatusEntity>(STSubStatusQueries.AllSTSubStatus, para);

            return lstSTSubStatus.ToList();
        }

        public async Task<STSubStatusEntity?> GetSTSubStatusByIdAsync(int stSubStatusId)
        {
            var para = new DynamicParameters();
            para.Add("@STSubStatusId", stSubStatusId);
            return await _stSubStatusRepository.GetAsync<STSubStatusEntity>(STSubStatusQueries.GetSTSubStatusById, para);

        }

        public async Task<string?> DeleteSTSubStatusAsync(int stSubStatusId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@STSubStatusId", stSubStatusId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _stSubStatusRepository.ExecuteScalarAsync<string?>(STSubStatusQueries.DeleteSTSubStatus, para);
        }

        public async Task<IList<STSubStatusEntity>> GetSTSubStatusByStatusAsync(int stStatusId)
        {
            var para = new DynamicParameters();
            para.Add("@STStatusId", stStatusId);
            var lstSTSubStatus = await _stSubStatusRepository.GetAllAsync<STSubStatusEntity>(STSubStatusQueries.GetSTSubStatusByStatus, para);

            return lstSTSubStatus.ToList();
        }

        public async Task<IList<STSubStatusByTypeEntity>> GetAllSTSubStatusByTypeAsync(string? StatusType, int? ActiveId)
        {
            var para = new DynamicParameters();
            para.Add("@StatusType", StatusType);
            para.Add("@ActiveId", ActiveId);
            var lstSTSubStatusByType = await _stSubStatusRepository.GetAllAsync<STSubStatusByTypeEntity>(STSubStatusQueries.AllSTSubStatusByType, para);

            return lstSTSubStatusByType.ToList();
        }

        public async Task<IList<ServiceTicketStatusEntity>> GetServiceTicketStatusAsync(int? SubStatusid)
        {
            var para = new DynamicParameters();
            para.Add("@SubStatusid", SubStatusid);
            var lstSTStatus = await _stSubStatusRepository.GetAllAsync<ServiceTicketStatusEntity>(STSubStatusQueries.AllServiceTicketStatus, para);

            return lstSTStatus.ToList();
        }

    }
}
