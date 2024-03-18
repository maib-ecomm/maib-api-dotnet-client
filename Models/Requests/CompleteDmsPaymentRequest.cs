using System;
using System.Text.Json.Serialization;

namespace MerchantHub.Connector.Proxy.Api.Models.Requests;

public sealed class CompleteDmsPaymentRequest : BaseRequest
{
    protected override string Action => "/v1/complete";

    /// <summary>
    /// The identifier of the transaction that has been authorized and must be completed
    /// </summary>
    [JsonPropertyName("payId")]
    public Guid PayId { get; set; }

    /// <summary>
    /// Amount to be debited from Customer's bank account. Format: X.XX
    /// 
    /// E.g: 10.25 (currency=USD) means $10 and 25 cents.
    /// 
    /// It can be less than or equal to the amount that was previously put on hold.
    /// 
    /// If this parameter is not present, the entire previously put on hold amount will be debited.
    /// </summary>
    [JsonPropertyName("confirmAmount")]
    public decimal? ConfirmAmount { get; set; }

    /// <summary>
    /// Client ip
    /// </summary>
    [JsonPropertyName("clientIp")]
    public string ClientIp { get; set; }
}