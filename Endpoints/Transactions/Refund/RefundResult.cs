using System;

namespace MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Refund
{
    public sealed class RefundResult
    {
        /// <summary>
        ///     Pay id
        /// </summary>
        public Guid PayId { get; set; }

        /// <summary>
        ///     Order id
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        ///     Transaction refund amount
        /// </summary>
        public decimal? RefundAmount { get; set; }

        /// <summary>
        ///     Transaction status code
        /// </summary>
        public string? StatusCode { get; set; }

        /// <summary>
        ///     Payment status
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        ///     Payment status message
        /// </summary>
        public string? StatusMessage { get; set; }
    }
}
