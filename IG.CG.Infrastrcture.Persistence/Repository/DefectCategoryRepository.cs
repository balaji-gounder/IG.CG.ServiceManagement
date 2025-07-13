using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class DefectCategoryRepository : IDefectCategoryRepository
    {
        private readonly ISqlDbContext _defectCategoryRepository;
        public DefectCategoryRepository(ISqlDbContext defectCategoryRepository)
        {
            _defectCategoryRepository = defectCategoryRepository;
        }

        public async Task<string?> UpsertDefectCategoryAsync(DefectCategoryEntity defectCategoryObj)
        {
            var para = new DynamicParameters();
            para.Add("@DefectCategoryId", defectCategoryObj.DefectCategoryId);
            para.Add("@DefectCategoryName", defectCategoryObj.DefectCategoryName);
            para.Add("@IsActive", defectCategoryObj.IsActive);
            para.Add("@UserId", defectCategoryObj.UserId);
            para.Add("@DivisionCode", defectCategoryObj.DivisionCode);
            para.Add("@ProductLineCode", defectCategoryObj.ProductLineCode);
            para.Add("@ProductGroupCode", defectCategoryObj.ProductGroupCode);
            return await _defectCategoryRepository.ExecuteScalarAsync<string?>(DefectCategoryQueries.UpsertDefectCategory, para);
        }
        public async Task<string?> DeleteDefectCategoryAsync(int defectCategoryId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@DefectCategoryId", defectCategoryId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _defectCategoryRepository.ExecuteScalarAsync<string?>(DefectCategoryQueries.DeleteDefectCategory, para);
        }
        public async Task<IList<DefectCatDispEntity>> GetAllDefectCategoryAsync(DefectCategoryFilter defectCategoryFilter)
        {
            var para = new DynamicParameters();
            para.Add("@DefectCategoryName", defectCategoryFilter.DefectCategoryName);
            para.Add("@ProductGroupCode", defectCategoryFilter.ProductGroupCode);
            para.Add("@ProductLineCode", defectCategoryFilter.ProductLineCode);
            para.Add("@DivisionCode", defectCategoryFilter.DivisionCode);
            para.Add("@PageSize", defectCategoryFilter.PageSize);
            para.Add("@PageNumber", defectCategoryFilter.PageNumber);
            var lstDefectCat = await _defectCategoryRepository.GetAllAsync<DefectCatDispEntity>(DefectCategoryQueries.AllDefectCategory, para);

            return lstDefectCat.ToList();
        }
        public async Task<DefectCategoryEntity?> GetDefectCategoryByIdAsync(int defectCategoryId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@DefectCategoryId", defectCategoryId);
            return await _defectCategoryRepository.GetAsync<DefectCategoryEntity>(DefectCategoryQueries.GetDefectCategoryById, sp_params);
        }


        public async Task<IList<DefectCatDispEntity>> GetAllDefectCategoryByProductAsync(string? DivisionCode, string? ProductLineCode, string? ProductGroupCode)
        {
            var para = new DynamicParameters();

            para.Add("@ProductGroupCode", ProductGroupCode);
            para.Add("@ProductLineCode", ProductLineCode);
            para.Add("@DivisionCode", DivisionCode);
            var lstDefectCat = await _defectCategoryRepository.GetAllAsync<DefectCatDispEntity>(DefectCategoryQueries.AllDefectCategoryByProduct, para);

            return lstDefectCat.ToList();
        }
    }
}
