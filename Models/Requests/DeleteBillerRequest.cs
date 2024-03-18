using System;
using System.Net.Http;

namespace Maib.Ecomm.Api.Connector.Models.Requests
{
    public sealed class DeleteBillerRequest : BaseRequest
    {
        protected override string Action => "/v1/delete-card/{0}";

        protected override HttpMethod HttpMethod => HttpMethod.Delete;

        /// <summary>
        /// Card identifier in the maib ecomm system
        /// </summary>
        public Guid BillerId { get; set; }

        internal override HttpRequestMessage ToHttpRequest(string url)
        {
            return new HttpRequestMessage(HttpMethod.Delete, url + string.Format(Action, BillerId));
        }
    }
}
