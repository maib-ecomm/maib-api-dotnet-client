using System;

namespace MerchantHub.Connector.Proxy.Api.Exceptions;

/// <summary>
/// Thrown when the service is reachable, but the response status code was not 200.
/// </summary>
public class StatusCodeException : Exception
{
    /// <summary>
    /// Gets the HTTP status code.
    /// </summary>
    public int HttpStatusCode { get; }

    internal StatusCodeException(int httpStatusCode)
    : base("Response status code does not indicate success: " + httpStatusCode)
    {
        HttpStatusCode = httpStatusCode;
    }
}