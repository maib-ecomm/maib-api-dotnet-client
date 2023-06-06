using System;

namespace MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Dms.Complete
{
    public sealed class CompleteResult
    {
        /// <summary>
        ///     Payment id
        /// </summary>
        public Guid PayId { get; set; }

        /// <summary>
        ///     Order id
        /// </summary>
        public string? OrderId { get; set; }

        /// <summary>
        ///     Card number
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        ///     Transaction status code
        /// </summary>
        public string? StatusCode { get; set; }


        /// <summary>
        ///     Transaction status
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        ///     Transaction status message
        /// </summary>

        public string? StatusMessage { get; set; }

        /// <summary>
        ///     Transaction confirm amount
        /// </summary>
        public decimal ConfirmAmount { get; set; }
    }
}
