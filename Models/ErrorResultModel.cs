namespace MerchantHub.Connector.Proxy.Api.Models
{
    /// <summary>
    /// Represents the error result model.
    /// </summary>
    public class ErrorResultModel
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string? ErrorMessage { get; set; }
    }
}
