using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IG.CG.Core.Application.Interfaces.Auth
{
    public interface IJwtAuthManager
    {
        JwtAuthResult GenerateTokens(string username, string emailid, Claim[] claims, DateTime now, string uniqueid);
        JwtAuthResult Refresh(string refreshToken, string emailid, string accessToken, DateTime now);
        void RemoveExpiredRefreshTokens(DateTime now);
        (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);
        void RemoveExpiredRefreshTokens(string? userName);
    }
}
