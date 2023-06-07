using System;

namespace MerchantHub.Connector.Proxy.Api.Exceptions
{
    /// <summary>
    /// Thrown when the service is reachable, but the response status code was not 200.
    /// </summary>
    public class StatusCodeException : Exception
    {
        /// <summary>
        /// Gets the error code.
        /// </summary>
        public string ErrorCode { get; internal set; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string ErrorMessage { get; internal set; }

        /// <summary>
        /// Gets the HTTP status code.
        /// </summary>
        public int HttpStatusCode { get; internal set; }

        internal StatusCodeException(string message)
            : base(message)
        {
            ErrorMessage = message;
        }
    }
}