using System.Text.Json.Serialization;

namespace MerchantHub.Connector.Proxy.Api.Models.Responses;

public sealed class GenerateTokenResponse
{
    /// <summary>
    /// Access Token
    /// </summary>
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; }

    /// <summary>
    /// Access Token lifetime in seconds
    /// </summary>

    [JsonPropertyName("expiresIn")]
    public int ExpiresIn { get; set; }

    /// <summary>
    /// Refresh Token for generating a new Access Token
    /// </summary>
    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; set; }

    /// <summary>
    /// Refresh Token lifetime in seconds
    /// </summary>
    [JsonPropertyName("refreshExpiresIn")]
    public int RefreshExpiresIn { get; set; }

    /// <summary>
    /// Token type (Bearer)
    /// </summary>
    [JsonPropertyName("tokenType")]
    public string TokenType { get; set; }
}