using System;
using MerchantHub.Connector.Proxy.Api.Models;

namespace MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Refund
{
    public sealed class RefundRequest : BaseRequest
    {
        protected override string Action => "/v1/refund";

        /// <summary>
        /// PayId
        /// </summary>
        public Guid PayId { get; set; }

        /// <summary>
        /// RefundAmount to revers if not specified revers all sum
        /// </summary>
        public decimal? RefundAmount { get; set; }
    }
}
