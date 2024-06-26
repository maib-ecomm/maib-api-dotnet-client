﻿using System;
using System.Text.Json.Serialization;

namespace Maib.Ecomm.Api.Connector.Models.Responses;

public sealed class RefundPaymentResponse
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
    public string OrderId { get; set; }

    /// <summary>
    /// Refund status.
    /// 
    /// OK - successfully refunded.
    /// 
    /// REVERSED - the transaction has previously been refunded; repeated refund are not allowed.
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
    /// Amount returned to Costumer. Format: X.XX
    /// </summary>
    [JsonPropertyName("refundAmount")]
    public decimal? RefundAmount { get; set; }
}