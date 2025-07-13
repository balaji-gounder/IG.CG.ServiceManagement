using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Specification
{
    public class UserGetByUserTypeService : IUserGetByUserTypeService
    {
        private readonly IMapper _mapper;
        private readonly IUserGetByUserTypeRepository _userGetByUserTypeRepository;
        public UserGetByUserTypeService(IMapper mapper, IUserGetByUserTypeRepository userGetByUserTypeRepository)
        {
            _mapper = mapper;
            _userGetByUserTypeRepository = userGetByUserTypeRepository;

        }

        public async Task<IList<UserGetByUserTypeModel>> GetAllUserGetByUserTypeAsync(UserGetByUserTypeFilter userTypeFilter)
        {
            var userGetByUserType = await _userGetByUserTypeRepository.GetAllUserGetByUserTypeAsync(userTypeFilter);
            var userGetByUserTypeModel = _mapper.Map<List<UserGetByUserTypeModel>>(userGetByUserType.ToList());
            return userGetByUserTypeModel;
        }


    }
}
