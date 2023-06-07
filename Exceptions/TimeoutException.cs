using System;

namespace MerchantHub.Connector.Proxy.Api.Exceptions
{
    /// <summary>
    /// Thrown when a request to the service times out, i.e. the service did not respond within <see cref="NotReachableException.RequestTimeoutMs"/> ms.
    /// </summary>
    /// <remarks>
    /// For short timeouts (under about 3 seconds) this may also be thrown for a failure to connect that would normally throw another
    /// <see cref="NotReachableException"/>, e.g. a "connection refused" error or DNS resolution error, because the attempt to connect times
    /// out before the "real" error has a chance to happen.
    /// </remarks>
    public class TimeoutException : NotReachableException
    {
        internal TimeoutException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}