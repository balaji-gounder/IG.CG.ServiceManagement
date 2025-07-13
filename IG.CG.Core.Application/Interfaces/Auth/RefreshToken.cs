using System.Text.Json.Serialization;

namespace IG.CG.Core.Application.Interfaces.Auth
{
    public class RefreshToken
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; } = string.Empty;    // can be used for usage tracking
        [JsonPropertyName("useruniqueid")]                        // can optionally include other metadata, such as user agent, ip address, device name, and so on
        public string UserUniqueID { get; set; } = string.Empty;//It's used for allow signle user connect with differnt system

        [JsonPropertyName("tokenString")]
        public string TokenString { get; set; } = string.Empty;

        [JsonPropertyName("emailid")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("expireAt")]
        public DateTime ExpireAt { get; set; }
    }
}
