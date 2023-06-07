using System;
using System.Collections.Generic;
using MerchantHub.Connector.Proxy.Api.Dtos;
using MerchantHub.Connector.Proxy.Api.Models;
using MerchantHub.Connector.Proxy.Api.Models.Enums;

namespace MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.OneClick.Execute
{
    public sealed class ExecuteOneClickRequest : BaseRequest
    {
        protected override string Action => "/v1/execute-oneclick";

        /// <summary>
        ///         Transaction amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        ///     Delivery cost
        /// </summary>
        public decimal? Delivery { get; set; }

        /// <summary>
        ///     Transaction currency code MDL – 498 / USD – 840 / EUR – 978 
        /// </summary>

        public Currency Currency { get; set; }

        /// <summary>
        ///     Transaction description
        /// </summary>

        public string? Description { get; set; }

        /// <summary>
        ///     Pay order id
        /// </summary>
        public string? OrderId { get; set; }

        /// <summary>
        ///     Transaction language en, ro, ru
        /// </summary>

        public string Language { get; set; } = "en";

        /// <summary>
        ///     Biller id in case not specified Transaction Id will be used
        /// as Id of recurring transaction
        /// </summary>

        public Guid BillerId { get; set; }

        /// <summary>
        /// Items
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
    }
}
