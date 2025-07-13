using System.Text.Json.Serialization;

namespace IG.CG.Core.Application.Interfaces.Auth
{
    public class JwtTokenConfig
    {
        [JsonPropertyName("secret")]
        public string Secret { get; set; } = string.Empty;

        [JsonPropertyName("issuer")]
        public string? Issuer { get; set; }

        [JsonPropertyName("audience")]
        public string Audience { get; set; } = string.Empty;

        [JsonPropertyName("accessTokenExpiration")]
        public int AccessTokenExpiration { get; set; }

        [JsonPropertyName("refreshTokenExpiration")]
        public int RefreshTokenExpiration { get; set; }
    }
}
