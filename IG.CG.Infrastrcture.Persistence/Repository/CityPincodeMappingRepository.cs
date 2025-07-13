using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class CityPincodeMappingRepository : ICityPincodeMappingRepository
    {
        private readonly ISqlDbContext _CityPincodeRepository;
        public CityPincodeMappingRepository(ISqlDbContext CityPincodeRepository)
        {
            _CityPincodeRepository = CityPincodeRepository;
        }

        public async Task<IList<CityPincodeMappingEntity>> GetAllCityPincodeMapping(string? CityId, string DivisionCode, string Mode)
        {
            var para = new DynamicParameters();
            para.Add("@Cityid", CityId);
            para.Add("@DivisionCode", DivisionCode);
            para.Add("@Mode", Mode);
            var lstAsc = await _CityPincodeRepository.GetAllAsync<CityPincodeMappingEntity>(CityPincodeMappingQueries.AllPinCodeGet, para);
            return lstAsc.ToList();
        }

        public async Task<IList<CityPincodeMappingEntity>> GetAllPincodeMappingAsc(string? Pincode)
        {
            var para = new DynamicParameters();
            para.Add("@Pincode", Pincode);
            var lstAsc = await _CityPincodeRepository.GetAllAsync<CityPincodeMappingEntity>(CityPincodeMappingQueries.AlPinCodeUserGetAscGet, para);
            return lstAsc.ToList();
        }

        public async Task<IList<CityPincodeMappingEntity>> GetAllPincodeMappingUser(string? Pincode, string? ProductLineCode)
        {
            var para = new DynamicParameters();
            para.Add("@Pincode", Pincode);
            para.Add("@ProductLineCode", ProductLineCode);
            var lstAsc = await _CityPincodeRepository.GetAllAsync<CityPincodeMappingEntity>(CityPincodeMappingQueries.AlPinCodeUserGetUserGet, para);
            return lstAsc.ToList();
        }

    }
}
