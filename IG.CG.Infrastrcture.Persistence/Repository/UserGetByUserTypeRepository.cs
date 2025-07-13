using Dapper;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class UserGetByUserTypeRepository : IUserGetByUserTypeRepository
    {
        private readonly ISqlDbContext _userGetByUserTypeRepository;
        public UserGetByUserTypeRepository(ISqlDbContext userGetByUserTypeRepository)
        {
            _userGetByUserTypeRepository = userGetByUserTypeRepository;
        }

        public async Task<IList<UserGetByUserTypeEntity>> GetAllUserGetByUserTypeAsync(UserGetByUserTypeFilter userTypeFilter)
        {
            var para = new DynamicParameters();
            para.Add("@UserName", userTypeFilter.UserName);
            para.Add("@UserTypeId", userTypeFilter.UserTypeId);

            var lstRegion = await _userGetByUserTypeRepository.GetAllAsync<UserGetByUserTypeEntity>(UserQueries.GetUserTypeByUser, para);
            return lstRegion.ToList();
        }

    }
}
