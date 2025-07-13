using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;


namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class DefectRepository : IDefectRepository
    {
        private readonly ISqlDbContext _defectRepository;
        public DefectRepository(ISqlDbContext defectRepository)
        {
            _defectRepository = defectRepository;
        }
        public async Task<string?> UpsertDefectAsync(DefectEntity defectObj)
        {
            var para = new DynamicParameters();
            para.Add("@DefectId", defectObj.DefectId);
            para.Add("@DivisionCode", defectObj.DivisionCode);
            para.Add("@ProductLineCode", defectObj.ProductLineCode);
            para.Add("@ProductGroupCode", defectObj.ProductGroupCode);
            para.Add("@ProductCode", defectObj.ProductCode);
            para.Add("@DefectCategoryId", defectObj.DefectCategoryId);
            para.Add("@DefectDesc", defectObj.DefectDesc);
            para.Add("@IsActive", defectObj.IsActive);
            para.Add("@UserId", defectObj.UserId);
            return await _defectRepository.ExecuteScalarAsync<string?>(DefectQueries.UpsertDefect, para);
        }

        public async Task<string?> DeleteDefectAsync(int defectId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@DefectId", defectId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _defectRepository.ExecuteScalarAsync<string?>(DefectQueries.DeleteDefect, para);
        }

        public async Task<IList<DefectDisplayEntity>> GetAllDefectAsync(DefectFilter DefectFilter)
        {
            var para = new DynamicParameters();
            para.Add("@DefectCategoryId", DefectFilter.DefectCategoryId);
            para.Add("@ProductGroupCode", DefectFilter.ProductGroupCode);
            para.Add("@ProductLineCode", DefectFilter.ProductLineCode);
            para.Add("@DivisionCode", DefectFilter.DivisionCode);
            para.Add("@PageSize", DefectFilter.PageSize);
            para.Add("@PageNumber", DefectFilter.PageNumber);
            var lstRegion = await _defectRepository.GetAllAsync<DefectDisplayEntity>(DefectQueries.AllDefect, para);
            return lstRegion.ToList();
        }
        public async Task<DefectEntity?> GetDefectByIdAsync(int defectId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@DefectId", defectId);
            return await _defectRepository.GetAsync<DefectEntity>(DefectQueries.GetDefectById, sp_params);
        }

        public async Task<IList<DefectDisplayEntity>> GetAllDefectByProductLineAsync(string? ProductLineCode)
        {
            var para = new DynamicParameters();

            para.Add("@ProductLineCode", ProductLineCode);

            var lstRegion = await _defectRepository.GetAllAsync<DefectDisplayEntity>(DefectQueries.AllDefectByProductLint, para);
            return lstRegion.ToList();
        }
    }
}
