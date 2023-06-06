using System;
using System.Net.Http;
using MerchantHub.Connector.Proxy.Api.Http.Interfaces;
using MerchantHub.Connector.Proxy.Api.Http.Settings;
using MerchantHub.Connector.Proxy.Api.Models;
using MerchantHub.Connector.Proxy.Api.Serialization;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using MerchantHub.Connector.Proxy.Api.Exceptions;
using MerchantHub.Connector.Proxy.Api.Options;

namespace MerchantHub.Connector.Proxy.Api.Http
{
    /// <summary>
    /// Represents the base client. Implements the <see cref="IEndpointClient" />.
    /// </summary>
    public abstract class BaseClient : IEndpointClient
    {
        private readonly IHttpClientFactory _clientFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseClient" /> class.
        /// </summary>
        /// <param name="clientFactory">The client factory.</param>
        /// <param name="options">The options.</param>
        protected BaseClient(IHttpClientFactory clientFactory, ConnectorOptions options)
        {
            Options = options;
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        protected ConnectorOptions Options { get; set; }

        public abstract HttpRequestMessage BuildRequest(RequestSettings requestSettings);

        public abstract Task<TResponse> SendAsync<TResponse, TRequest>(
            TRequest requestData,
            CancellationToken cancellationToken = default) where TRequest : BaseRequest;

        public async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request, string? accessToken = default, CancellationToken cancellationToken = default)
        {
            var client = _clientFactory.CreateClient();
            client.Timeout = TimeSpan.FromMilliseconds(Options.RequestTimeoutMs);
            if (accessToken != null)
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            try
            {
                return await client.SendAsync(request, cancellationToken);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exceptions.TimeoutException(
                    $"Request to service URL '{Options.Url}' timed out (timeout = {client.Timeout.TotalMilliseconds:N0} ms).", ex);
            }
            catch (Exception ex)
            {
                throw new Exceptions.TimeoutException(
                    $"Could not make request to service at '{Options.Url}'. " +
                    "The endpoint may be incorrect or there may be a firewall blocking the port.", ex);
            }
        }

        /// <summary>
        /// Creates the invalid response exception.
        /// </summary>
        /// <param name="responseJson">The response json.</param>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <returns>Exception.</returns>
        /// <exception cref="ApplicationException">An empty response was received. StatusCode is " + httpStatusCode</exception>
        /// <exception cref="InvalidResponseException"></exception>
        protected static Exception CreateInvalidResponseException(string responseJson, int httpStatusCode)
        {
            try
            {
                if (string.IsNullOrEmpty(responseJson))
                    throw new ApplicationException("An empty response was received. StatusCode is " + httpStatusCode);

                var errorResponse = Serializer.DeserializeString<ErrorResultModel>(responseJson);

                var exception = new StatusCodeException("Response status code does not indicate success: " + httpStatusCode)
                {
                    HttpStatusCode = httpStatusCode
                };

                if (errorResponse != null)
                {
                    exception.ErrorCode = errorResponse.ErrorCode;
                    exception.ErrorMessage = errorResponse.ErrorMessage;
                }

                return exception;
            }
            catch (Exception ex)
            {
                throw new InvalidResponseException(responseJson, ex)
                {
                    HttpStatusCode = httpStatusCode
                };
            }
        }
    }
}
