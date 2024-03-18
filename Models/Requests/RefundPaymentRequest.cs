using System;
using System.Text.Json.Serialization;

namespace Maib.Ecomm.Api.Connector.Models.Requests;

public sealed class RefundPaymentRequest : BaseRequest
{
    protected override string Action => "/v1/refund";

    /// <summary>
    /// The identifier of the transaction to be refunded
    /// </summary>
    [JsonPropertyName("payId")]
    public Guid PayId { get; set; }

    /// <summary>
    /// Amount to be returned to Costumer. Format: X.XX
    /// 
    /// E.g: 10.25 (currency=USD) means $10 and 25 cents.
    /// 
    /// It can be less than or equal to the transaction amount.
    /// 
    /// If this parameter is not present, the full transaction amount will be refunded.
    /// </summary>
    [JsonPropertyName("refundAmount")]
    public decimal? RefundAmount { get; set; }
}