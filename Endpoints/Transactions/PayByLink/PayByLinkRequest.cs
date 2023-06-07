using System;
using System.Collections.Generic;
using MerchantHub.Connector.Proxy.Api.Dtos;
using MerchantHub.Connector.Proxy.Api.Models;

namespace MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.PayByLink
{
    public sealed class PayByLinkRequest : BaseRequest
    {
        protected override string Action => "/v1/pay-by-link";

        /// <summary>
        ///     Payment amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        ///     Terminal Id
        /// </summary>
        public Guid TerminalId { get; set; }

        /// <summary>
        ///     ProjectId
        /// </summary>
        public string ProjectId { get; set; }

        /// <summary>
        ///     Language
        /// </summary>
        public string Language { get; set; } = "en";

        /// <summary>
        ///     Description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        ///     Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        ///     Phone
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        ///     Client name
        /// </summary>
        public string? ClientName { get; set; }

        /// <summary>
        ///     Items
        /// </summary>
        public List<ItemDto>? Items { get; set; }

        /// <summary>
        ///     Success Page URL redirect (by default in Merchant Hub)
        /// </summary>
        public string? OkUrl { get; set; }

        /// <summary>
        ///     Fail Page URL (by default in MH)
        /// </summary>
        public string? FailUrl { get; set; }

        /// <summary>
        ///     Pay by link id
        /// </summary>
        public string PayByLinkId { get; set; }

        /// <summary>
        ///     Client ip
        /// </summary>
        public string ClientIp { get; set; }
    }
}
