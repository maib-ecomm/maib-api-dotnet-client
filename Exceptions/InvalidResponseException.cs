using System;

namespace MerchantHub.Connector.Proxy.Api.Exceptions;

/// <summary>
/// Thrown when the response returned from an endpoint cannot be parsed as a valid response.
/// The usually means the endpoint URL does not point to an service.
/// </summary>
public class InvalidResponseException : Exception
{
    /// <summary>
    /// Gets the response text.
    /// </summary>
    public string ResponseText { get; }

    /// <summary>
    /// Gets the HTTP status code.
    /// </summary>
    public int HttpStatusCode { get; }

    internal InvalidResponseException(int httpStatusCode, string responseText, Exception? innerException = null)
        : base($"Unexpected response (HTTP {httpStatusCode}): {responseText}", innerException)
    {
        HttpStatusCode = httpStatusCode;
        ResponseText = responseText;
    }
}