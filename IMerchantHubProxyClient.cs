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
using MerchantHub.Connector.Proxy.Api.Models;

namespace MerchantHub.Connector.Proxy.Api
{
    public interface IMerchantHubProxyClient
    {
        /// <summary>
        ///     Check payment by payment id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<OperationResult<CheckResult?>> CheckPaymentAsync(CheckRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Delete biller by id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<OperationResult<DeleteResult?>> DeleteBillerAsync(DeleteRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Complete dms payment
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<OperationResult<CompleteResult?>> CompleteDmsPaymentAsync(CompleteRequest request,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Hold dms payment
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<OperationResult<BaseResult?>> HoldDmsPaymentAsync(HoldRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Execute one click payment
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<OperationResult<BaseResult?>> ExecuteOneClickPaymentAsync(ExecuteOneClickRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Save one click payment
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<OperationResult<BaseResult?>> SaveOneClickPaymentAsync(SaveOneClickRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Pay by link
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<OperationResult<BaseResult?>> PayByLinkAsync(PayByLinkRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Save request payment
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<OperationResult<BaseResult?>> SaveRecurringPaymentAsync(SaveRecurringRequest request,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Execute request payment
        /// </summary>
        /// <param name="recurring"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<OperationResult<ExecuteRecurringResult?>> ExecuteRecurringPaymentAsync(ExecuteRecurringRequest recurring, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Refund payment
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<OperationResult<RefundResult?>> RefundPaymentAsync(RefundRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Execute sms payment
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<OperationResult<BaseResult?>> PayAsync(PayRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Generate access token
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<OperationResult<GenerateTokenResult?>>  GenerateTokenAsync(GenerateTokenRequest request, CancellationToken cancellationToken = default);
    }
}
