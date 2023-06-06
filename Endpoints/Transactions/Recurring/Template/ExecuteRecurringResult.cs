using System;
using MerchantHub.Connector.Proxy.Api.Models.Enums;

namespace MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Recurring.Template
{
    public class ExecuteRecurringResult
    {
        /// <summary>
        ///     Pay id
        /// </summary>
        public Guid PayId { get; set; }

        /// <summary>
        ///     Transaction rrn
        /// </summary>
        public string Rrn { get; set; }

        /// <summary>
        ///     Order id
        /// </summary>
        public string? OrderId { get; set; }

        /// <summary>
        ///     Biller id
        /// </summary>
        public Guid? BillerId { get; set; }

        /// <summary>
        ///     Transaction status
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

        /// <summary>
        ///     Approval code
        /// </summary>
        public string Approval { get; set; }

        /// <summary>
        ///     Transaction currency
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        ///     Transaction amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        ///     Transaction card
        /// </summary>
        public string CardNumber { get; set; }
    }
}
