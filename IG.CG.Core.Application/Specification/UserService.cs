using AutoMapper;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Specification
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;

        }

        public async Task<IList<UserDisplayModel>> GetAllUserAsync(UserFilter userFilter)
        {
            var user = await _userRepository.GetAllUserAsync(userFilter);
            var userModel = _mapper.Map<List<UserDisplayModel>>(user.ToList());
            return userModel;
        }

        public async Task<UserDisplayModel> GetUserByIdAsync(string userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            var userModel = _mapper.Map<UserDisplayModel>(user);
            return userModel;
        }


        public async Task<string?> UpsertUserAsync(UserModel userModel, string? userId)
        {
            UserEntity userObj = _mapper.Map<UserEntity>(userModel);
            userObj.CreatedBy = userId;
            return await _userRepository.UpsertUserAsync(userObj);
        }
        public async Task<string?> DeleteUserAsync(int userAutoId, string? userId, int isActive)
        {
            return await _userRepository.DeleteUserAsync(userAutoId, userId, isActive);
        }

        public async Task<IList<MasterModel>> GetAllUserWishMstByUserIdAsync(MasterFilter userFilter)
        {
            var userWishMst = await _userRepository.GetAllUserWishMstByUserIdAsync(userFilter);
            var userWishMstModel = _mapper.Map<List<MasterModel>>(userWishMst.ToList());
            return userWishMstModel;
        }
    }
}
