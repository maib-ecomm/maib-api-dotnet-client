using System;
using System.Net.Http;
using MerchantHub.Connector.Proxy.Api.Http.Settings;
using MerchantHub.Connector.Proxy.Api.Options;
using MerchantHub.Connector.Proxy.Api.Serialization;
using Microsoft.Extensions.Options;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MerchantHub.Connector.Proxy.Api.Http
{

    /// <summary>
    /// Represents a http rest client.
    /// Implements the <see cref="BaseClient" />
    /// </summary>
    public sealed class RestClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RestClient" /> class.
        /// </summary>
        /// <param name="clientFactory">The client factory.</param>
        /// <param name="optionsAccessor">The options accessor.</param>
        public RestClient(IHttpClientFactory clientFactory, IOptionsMonitor<ConnectorOptions> optionsAccessor) : base(
            clientFactory, optionsAccessor.CurrentValue)
        {
            optionsAccessor.OnChange((options, name) => Options = options);
        }

        public override HttpRequestMessage BuildRequest(RequestSettings requestSettings)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
            {
                RequestUri = requestSettings.Uri,
                Method = requestSettings.Method,
                Content = new StringContent(Serializer.SerializeToString(requestSettings.Content), Encoding.UTF8,
                    MediaTypeNames.Application.Json)
            };

            return httpRequestMessage;
        }

        public override async Task<TResponse> SendAsync<TResponse, TRequest>(TRequest requestData,
            CancellationToken cancellationToken = default)
        {
            _ = requestData ?? throw new ArgumentNullException(nameof(requestData));
            var requestMessage = requestData.ToHttpRequest(Options.Url);

            var message = await SendRequestAsync(requestMessage, requestData.AccessToken, cancellationToken: cancellationToken);

            var responseJson = await message.Content.ReadAsStringAsync();
            var httpStatusCode = (int)message.StatusCode;

            message.Dispose();

            if (httpStatusCode >= 200 && httpStatusCode <= 299)
                return Serializer.DeserializeString<TResponse>(responseJson);



            throw CreateInvalidResponseException(responseJson, httpStatusCode);
        }
    }
}
