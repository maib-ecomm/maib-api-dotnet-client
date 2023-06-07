using System.Net.Http;
using MerchantHub.Connector.Proxy.Api.Serialization;
using System.Net.Mime;
using System.Text;

namespace MerchantHub.Connector.Proxy.Api.Models
{
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
            return new HttpRequestMessage(HttpMethod, url + Action)
            {
                Content = new StringContent(Serializer.SerializeToString(this), Encoding.UTF8, MediaTypeNames.Application.Json)
            };
        }
    }
}
