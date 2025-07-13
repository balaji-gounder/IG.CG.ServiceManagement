
using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class DivisionRepository : IDivisionRepository
    {
        private readonly ISqlDbContext _divisionRepository;
        public DivisionRepository(ISqlDbContext divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }

        public async Task<string?> UpsertDivisionAsync(DivisionEntity divisionObj)
        {
            var para = new DynamicParameters();
            para.Add("@DivisionId", divisionObj.DivisionId);
            para.Add("@DivisionName", divisionObj.DivisionName);
            para.Add("@DivisionCode", divisionObj.DivisionCode);
            para.Add("@DivisionRemarks", divisionObj.DivisionRemarks);
            para.Add("@LongLastingTickitHour", divisionObj.LongLastingTickitHour);
            para.Add("@FrameSizeOrHpReqOrNot", divisionObj.FrameSizeOrHpReqOrNot);
            para.Add("@IsActive", divisionObj.IsActive);
            para.Add("@UserId", divisionObj.UserId);

            return await _divisionRepository.ExecuteScalarAsync<string?>(DivisionQueries.UpsertDivision, para);
        }

        public async Task<string?> DeleteDivisionAsync(int divisionId, string userId, int isActive)
        {
            var para = new DynamicParameters();
            para.Add("@DivisionId", divisionId);
            para.Add("@UserId", userId);
            para.Add("@IsActive", isActive);
            return await _divisionRepository.ExecuteScalarAsync<string?>(DivisionQueries.DeleteDivision, para);
        }

        public async Task<IList<DivisionEntity>> GetAllDivisionAsync(DivisionFilter divisionFilter)
        {
            var para = new DynamicParameters();
            para.Add("@DivisionName", divisionFilter.DivisionName);
            para.Add("@PageSize", divisionFilter.PageSize);
            para.Add("@PageNumber", divisionFilter.PageNumber);
            var lstRegion = await _divisionRepository.GetAllAsync<DivisionEntity>(DivisionQueries.AllDivision, para);
            return lstRegion.ToList();
        }

        public async Task<DivisionEntity?> GetDivisionByIdAsync(int divisionId)
        {
            var sp_params = new DynamicParameters();
            sp_params.Add("@DivisionId", divisionId);
            return await _divisionRepository.GetAsync<DivisionEntity>(DivisionQueries.GetDivisionById, sp_params);
        }

        public async Task<IList<DivisionEntity>> GetAllSAPDivisionAsync(SAPCommonFilter SapFilter)
        {
            var para = new DynamicParameters();
            para.Add("@Id", SapFilter.Id);
            para.Add("@Name", SapFilter.Name);
            para.Add("@Mode", SapFilter.Mode);
            var lstRegion = await _divisionRepository.GetAllAsync<DivisionEntity>(SAPCommonQueries.SAPCommon, para);
            return lstRegion.ToList();
        }

        public async Task<IList<ProductTypeEntity>> GetAllProductTypeAsync()
        {
            var para = new DynamicParameters();
            var lstRegion = await _divisionRepository.GetAllAsync<ProductTypeEntity>(DivisionQueries.AllProductTypeGet, para);
            return lstRegion.ToList();
        }
    }
}
