﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MerchantHub.Connector.Proxy.Api.Models.Enums;

namespace MerchantHub.Connector.Proxy.Api.Models.Responses
{
    public sealed class CheckPaymentResponse
    {
        /// <summary>
        /// Transaction identifier assigned by maib ecomm
        /// </summary>
        [JsonPropertyName("payId")]
        public Guid PayId { get; set; }

        /// <summary>
        /// Order ID generated by Merchant website/app
        /// </summary>
        [JsonPropertyName("orderId")]
        public string? OrderId { get; set; }

        /// <summary>
        /// Card identifier registered in maib ecomm system (for recurring/one-click payments)
        /// </summary>

        [JsonPropertyName("billerId")]
        public Guid? BillerId { get; set; }

        /// <summary>
        /// The date (month/year) until which the card data will be saved in maib ecomm system (for recurring/one-click payments).
        /// 
        /// Format: MMYY (e.g: 1229 - december 2029).
        /// </summary>
        [JsonPropertyName("billerExpiry")]
        public string? BillerExpiry { get; set; }

        /// <summary>
        /// <see href="https://docs.maibmerchants.md/en/transaction-and-3d-secure-status#transaction-status">Transaction status</see>
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Transaction status code
        /// </summary>
        [JsonPropertyName("statusCode")]
        public string? StatusCode { get; set; }

        /// <summary>
        /// Transaction status information message
        /// </summary>
        [JsonPropertyName("statusMessage")]
        public string? StatusMessage { get; set; }

        /// <summary>
        /// <see href="https://docs.maibmerchants.md/en/transaction-and-3d-secure-status#3d-secure-authentication">3-D Secure authentication result</see>
        /// </summary>
        [JsonPropertyName("threeDs")]
        public string? ThreeDs { get; set; }

        /// <summary>
        /// RRN - Transaction ID generated by maib
        /// </summary>
        [JsonPropertyName("rrn")]
        public string? Rrn { get; set; }

        /// <summary>
        /// Approval Code - The transaction approval code generated by the card issuing bank
        /// </summary>
        [JsonPropertyName("approval")]
        public string? Approval { get; set; }

        /// <summary>
        /// Masked number card
        /// </summary>
        [JsonPropertyName("cardNumber")]
        public string CardNumber { get; set; }

        /// <summary>
        /// Transaction amount. Format: X.XX
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal? Amount { get; set; }

        /// <summary>
        /// Amount debited from Customer's account in format X.XX (for two-step payments)
        /// </summary>
        [JsonPropertyName("confirmAmount")]
        public decimal? ConfirmAmount { get; set; }

        /// <summary>
        /// Amount refunded to Buyer in formatt X.XX (for refunded payments)
        /// </summary>
        [JsonPropertyName("refundAmount")]
        public decimal? RefundAmount { get; set; }

        /// <summary>
        /// Transaction currency (MDL/EUR/USD)
        /// </summary>
        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }

        /// <summary>
        /// Payment description
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Customer IP
        /// </summary>
        [JsonPropertyName("clientIp")]
        public string? ClientIp { get; set; }

        /// <summary>
        /// Customer name
        /// </summary>
        [JsonPropertyName("clientName")]
        public string? ClientName { get; set; }

        /// <summary>
        /// Customer email
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Customer phone
        /// </summary>
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        /// <summary>
        /// Shipping cost
        /// </summary>
        [JsonPropertyName("delivery")]
        public decimal? Delivery { get; set; }

        /// <summary>
        /// The products or services ordered from the website/app
        /// </summary>
        [JsonPropertyName("items")]
        public List<ItemDto>? Items { get; set; }
    }
}
