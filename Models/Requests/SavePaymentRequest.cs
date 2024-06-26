﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using Maib.Ecomm.Api.Connector.Models.Enums;

namespace Maib.Ecomm.Api.Connector.Models.Requests;

public abstract class SavePaymentRequest : BaseRequest
{
    /// <summary>
    /// The date (month/year) until which the card data will be saved in maib ecomm system.
    /// 
    /// Format: MMYY (e.g: 1229 -&gt; 31 December 2029 / 23:59:59). 
    /// 
    /// If the validity of the card is lower than the value passed in this parameter, then the card data will be kept until the date of validity of the card.
    /// </summary>
    [JsonPropertyName("billerExpiry")]
    public string BillerExpiry { get; set; }

    /// <summary>
    /// Customer IP
    /// </summary>
    [JsonPropertyName("clientIp")]
    public string ClientIp { get; set; }

    /// <summary>
    /// Transaction amount. Format: X.XX
    /// 
    /// E.g: 10.25 (currency=USD) means $10 and 25 cents.
    /// 
    /// *If the parameter is passed, the amount will be debited from the Customer's account and the card data will be saved in the maib ecomm system.
    /// 
    /// *If the parameter is not passed, then the card data will be saved without debiting anything from the Customer's account.
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal? Amount { get; set; }

    /// <summary>
    /// Transaction currency (MDL/EUR/USD)
    /// </summary>
    [JsonPropertyName("currency")]
    public Currency Currency { get; set; }

    /// <summary>
    /// Language maib ecomm checkout page.
    /// 
    /// Allowed values: ro/en/ru
    /// 
    /// If this parameter is not passed, the page will be displayed in English
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; set; }

    /// <summary>
    /// Payment description.
    /// 
    /// Displayed on maib ecomm checkout page
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

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

    /// <summary>
    /// The link where the Merchant will receive the final response with the transaction status and data.
    /// 
    /// If this parameter is not passed, its value will be taken from maibmerchants.
    /// </summary>
    [JsonPropertyName("callbackUrl")]
    public string? CallBackUrl { get; set; }

    /// <summary>
    /// The link where the Customer will be redirected if the transaction was successful.
    /// 
    /// If this parameter is not passed, its value will be taken from maibmerchants. (GET request + payId&amp;orderId&amp;billerId)
    /// </summary>
    [JsonPropertyName("okUrl")]
    public string? OkUrl { get; set; }

    /// <summary>
    /// The link where the Customer will be redirected if the transaction was failed.
    /// 
    /// If this parameter is not passed, its value will be taken from maibmerchants. (GET request + payId&amp;orderId)
    /// </summary>
    [JsonPropertyName("failUrl")]
    public string? FailUrl { get; set; }
}