using System;
using System.Collections.Generic;
using MerchantHub.Connector.Proxy.Api.Dtos;
using MerchantHub.Connector.Proxy.Api.Models;
using MerchantHub.Connector.Proxy.Api.Models.Enums;

namespace MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Recurring.Template
{
    public sealed class ExecuteRecurringRequest : BaseRequest
    {
        protected override string Action => "/v1/execute-recurring";

        /// <summary>
        /// Transaction amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Shipp cost
        /// </summary>
        public decimal? Delivery { get; set; }

        /// <summary>
        /// Transaction currency code MDL – 498 / USD – 840 / EUR – 978 
        /// </summary>

        public Currency Currency { get; set; }

        /// <summary>
        /// Transaction description
        /// </summary>

        public string? Description { get; set; }

        public string? OrderId { get; set; }

        /// <summary>
        /// Biller id in case not specified Transaction Id will be used
        /// as Id of recurring transaction
        /// </summary>

        public Guid BillerId { get; set; }

        /// <summary>
        /// Items
        /// </summary>
        public List<ItemDto>? Items { get; set; }
    }
}
