using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MerchantHub.Connector.Proxy.Api.Models;

public class OperationError
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="OperationError" /> class
    /// </summary>
    /// <param name="errorCode">The error code</param>
    /// <param name="errorMessage">The error message</param>
    /// <param name="errorArgs">Details of the error</param>
    public OperationError(string errorCode, string errorMessage, Dictionary<string, string> errorArgs)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
        ErrorArgs = errorArgs;
    }

    /// <summary>
    ///     Gets the error code
    /// </summary>
    [JsonPropertyName("errorCode")]
    public string ErrorCode { get; }

    /// <summary>
    ///     Gets the error message
    /// </summary>
    [JsonPropertyName("errorMessage")]
    public string ErrorMessage { get; }

    /// <summary>
    /// Details of the error
    /// </summary>
    [JsonPropertyName("errorArgs")]
    public Dictionary<string, string> ErrorArgs { get; }
}