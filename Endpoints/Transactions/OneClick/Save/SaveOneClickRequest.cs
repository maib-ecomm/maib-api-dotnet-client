using MerchantHub.Connector.Proxy.Api.Models;

namespace MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.OneClick.Save
{
    public sealed class SaveOneClickRequest : SaveRequest
    {
        protected override string Action => "/v1/savecard-oneclick";
    }
}
