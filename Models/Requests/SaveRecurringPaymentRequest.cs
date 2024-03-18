namespace MerchantHub.Connector.Proxy.Api.Models.Requests;

public sealed class SaveRecurringPaymentRequest : SavePaymentRequest
{
    protected override string Action => "/v1/savecard-recurring";
}