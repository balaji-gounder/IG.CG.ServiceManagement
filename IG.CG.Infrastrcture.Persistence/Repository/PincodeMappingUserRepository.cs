using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class PincodeMappingUserRepository : IPincodeMappingUserRepository
    {
        private readonly ISqlDbContext _pincodeMappingUserRepository;
        public PincodeMappingUserRepository(ISqlDbContext pincodeMappingUserRepository)
        {
            _pincodeMappingUserRepository = pincodeMappingUserRepository;
        }

        public async Task<int?> AddPincodeMappingUser(string jsonData)
        {
            var para = new DynamicParameters();
            para.Add("@json", jsonData);
            var result = await _pincodeMappingUserRepository.ExecuteScalarAsync<int?>(PincodeMappingUserQueries.PincodeMappingUserInsertJson, para);
            return result;
        }

        public async Task<IList<PincodeMappingUserDisplayEntity>> GetAllPincodeMappingUserAsync(BaseFilter baseFilter)
        {
            var para = new DynamicParameters();

            para.Add("@PageSize", baseFilter.PageSize);
            para.Add("@PageNumber", baseFilter.PageNumber);
            var PincodeMappingUser = await _pincodeMappingUserRepository.GetAllAsync<PincodeMappingUserDisplayEntity>(PincodeMappingUserQueries.GetAllPincodeMappingUser, para);

            return PincodeMappingUser.ToList();
        }
    }
}
