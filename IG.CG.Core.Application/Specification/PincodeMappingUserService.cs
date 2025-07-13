
using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Specification
{
    public class PincodeMappingUserService : IPincodeMappingUserService
    {
        private readonly IMapper _mapper;
        private readonly IPincodeMappingUserRepository _pincodeMappingUserRepository;
        public PincodeMappingUserService(IMapper mapper, IPincodeMappingUserRepository pincodeMappingUserRepository)
        {
            _mapper = mapper;
            _pincodeMappingUserRepository = pincodeMappingUserRepository;
        }

        public async Task<IList<PincodeMappingUserDisplayModel>> GetAllPincodeMappingUserAsync(BaseFilter baseFilter)
        {
            var pincodeMappingUser = await _pincodeMappingUserRepository.GetAllPincodeMappingUserAsync(baseFilter);
            var pincodeMappingUserModel = _mapper.Map<List<PincodeMappingUserDisplayModel>>(pincodeMappingUser.ToList());
            return pincodeMappingUserModel;
        }
    }
}
