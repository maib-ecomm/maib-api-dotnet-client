using System;
using System.Net.Http;

namespace Maib.Ecomm.Api.Connector.Models.Requests;

public sealed class CheckPaymentRequest : BaseRequest
{
    protected override string Action => "/v1/pay-info/{0}";

    protected override HttpMethod HttpMethod => HttpMethod.Get;

    /// <summary>
    /// Transaction identifier assigned by maib ecomm
    /// </summary>
    public Guid PayId { get; set; }

    internal override HttpRequestMessage ToHttpRequest(string url)
    {
        return new HttpRequestMessage(HttpMethod, url + string.Format(Action, PayId));
    }
}