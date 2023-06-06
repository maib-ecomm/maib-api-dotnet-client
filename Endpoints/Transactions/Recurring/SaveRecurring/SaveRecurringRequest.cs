using MerchantHub.Connector.Proxy.Api.Models;

namespace MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Recurring.SaveRecurring
{
    public sealed class SaveRecurringRequest : SaveRequest
    {
        protected override string Action => "/v1/savecard-recurring";
    }
}
