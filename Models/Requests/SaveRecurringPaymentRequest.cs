namespace Maib.Ecomm.Api.Connector.Models.Requests;

public sealed class SaveRecurringPaymentRequest : SavePaymentRequest
{
    protected override string Action => "/v1/savecard-recurring";
}