using System;

namespace Maib.Ecomm.Api.Connector.Exceptions;

/// <summary>
/// Thrown when a connection to the service cannot be made. Could have multiple causes.
/// </summary>
public class NotReachableException : Exception
{
    internal NotReachableException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}