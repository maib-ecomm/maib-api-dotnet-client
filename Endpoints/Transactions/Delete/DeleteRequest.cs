using System;
using System.Net.Http;
using MerchantHub.Connector.Proxy.Api.Models;

namespace MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Delete
{
    public sealed class DeleteRequest : BaseRequest
    {
        protected override string Action => "/v1/delete-card/{billerId}";

        protected override HttpMethod HttpMethod => HttpMethod.Delete;

        /// <summary>
        ///     Biller id
        /// </summary>

        public Guid BillerId { get; set; }

        internal override HttpRequestMessage ToHttpRequest(string url)
        {
            return new HttpRequestMessage(HttpMethod.Delete, url + string.Format(Action, BillerId));
        }
    }
}
