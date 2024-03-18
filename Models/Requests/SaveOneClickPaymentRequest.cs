namespace MerchantHub.Connector.Proxy.Api.Models.Requests;

public sealed class SaveOneClickPaymentRequest : SavePaymentRequest
{
    protected override string Action => "/v1/savecard-oneclick";
}