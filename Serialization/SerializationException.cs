using System;

namespace MerchantHub.Connector.Proxy.Api.Serialization
{
    /// <summary>
    /// Thrown when the data returned from the service could not be serialized or deserialize.
    /// </summary>
    public sealed class SerializationException : Exception
    {
        public string SourceText { get; internal set; }

        internal SerializationException(string message, Exception innerException, string? sourceText = null)
            : base(message, innerException)
        {
            SourceText = sourceText;
        }
    }
}
