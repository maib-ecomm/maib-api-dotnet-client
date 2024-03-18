using System;
using System.Text.Json.Serialization;
using MerchantHub.Connector.Proxy.Api.Models.Enums;

namespace MerchantHub.Connector.Proxy.Api.Models.Responses;

public class ExecuteRecurringPaymentResponse
{
    /// <summary>
    ///     Pay id
    /// </summary>
    [JsonPropertyName("payId")]
    public Guid PayId { get; set; }

    /// <summary>
    ///     Transaction rrn
    /// </summary>
    [JsonPropertyName("rrn")]
    public string Rrn { get; set; }

    /// <summary>
    ///     Order id
    /// </summary>
    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    /// <summary>
    ///     Biller id
    /// </summary>
    [JsonPropertyName("billerId")]
    public Guid? BillerId { get; set; }

    /// <summary>
    ///     Transaction status
    /// </summary>
    [JsonPropertyName("statusCode")]
    public string? StatusCode { get; set; }

    /// <summary>
    ///     Payment status
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    ///     Payment status message
    /// </summary>
    [JsonPropertyName("statusMessage")]
    public string? StatusMessage { get; set; }

    /// <summary>
    ///     Approval code
    /// </summary>
    [JsonPropertyName("approval")]
    public string Approval { get; set; }

    /// <summary>
    ///     Transaction currency
    /// </summary>
    [JsonPropertyName("currency")]
    public Currency Currency { get; set; }

    /// <summary>
    ///     Transaction amount
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    /// <summary>
    ///     Transaction card
    /// </summary>
    [JsonPropertyName("cardNumber")]
    public string CardNumber { get; set; }
}