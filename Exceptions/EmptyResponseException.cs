using System;

namespace MerchantHub.Connector.Proxy.Api.Exceptions;

/// <summary>
/// Thrown when the response returned from an endpoint is empty.
/// The usually means the endpoint URL does not point to an service.
/// </summary>
public class EmptyResponseException : Exception
{
    /// <summary>
    /// Gets the HTTP status code.
    /// </summary>
    public int HttpStatusCode { get; internal set; }

    internal EmptyResponseException(int httpStatusCode, Exception? innerException = null)
        : base("An empty response was received. StatusCode is " + httpStatusCode, innerException)
    {
        HttpStatusCode = httpStatusCode;
    }
}