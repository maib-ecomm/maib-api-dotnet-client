using System;
using System.Net.Http;

namespace MerchantHub.Connector.Proxy.Api.Http.Settings
{
    /// <summary>
    /// Represents the request settings.
    /// </summary>
    public class RequestSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestSettings" /> class.
        /// </summary>
        public RequestSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestSettings" /> class.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="content">The content.</param>
        /// <param name="method">The method.</param>
        public RequestSettings(string uri, object content, HttpMethod method)
        {
            Uri = new Uri(uri);
            Content = content;
            Method = method;
        }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        public HttpMethod Method { get; set; }

        /// <summary>
        /// Gets or sets the URI.
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public object Content { get; set; }
    }
}
