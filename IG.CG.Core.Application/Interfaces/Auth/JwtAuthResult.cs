using System.Text.Json.Serialization;

namespace IG.CG.Core.Application.Interfaces.Auth
{
    public class JwtAuthResult
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; } = string.Empty;

        [JsonPropertyName("refreshToken")]
        public RefreshToken? RefreshToken { get; set; }
    }
}
