using System;
using Maib.Ecomm.Api.Connector.Models;

namespace Maib.Ecomm.Api.Connector.Exceptions;

/// <summary>
/// Thrown when service encounters one or more errors. It may be a request validation error or another business condition.
/// </summary>
public class OperationException : Exception
{
    /// <summary>
    /// Gets the collection of operation errors
    /// </summary>
    public OperationError[] OperationErrors { get; }

    /// <summary>
    /// Gets the HTTP status code of the operation
    /// </summary>
    public int HttpStatusCode { get; }

    internal OperationException(int httpStatusCode, OperationError[] operationErrors) : base("One or more errors occurred in the operation")
    {
        OperationErrors = operationErrors;
        HttpStatusCode = httpStatusCode;
    }
}