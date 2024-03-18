using System.Threading;
using System.Threading.Tasks;
using MerchantHub.Connector.Proxy.Api.Models;
using MerchantHub.Connector.Proxy.Api.Models.Requests;
using MerchantHub.Connector.Proxy.Api.Models.Responses;

namespace MerchantHub.Connector.Proxy.Api;

public interface IMerchantHubProxyClient
{
    /// <summary>
    /// Check payment by payment id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<OperationResult<CheckPaymentResponse?>> CheckPaymentAsync(CheckPaymentRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete biller by id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<OperationResult<DeleteBillerResponse?>> DeleteBillerAsync(DeleteBillerRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Complete dms payment
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<OperationResult<CompleteDmsPaymentResponse?>> CompleteDmsPaymentAsync(CompleteDmsPaymentRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Hold dms payment
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<OperationResult<InitPaymentResponse?>> HoldDmsPaymentAsync(HoldDmsPaymentRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Execute one click payment
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<OperationResult<InitPaymentResponse?>> ExecuteOneClickPaymentAsync(ExecuteOneClickPaymentRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Save one click payment
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<OperationResult<InitPaymentResponse?>> SaveOneClickPaymentAsync(SaveOneClickPaymentRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Save request payment
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<OperationResult<InitPaymentResponse?>> SaveRecurringPaymentAsync(SaveRecurringPaymentRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Execute request payment
    /// </summary>
    /// <param name="recurring"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<OperationResult<ExecuteRecurringPaymentResponse?>> ExecuteRecurringPaymentAsync(ExecuteRecurringPaymentRequest recurring, CancellationToken cancellationToken = default);

    /// <summary>
    /// Refund payment
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<OperationResult<RefundPaymentResponse?>> RefundPaymentAsync(RefundPaymentRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Execute sms payment
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<OperationResult<InitPaymentResponse?>> PayAsync(PayRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Generate access token
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<OperationResult<GenerateTokenResponse?>>  GenerateTokenAsync(GenerateTokenRequest request, CancellationToken cancellationToken = default);
}