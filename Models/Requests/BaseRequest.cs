using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ConnectorJsonSerializerContext = MerchantHub.Connector.Proxy.Api.Serialization.ConnectorJsonSerializerContext;

namespace MerchantHub.Connector.Proxy.Api.Models.Requests;

/// <summary>
/// Represents the base request.
/// </summary>
public abstract class BaseRequest
{
    /// <summary>
    /// Gets the action.
    /// </summary>
    protected abstract string Action { get; }

    /// <summary>
    /// Access token
    /// </summary>
    [JsonIgnore]
    public string? AccessToken { get; set; }

    /// <summary>
    /// Gets or sets the HTTP method.
    /// </summary>
    protected virtual HttpMethod HttpMethod { get; } = HttpMethod.Post;

    /// <summary>
    /// Converts to <see cref="HttpRequestMessage" />.
    /// </summary>
    /// <param name="url">The URL.</param>
    internal virtual HttpRequestMessage ToHttpRequest(string url)
    {
        string content = JsonSerializer.Serialize(this, ConnectorJsonSerializerContext.Default.GetTypeInfo(GetType())!);

        var result = new HttpRequestMessage(HttpMethod, url + Action)
        {
            Content = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json)
        };

        return result;
    }
}