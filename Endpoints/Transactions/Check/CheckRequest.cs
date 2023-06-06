using System;
using System.Net.Http;
using MerchantHub.Connector.Proxy.Api.Models;

namespace MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Check
{
    public sealed class CheckRequest : BaseRequest
    {

        protected override string Action => "/v1/pay-info/{payId}";

        protected override HttpMethod HttpMethod => HttpMethod.Get;

        /// <summary>
        ///     Payment id
        /// </summary>
        public Guid PayId { get; set; }

        internal override HttpRequestMessage ToHttpRequest(string url)
        {
            return new HttpRequestMessage(HttpMethod.Get, url + string.Format(Action, PayId));
        }
    }
}
