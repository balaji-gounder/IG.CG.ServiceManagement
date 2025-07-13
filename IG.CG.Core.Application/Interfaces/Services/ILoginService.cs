using IG.CG.Core.Application.Models;

namespace IG.CG.Core.Application.Interfaces.Services
{
    public interface ILoginService
    {
        ValueTask<UserInfo?> ValidateUserAsync(LoginModel userModel);
        ValueTask<UserInfo?> ValidateCustomerAsync(string mobileNo, string otp);
        void RemoveExpiredRefreshTokens(string? userName);
        ValueTask<int?> UserLogHistoryAsync(string userId, string type);
        ValueTask<string?> ChangePasswordAsync(ChangePasswordModel userModel);

        ValueTask<string?> EncryptText(string textToEncrypt);
        ValueTask<string?> DecryptText(string textToDecrypt);
        ValueTask<string?> IsForgotPassword(string UserId, string? IPAddress);
    }
}
