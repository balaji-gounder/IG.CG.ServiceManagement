using AutoMapper;
using IG.CG.Core.Application.Interfaces.Auth;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Interfaces.Services;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;
using System.Collections.Concurrent;
using System.Security.Claims;

namespace IG.CG.Core.Application.Specification
{
    public class LoginService : ILoginService
    {
        private readonly IMapper _mapper;
        private readonly ILoginRepository _userRepository;
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly ConcurrentDictionary<string, RefreshToken> _usersRefreshTokens;  // can store in a database or a distributed cache
        public LoginService(IMapper mapper, ILoginRepository userRepository, IJwtAuthManager jwtAuthManager)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _jwtAuthManager = jwtAuthManager;
            _usersRefreshTokens = new ConcurrentDictionary<string, RefreshToken>();
        }
        public async ValueTask<UserInfo?> ValidateUserAsync(LoginModel userModel)
        {
            var userEntity = _mapper.Map<LoginEntity>(userModel);
            var userInfo = await _userRepository.IsValidUserAsync(userEntity);

            if (userInfo != null)
            {
                var claims = new[]
                {
                             new Claim(ClaimTypes.Name, userInfo.UserId),
                             new Claim(ClaimTypes.Email, userInfo.UserName),
                             new Claim("IsCustomer", "false"),
                    };

                string uniqueid = DateTime.Now.ToString("yyyyMMddHHmmss");

                var jwtResult = _jwtAuthManager.GenerateTokens(userInfo.UserId, userInfo.UserName, claims, DateTime.Now, uniqueid);
                userInfo.Token = jwtResult.AccessToken;
                userInfo.RefreshToken = jwtResult?.RefreshToken;

                return userInfo;
            }
            else
            {
                return null;
            }
        }



        public async ValueTask<string?> IsForgotPassword(string UserId, string? IPAddress)
        {

            var userInfo = await _userRepository.IsForgotPassword(UserId, IPAddress);
            if (userInfo != null)
            {


                return userInfo;
            }
            else
            {
                return null;
            }
        }


        public async ValueTask<UserInfo?> ValidateCustomerAsync(string mobileNo, string otp)
        {
            var userInfo = await _userRepository.IsValidCustomerAsync(mobileNo, otp);

            if (userInfo != null)
            {
                Claim[] claims;


                if (userInfo.IsCustomer.Equals("true", StringComparison.InvariantCulture))
                {
                    claims = new[]
                    {
                             new Claim(ClaimTypes.Name, userInfo.UserId),
                             new Claim(ClaimTypes.Email, userInfo.UserName),
                             new Claim("IsCustomer", "true")

                    };
                }
                else
                {
                    claims = new[]
                   {
                             new Claim(ClaimTypes.Name, userInfo.UserId),
                             new Claim(ClaimTypes.Email, userInfo.UserName)
                   };
                }
                string uniquid = DateTime.Now.ToString("yyyyMMddHHmmss");

                var jwtResult = _jwtAuthManager.GenerateTokens(userInfo.UserId, userInfo.UserName, claims, DateTime.Now, uniquid);
                userInfo.Token = jwtResult.AccessToken;
                userInfo.RefreshToken = jwtResult?.RefreshToken;

                return userInfo;
            }
            else
            {
                return null;
            }
        }
        public void RemoveExpiredRefreshTokens(string? userName)
        {
            _jwtAuthManager.RemoveExpiredRefreshTokens(userName);
        }
        public async ValueTask<int?> UserLogHistoryAsync(string userId, string type)
        {
            return await _userRepository.UserLogHistoryAsync(userId, type);
        }
        public async ValueTask<string?> ChangePasswordAsync(ChangePasswordModel userModel)
        {
            var userEntity = _mapper.Map<ChangePasswordEntity>(userModel);
            var userInfo = await _userRepository.ChangePasswordAsync(userEntity);

            if (userInfo != null)
            {
                return userInfo;
            }
            else
            {
                return null;
            }
        }







        public async ValueTask<string?> EncryptText(string textToEncrypt)
        {
            var EncrText = await _userRepository.EncryptText(textToEncrypt);
            return EncrText;
        }
        public async ValueTask<string?> DecryptText(string textToDecrypt)
        {
            var DecrText = await _userRepository.DecryptText(textToDecrypt);
            return DecrText;
        }
    }
}
