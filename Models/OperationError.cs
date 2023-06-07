namespace MerchantHub.Connector.Proxy.Api.Models
{

    public class OperationError
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OperationError" /> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorMessage">The error message.</param>
        public OperationError(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        ///     Gets the error code.
        /// </summary>
        public string ErrorCode { get; }

        /// <summary>
        ///     Gets the error message.
        /// </summary>
        public string ErrorMessage { get; }
    }
}
