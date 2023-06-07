using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MerchantHub.Connector.Proxy.Api.Models;
using MerchantHub.Connector.Proxy.Api.Http.Settings;

namespace MerchantHub.Connector.Proxy.Api.Http.Interfaces
{
    /// <summary>
    /// Defines a endpoint client.
    /// </summary>
    public interface IEndpointClient
    {
        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="requestSettings">The request settings.</param>
        public HttpRequestMessage BuildRequest(RequestSettings requestSettings);

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="AccessToken"></param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request, string? AccessToken = default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Calls the service and returns a deserialized response object.
        /// </summary>
        /// <typeparam name="TResponse">The expected response type.</typeparam>
        /// <typeparam name="TRequest">The expected request type.</typeparam>
        /// <param name="requestData">The query data to send to the service. Must not be null.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<TResponse> SendAsync<TResponse, TRequest>(TRequest requestData, CancellationToken cancellationToken = default) where TRequest : BaseRequest;
    }
}
