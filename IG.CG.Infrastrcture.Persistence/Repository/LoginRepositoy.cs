using Dapper;
using EmpAuth;
using IG.CG.Core.Application.Interfaces;
using IG.CG.Core.Application.Interfaces.Repository;
using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Constants.Queries;
using IG.CG.Core.Domain.Entities;
using IG.CG.Core.Domain.Utility;
using System.Net;

namespace IG.CG.Infrastrcture.Persistence.Repository
{
    public class LoginRepositoy : ILoginRepository
    {

        private readonly ISqlDbContext _userRepository;
        EncDec _objED = new EncDec();

        ServiceSoapClient objEM = new ServiceSoapClient(ServiceSoapClient.EndpointConfiguration.ServiceSoap);

        public LoginRepositoy(ISqlDbContext userRepository)
        {
            _userRepository = userRepository;
        }
        public async ValueTask<UserInfo?> IsValidCustomerAsync(string mobileNo, string otp)
        {
            var userInfo = new UserInfo();
            var para = new DynamicParameters();
            para.Add("@MobileNo", mobileNo);
            para.Add("@VerificationOTP", otp);
            //userInfo = await _userRepository.GetAsync<int?>(LoginQueries.ProductRegisterValidate, para);

            userInfo = await _userRepository.GetAsync<UserInfo>(LoginQueries.ProductRegisterValidate, para);

            if (userInfo != null)
            {
                userInfo.UserName = mobileNo;
                userInfo.UserId = mobileNo;
                userInfo.IsCustomer = "true";
                await UserLogHistoryAsync(mobileNo, "Product Register");
            }

            return userInfo;
        }
        public async ValueTask<UserInfo?> IsValidUserAsync(LoginEntity userEntity)
        {
            var EncPassword = _objED.Encrypt(userEntity.UserPassword);

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            ServiceSoapClient objEM = new ServiceSoapClient(ServiceSoapClient.EndpointConfiguration.ServiceSoap);


            var paraCGU = new DynamicParameters();
            paraCGU.Add("@UserId", userEntity.UserId);
            var isCheckCGUser = await _userRepository.ExecuteScalarAsync<string?>(LoginQueries.UserIsCheckCGUser, paraCGU);

            UserInfo? userInfo = null;

            if (isCheckCGUser != null && isCheckCGUser.Equals("CG", StringComparison.OrdinalIgnoreCase))
            {
                string sStr = "";
                var paraCGHR4U = new DynamicParameters();
                paraCGHR4U.Add("@UserType", "E");
                paraCGHR4U.Add("@UserPassword", userEntity.UserPassword);
                var PasswordHR4u = await _userRepository.ExecuteScalarAsync<string?>(LoginQueries.UserHR4UValidate, paraCGHR4U);

                sStr = _objED.URLEncode(PasswordHR4u);

                var msg = objEM.EncrGetDataAsync(userEntity.UserId, sStr);

                if (msg is not null && msg.Result is not null && msg.Result.Body is not null)
                {
                    if (msg.Result.Body.EncrGetDataResult.Equals("OK", StringComparison.OrdinalIgnoreCase))
                    {
                        var paraCG = new DynamicParameters();
                        paraCG.Add("@UserId", userEntity.UserId);
                        paraCG.Add("@UserPassword", EncPassword);
                        paraCG.Add("@Mode", "2");
                        userInfo = await _userRepository.GetAsync<UserInfo>(LoginQueries.UserValidate, paraCG);


                    }
                }
            }
            else
            {
                var para = new DynamicParameters();
                para.Add("@UserId", userEntity.UserId);
                para.Add("@UserPassword", EncPassword);
                para.Add("@Mode", "1");
                userInfo = await _userRepository.GetAsync<UserInfo>(LoginQueries.UserValidate, para);

            }

            if (userInfo != null)
            {
                await UserLogHistoryAsync(userEntity?.UserId, "LogIn");
            }

            return userInfo;

        }
        public async ValueTask<int?> UserLogHistoryAsync(string? userId, string type = "")
        {
            var para = new DynamicParameters();
            para.Add("@UserId", userId);
            para.Add("@UserAction", type);
            return await _userRepository.ExecuteScalarAsync<int?>(LoginQueries.UserLogHistory, para);
        }
        //public async ValueTask<List<ChangePasswordModel?>> ChangePasswordAsync(ChangePasswordEntity userEntity)
        //{

        public async ValueTask<string?> ChangePasswordAsync(ChangePasswordEntity userEntity)
        {
            var EncOldPassword = _objED.Encrypt(userEntity.OldPassword);
            var EncPassword = _objED.Encrypt(userEntity.UserPassword);
            var para = new DynamicParameters();
            para.Add("@UserId", userEntity.UserId);
            para.Add("@UserOldPassword", EncOldPassword);
            para.Add("@UserPassword", EncPassword);

            var isCheck = await _userRepository.ExecuteScalarAsync<string?>(LoginQueries.UserChangePassword, para);

            return isCheck;


        }
        public async ValueTask<string?> EncryptText(string textToEncrypt)
        {
            var EncText = _objED.Encrypt(textToEncrypt);
            return EncText;
        }

        public async ValueTask<string?> DecryptText(string textToDycrypt)
        {
            var DecText = _objED.Decrypt(textToDycrypt);
            return DecText;
        }


        public async ValueTask<string?> IsForgotPassword(string UserId, string? IPAddress)
        {

            Random r = new Random();
            string RNo = r.Next(6, 100000).ToString();

            var EncOldPassword = _objED.Encrypt(RNo);

            var para = new DynamicParameters();
            para.Add("@UserId", UserId);
            para.Add("@IPAddress", IPAddress);
            para.Add("@EncryptPassword", EncOldPassword);
            para.Add("@Password", RNo);

            var isCheck = await _userRepository.ExecuteScalarAsync<string?>(LoginQueries.UserForgotPassword, para);

            return isCheck;


        }
    }
}
