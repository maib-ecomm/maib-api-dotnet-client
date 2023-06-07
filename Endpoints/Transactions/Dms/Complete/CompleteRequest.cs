using System;
using MerchantHub.Connector.Proxy.Api.Models;

namespace MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Dms.Complete
{
    public sealed class CompleteRequest : BaseRequest
    {
        protected override string Action => "/v1/complete";

        /// <summary>
        ///     Pay id
        /// </summary>
        public Guid PayId { get; set; }

        /// <summary>
        ///     Confirm amount
        /// </summary>
        public decimal? ConfirmAmount { get; set; }

        /// <summary>
        /// Client ip
        /// </summary>
        public string ClientIp { get; set; }
    }
}
