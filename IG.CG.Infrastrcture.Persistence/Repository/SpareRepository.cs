
using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models.Filters;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class SpareRepository : ISpareRepository
    {
        private readonly ISqlDbContext _spareRepository;
        public SpareRepository(ISqlDbContext spareRepository)
        {
            _spareRepository = spareRepository;
        }


        public async Task<string?> UpsertSpareAsync(SpareEntity spareObj)
        {
            
            var para = new DynamicParameters();
            para.Add("@Spareid", spareObj.Spareid);
            para.Add("@SpareCode", spareObj.SpareCode);
            para.Add("@DivisionCode", spareObj.DivisionCode);
            para.Add("@ProductLineCode", spareObj.ProductLineCode);
            para.Add("@ProductCode", spareObj.ProductCode);
            para.Add("@ProductGroup", spareObj.ProductGroupCode);
            para.Add("@SpareDescription", spareObj.SpareDescription);
            para.Add("@SparePrice", spareObj.SparePrice);
            para.Add("@UserId", spareObj.UserId);
            para.Add("@IsActive", spareObj.IsActive);
            return await _spareRepository.ExecuteScalarAsync<string?>(SpareQueries.UpsertSpare, para);
        }

        public async Task<SpareEntity?> GetSpareByIdAsync(int SpareId)
        {
            var para = new DynamicParameters();
            para.Add("@Spareid", SpareId);
            return await _spareRepository.GetAsync<SpareEntity>(SpareQueries.GetSpareById, para);

        }

        public async Task<IList<SpareDisplayEntity>> GetAllSpareAsync(SpareFilter spareFilter)
        {
            var para = new DynamicParameters();
            para.Add("@DivisionCode", spareFilter.DivisionCode);
            para.Add("@ProductLineCode", spareFilter.ProductLineCode);
            para.Add("@ProductCode", spareFilter.ProductCode);
            para.Add("@ProductGroupCode", spareFilter.ProductGroupCode);
            para.Add("@PageSize", spareFilter.PageSize);
            para.Add("@PageNumber", spareFilter.PageNumber);
            var lstSpare = await _spareRepository.GetAllAsync<SpareDisplayEntity>(SpareQueries.AllSpare, para);

            return lstSpare.ToList();
        }

        public async Task<string?> DeleteSpareAsync(int SpareId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@Spareid", SpareId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _spareRepository.ExecuteScalarAsync<string?>(SpareQueries.DeleteSpare, para);
        }

    }
}
