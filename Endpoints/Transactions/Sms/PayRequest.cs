using System.Collections.Generic;
using MerchantHub.Connector.Proxy.Api.Dtos;
using MerchantHub.Connector.Proxy.Api.Models.Enums;
using MerchantHub.Connector.Proxy.Api.Models;

namespace MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Sms
{
    public class PayRequest : BaseRequest
    {
        protected override string Action => "/v1/pay";

        /// <summary>
        ///     Transaction amount 
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        ///     Currency code in ISO 4217. MDL-498, USD-840, EUR-978
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        ///     Transaction Description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        ///     Language
        /// </summary>
        public string Language { get; set; } = "en";

        /// <summary>
        ///     Order Id
        /// </summary>
        public string? OrderId { get; set; }

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
        ///     Delivery cost
        /// </summary>
        public decimal? Delivery { get; set; }

        /// <summary>
        ///     Items
        /// </summary>
        public List<ItemDto>? Items { get; set; }

        /// <summary>
        ///     Success Page URL redirect (by default in Merchant Hub)
        /// </summary>
        public string? OkUrl { get; set; }

        /// <summary>
        ///     Server URL where confirmation data will be sent
        /// </summary>
        public string? CallBackUrl { get; set; }

        /// <summary>
        ///     Fail Page URL (by default in MH)
        /// </summary>
        public string? FailUrl { get; set; }

        /// <summary>
        ///     Client ip
        /// </summary>
        public string ClientIp { get; set; }
    }
}
