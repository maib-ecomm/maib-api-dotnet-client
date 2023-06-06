using System;
using System.Collections.Generic;
using MerchantHub.Connector.Proxy.Api.Dtos;
using MerchantHub.Connector.Proxy.Api.Models.Enums;

namespace MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Check
{
    public sealed class CheckResult
    {
        /// <summary>
        ///     Pay id
        /// </summary>
        public Guid PayId { get; set; }

        /// <summary>
        ///     Payment order id
        /// </summary>
        public string? OrderId { get; set; }

        /// <summary>
        ///     Biller id
        /// </summary>

        public Guid? BillerId { get; set; }

        /// <summary>
        ///     Payment currency
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        ///     Biller expiry in format MMYY
        /// </summary>
        public string? BillerExpiry { get; set; }

        /// <summary>
        ///     Transaction status
        /// </summary>
        public string? StatusCode { get; set; }

        /// <summary>
        ///     Payment method
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }

        /// <summary>
        ///     Payment status
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        ///     Payment status message
        /// </summary>
        public string? StatusMessage { get; set; }

        /// <summary>
        ///     Payment client name
        /// </summary>
        public string? ClientName { get; set; }

        /// <summary>
        ///     3D Secure
        /// </summary>
        public string? ThreeDs { get; set; }

        /// <summary>
        ///     Transaction rrn
        /// </summary>
        public string? Rrn { get; set; }

        /// <summary>
        ///     Approval code
        /// </summary>
        public string? Approval { get; set; }

        /// <summary>
        ///     Transaction confirmed amount
        /// </summary>
        public decimal? ConfirmAmount { get; set; }

        /// <summary>
        ///     Transaction amount
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        ///     Transaction refund amount
        /// </summary>
        public decimal? RefundAmount { get; set; }

        /// <summary>
        ///     Transaction Description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        ///     Client ip
        /// </summary>
        public string? ClientIp { get; set; }

        /// <summary>
        ///     Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        ///     Phone
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        ///     Delivery cost
        /// </summary>
        public decimal? Delivery { get; set; }

        /// <summary>
        ///     Items
        /// </summary>
        public List<ItemDto>? Items { get; set; }

        /// <summary>
        ///     Card number masked
        /// </summary>
        public string CardNumber { get; set; }
    }
}
