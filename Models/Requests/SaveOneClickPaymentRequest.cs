namespace Maib.Ecomm.Api.Connector.Models.Requests;

public sealed class SaveOneClickPaymentRequest : SavePaymentRequest
{
    protected override string Action => "/v1/savecard-oneclick";
}