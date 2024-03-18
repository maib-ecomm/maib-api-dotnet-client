using MerchantHub.Connector.Proxy.Api.Exceptions;
using MerchantHub.Connector.Proxy.Api.Models;
using MerchantHub.Connector.Proxy.Api.Models.Requests;
using MerchantHub.Connector.Proxy.Api.Models.Responses;
using System.Net.Http;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using MerchantHub.Connector.Proxy.Api.Options;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using MerchantHub.Connector.Proxy.Api.Serialization;

namespace MerchantHub.Connector.Proxy.Api;

internal sealed class MerchantHubProxyClient : IMerchantHubProxyClient
{
    public const string HttpClientName = "MerchantHubProxyClient";

    private readonly IHttpClientFactory _clientFactory;
    private ConnectorOptions _options;

    public MerchantHubProxyClient(IHttpClientFactory clientFactory, IOptionsMonitor<ConnectorOptions> optionsAccessor)
    {
        _clientFactory = clientFactory;

        _options = optionsAccessor.CurrentValue;
        optionsAccessor.OnChange((options, _) => _options = options);
    }

    public async Task<OperationResult<CheckPaymentResponse?>> CheckPaymentAsync(CheckPaymentRequest request, CancellationToken cancellationToken = default)
    {
        return await SendAsync<OperationResult<CheckPaymentResponse?>, CheckPaymentRequest>(request, cancellationToken);
    }

    public async Task<OperationResult<DeleteBillerResponse?>> DeleteBillerAsync(DeleteBillerRequest request, CancellationToken cancellationToken = default)
    {
        return await SendAsync<OperationResult<DeleteBillerResponse?>, DeleteBillerRequest>(request, cancellationToken);
    }

    public async Task<OperationResult<CompleteDmsPaymentResponse?>> CompleteDmsPaymentAsync(CompleteDmsPaymentRequest request, CancellationToken cancellationToken = default)
    {
        return await SendAsync<OperationResult<CompleteDmsPaymentResponse?>, CompleteDmsPaymentRequest>(request,
            cancellationToken);
    }

    public async Task<OperationResult<InitPaymentResponse?>> HoldDmsPaymentAsync(HoldDmsPaymentRequest request, CancellationToken cancellationToken = default)
    {
        return await SendAsync<OperationResult<InitPaymentResponse?>, HoldDmsPaymentRequest>(request, cancellationToken);
    }

    public async Task<OperationResult<InitPaymentResponse?>> ExecuteOneClickPaymentAsync(ExecuteOneClickPaymentRequest request, CancellationToken cancellationToken = default)
    {
        return await SendAsync<OperationResult<InitPaymentResponse?>, ExecuteOneClickPaymentRequest>(request,
            cancellationToken);
    }

    public async Task<OperationResult<InitPaymentResponse?>> SaveOneClickPaymentAsync(SaveOneClickPaymentRequest request, CancellationToken cancellationToken = default)
    {
        return await SendAsync<OperationResult<InitPaymentResponse?>, SaveOneClickPaymentRequest>(request,
            cancellationToken);
    }

    public async Task<OperationResult<InitPaymentResponse?>> SaveRecurringPaymentAsync(SaveRecurringPaymentRequest request, CancellationToken cancellationToken = default)
    {
        return await SendAsync<OperationResult<InitPaymentResponse?>, SaveRecurringPaymentRequest>(request,
            cancellationToken);
    }

    public async Task<OperationResult<ExecuteRecurringPaymentResponse?>> ExecuteRecurringPaymentAsync(ExecuteRecurringPaymentRequest recurring, CancellationToken cancellationToken = default)
    {
        return await SendAsync<OperationResult<ExecuteRecurringPaymentResponse?>, ExecuteRecurringPaymentRequest>(recurring,
            cancellationToken);
    }

    public async Task<OperationResult<RefundPaymentResponse?>> RefundPaymentAsync(RefundPaymentRequest request, CancellationToken cancellationToken = default)
    {
        return await SendAsync<OperationResult<RefundPaymentResponse?>, RefundPaymentRequest>(request, cancellationToken);
    }

    public async Task<OperationResult<InitPaymentResponse?>> PayAsync(PayRequest request, CancellationToken cancellationToken = default)
    {
        return await SendAsync<OperationResult<InitPaymentResponse?>, PayRequest>(request, cancellationToken);
    }

    public async Task<OperationResult<GenerateTokenResponse?>> GenerateTokenAsync(GenerateTokenRequest request, CancellationToken cancellationToken = default)
    {
        return await SendAsync<OperationResult<GenerateTokenResponse?>, GenerateTokenRequest>(request, cancellationToken);
    }

    private async Task<TResponse> SendAsync<TResponse, TRequest>(TRequest requestData,
        CancellationToken cancellationToken = default)
        where TRequest : BaseRequest
    {
        if (requestData == null)
            throw new ArgumentNullException(nameof(requestData));

        using HttpRequestMessage requestMessage = requestData.ToHttpRequest(_options.Url);

        if (!string.IsNullOrWhiteSpace(requestData.AccessToken))
        {
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", requestData.AccessToken);
        }

        using HttpResponseMessage responseMessage =
            await SendHttpAsync(requestMessage, cancellationToken: cancellationToken);

        var responseJson = await responseMessage.Content.ReadAsStringAsync();
        var httpStatusCode = Convert.ToInt32(responseMessage.StatusCode);

        return ParseResponse<TResponse>(httpStatusCode, responseJson);
    }

    private async Task<HttpResponseMessage> SendHttpAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        using HttpClient client = CreateClient();

        try
        {
            return await client.SendAsync(request, cancellationToken);
        }
        catch (Exception ex)
        {
            throw new NotReachableException(
                $"Could not make request to service at '{_options.Url}'. " +
                $"The provided base url may be incorrect or there may be a firewall blocking the port. Request timeout = {client.Timeout}",
                ex);
        }
    }

    private HttpClient CreateClient()
    {
        HttpClient client = _clientFactory.CreateClient(HttpClientName);
        client.Timeout = TimeSpan.FromMilliseconds(_options.RequestTimeoutMs);

        return client;
    }

    private TResponse ParseResponse<TResponse>(int httpStatusCode, string responseJson)
    {
        if (httpStatusCode is not (200 or 400 or 401 or 403 or 404 or 409 or 500))
            throw new InvalidResponseException(httpStatusCode, responseJson);
        
        if (string.IsNullOrWhiteSpace(responseJson))
        {
            throw new StatusCodeException(httpStatusCode);
        }

        try
        {
            TResponse? result = JsonSerializer.Deserialize<TResponse>(responseJson,
                ConnectorJsonSerializerContext.Default.Options);

            if (result == null)
                throw new InvalidResponseException(httpStatusCode, responseJson);

            return result;
        }
        catch (JsonException ex)
        {
            throw new InvalidResponseException(httpStatusCode, responseJson, ex);
        }
    }
}