﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Maib.Ecomm.Api.Connector.Models.Enums;

namespace Maib.Ecomm.Api.Connector.Models.Requests;

public sealed class ExecuteRecurringPaymentRequest : BaseRequest
{
    protected override string Action => "/v1/execute-recurring";

    /// <summary>
    /// Card identifier saved in maib ecomm system
    /// </summary>
    [JsonPropertyName("billerId")]
    public Guid BillerId { get; set; }

    /// <summary>
    /// Transaction amount. Format: X.XX
    /// 
    /// E.g: 10.25 (currency=USD) means $10 and 25 cents.
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    /// <summary>
    /// Transaction currency (MDL/EUR/USD)
    /// </summary>
    [JsonPropertyName("currency")]
    public Currency Currency { get; set; }

    /// <summary>
    /// Payment description.
    /// 
    /// Displayed on maib ecomm checkout page.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Order ID generated by Merchant website/app
    /// </summary>
    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

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