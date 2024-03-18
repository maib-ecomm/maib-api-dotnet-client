using System.Text.Json.Serialization;

namespace Maib.Ecomm.Api.Connector.Models.Requests;

public sealed class GenerateTokenRequest : BaseRequest
{
    protected override string Action => "/v1/generate-token";

    /// <summary>
    /// Project ID from Project in maibmerchants
    /// </summary>
    [JsonPropertyName("projectId")]
    public string ProjectId { get; set; }

    /// <summary>
    /// Project Secret from Project in maibmerchants
    /// </summary>
    [JsonPropertyName("projectSecret")]
    public string? ProjectSecret { get; set; }

    /// <summary>
    /// Refresh token
    /// </summary>
    [JsonPropertyName("refreshToken")]
    public string? RefreshToken { get; set; }
}