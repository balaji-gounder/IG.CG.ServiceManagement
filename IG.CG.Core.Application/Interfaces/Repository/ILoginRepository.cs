using IG.CG.Core.Application.Models;
using IG.CG.Core.Domain.Entities;

namespace IG.CG.Core.Application.Interfaces.Repository
{
    public interface ILoginRepository
    {
        ValueTask<UserInfo?> IsValidUserAsync(LoginEntity userEntity);
        ValueTask<UserInfo?> IsValidCustomerAsync(string mobileNo, string otp);
        ValueTask<int?> UserLogHistoryAsync(string userId, string type);

        ValueTask<string?> ChangePasswordAsync(ChangePasswordEntity userEntity);
        ValueTask<string?> EncryptText(string textToEncrypt);
        ValueTask<string?> DecryptText(string textToDecrypt);

        ValueTask<string?> IsForgotPassword(string UserId, string? IPAddress);
    }
}
