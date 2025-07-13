
using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class STStatusRepository :  ISTStatusRepository
    {
        private readonly ISqlDbContext _stStatusRepository;
        public STStatusRepository(ISqlDbContext stStatusRepository)
        {
            _stStatusRepository = stStatusRepository;
        }

        public async Task<string?> UpsertSTStatusAsync(STStatusEntity stStatusObj)
        {
            var para = new DynamicParameters();
            para.Add("@STStatusId", stStatusObj.STStatusId);
            para.Add("@STStatusName", stStatusObj.STStatusName);
            para.Add("@UserId", stStatusObj.UserId);
            para.Add("@IsActive", stStatusObj.IsActive);

            return await _stStatusRepository.ExecuteScalarAsync<string?>(STStatusQueries.UpsertSTStatus, para);
        }

        public async Task<IList<STStatusEntity>> GetAllSTStatusAsync(STStatusFilter stStatusFilter)
        {
            var para = new DynamicParameters();
            para.Add("@STStatusName", stStatusFilter.STStatusName);
            para.Add("@PageSize", stStatusFilter.PageSize);
            para.Add("@PageNumber", stStatusFilter.PageNumber);
            var lstSTStatus = await _stStatusRepository.GetAllAsync<STStatusEntity>(STStatusQueries.AllSTStatus, para);

            return lstSTStatus.ToList();
        }
        public async Task<STStatusEntity?> GetSTStatusByIdAsync(int stStatusId)
        {
            var para = new DynamicParameters();
            para.Add("@STStatusId", stStatusId);
            return await _stStatusRepository.GetAsync<STStatusEntity>(STStatusQueries.GetSTStatusById, para);
        
        }

        public async Task<string?> DeleteSTStatusAsync(int stStatusId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@STStatusId", stStatusId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _stStatusRepository.ExecuteScalarAsync<string?>(STStatusQueries.DeleteSTStatus, para);
        }

    }
}
