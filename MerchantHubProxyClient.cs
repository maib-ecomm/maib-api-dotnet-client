using System.Threading;
using System.Threading.Tasks;
using MerchantHub.Connector.Proxy.Api.Endpoints.Auth.Token;
using MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Check;
using MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Delete;
using MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Dms.Complete;
using MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Dms.Hold;
using MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.OneClick.Execute;
using MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.OneClick.Save;
using MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.PayByLink;
using MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Recurring.SaveRecurring;
using MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Recurring.Template;
using MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Refund;
using MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Sms;
using MerchantHub.Connector.Proxy.Api.Http.Interfaces;
using MerchantHub.Connector.Proxy.Api.Models;

namespace MerchantHub.Connector.Proxy.Api
{
    public sealed class MerchantHubProxyClient : IMerchantHubProxyClient
    {
        private readonly IEndpointClient _client;

        public MerchantHubProxyClient(IEndpointClient client)
        {
            _client = client;
        }

        public async Task<OperationResult<CheckResult?>> CheckPaymentAsync(CheckRequest request, CancellationToken cancellationToken = default)
        {
            return await _client.SendAsync<OperationResult<CheckResult?>, CheckRequest>(request, cancellationToken);
        }

        public async Task<OperationResult<DeleteResult?>> DeleteBillerAsync(DeleteRequest request, CancellationToken cancellationToken = default)
        {
            return await _client.SendAsync<OperationResult<DeleteResult?>, DeleteRequest>(request, cancellationToken);
        }

        public async Task<OperationResult<CompleteResult?>> CompleteDmsPaymentAsync(CompleteRequest request, CancellationToken cancellationToken = default)
        {
            return await _client.SendAsync<OperationResult<CompleteResult?>, CompleteRequest>(request,
                cancellationToken);
        }

        public async Task<OperationResult<BaseResult?>> HoldDmsPaymentAsync(HoldRequest request, CancellationToken cancellationToken = default)
        {
            return await _client.SendAsync<OperationResult<BaseResult?>, HoldRequest>(request, cancellationToken);
        }

        public async Task<OperationResult<BaseResult?>> ExecuteOneClickPaymentAsync(ExecuteOneClickRequest request, CancellationToken cancellationToken = default)
        {
            return await _client.SendAsync<OperationResult<BaseResult?>, ExecuteOneClickRequest>(request,
                cancellationToken);
        }

        public async Task<OperationResult<BaseResult?>> SaveOneClickPaymentAsync(SaveOneClickRequest request, CancellationToken cancellationToken = default)
        {
            return await _client.SendAsync<OperationResult<BaseResult?>, SaveOneClickRequest>(request,
                cancellationToken);
        }

        public async Task<OperationResult<BaseResult?>> PayByLinkAsync(PayByLinkRequest request, CancellationToken cancellationToken = default)
        {
            return await _client.SendAsync<OperationResult<BaseResult?>, PayByLinkRequest>(request, cancellationToken);
        }

        public async Task<OperationResult<BaseResult?>> SaveRecurringPaymentAsync(SaveRecurringRequest request, CancellationToken cancellationToken = default)
        {
            return await _client.SendAsync<OperationResult<BaseResult?>, SaveRecurringRequest>(request,
                cancellationToken);
        }

        public async Task<OperationResult<ExecuteRecurringResult?>> ExecuteRecurringPaymentAsync(ExecuteRecurringRequest recurring, CancellationToken cancellationToken = default)
        {
            return await _client.SendAsync<OperationResult<ExecuteRecurringResult?>, ExecuteRecurringRequest>(recurring,
                cancellationToken);
        }

        public async Task<OperationResult<RefundResult?>> RefundPaymentAsync(RefundRequest request, CancellationToken cancellationToken = default)
        {
            return await _client.SendAsync<OperationResult<RefundResult?>, RefundRequest>(request, cancellationToken);
        }

        public async Task<OperationResult<BaseResult?>> PayAsync(PayRequest request, CancellationToken cancellationToken = default)
        {
            return await _client.SendAsync<OperationResult<BaseResult?>, PayRequest>(request, cancellationToken);
        }

        public async Task<OperationResult<GenerateTokenResult?>> GenerateTokenAsync(GenerateTokenRequest request, CancellationToken cancellationToken = default)
        {
            return await _client.SendAsync<OperationResult<GenerateTokenResult?>, GenerateTokenRequest>(request, cancellationToken);
        }
    }
}
