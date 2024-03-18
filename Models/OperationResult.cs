using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace MerchantHub.Connector.Proxy.Api.Models;
/// <summary>
///     Any action result
/// </summary>
public abstract class OperationResult
{
    /// <summary>
    ///     Error that occurred during execution
    /// </summary>
    [JsonPropertyName("errors")]
    public List<OperationError>? Errors { get; set; }

    /// <summary>
    ///     Returns True when Errors is empty and Result is set.
    /// </summary>
    [MemberNotNullWhen(false, nameof(Errors))]
    [JsonPropertyName("ok")]
    public virtual bool Ok => (Errors == null || Errors.Count == 0);

    /// <summary>
    ///     Returns as factory method OperationResult with result and error
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="result">The result.</param>
    /// <param name="error">The error.</param>
    public static OperationResult<TResult> CreateResult<TResult>(TResult result, OperationError? error) => new OperationResult<TResult>
    {
        Result = result,
        Errors = error == null ? null : new List<OperationError> { error }
    };

    /// <summary>
    ///     Returns as factory method OperationResult with result and errors
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="result">The result.</param>
    /// <param name="errors">The errors.</param>
    public static OperationResult<TResult> CreateResult<TResult>(TResult result, List<OperationError>? errors = null) => new OperationResult<TResult>
    {
        Result = result,
        Errors = errors
    };

    /// <summary>
    ///     Returns as factory method EmptyOperationResult
    /// </summary>
    /// <param name="errors">The errors.</param>
    public static EmptyOperationResult CreateEmptyResult(List<OperationError>? errors = null) => new EmptyOperationResult
    {
        Errors = errors
    };


    /// <summary>
    ///     Returns as factory method EmptyOperationResult
    /// </summary>
    /// <param name="error">The error.</param>
    public static EmptyOperationResult CreateEmptyResult(OperationError? error) => new EmptyOperationResult
    {
        Errors = error == null ? null : new List<OperationError>
            {
                error
            }
    };
}

/// <summary>
///     Generic operation result for any requests for Web API service and some MVC actions.
/// </summary>
public class OperationResult<TResult> : OperationResult
{
    /// <summary>
    ///     Result for server operation
    /// </summary>
    [JsonPropertyName("result")]
    public TResult? Result { get; set; }

    [MemberNotNullWhen(true, nameof(Result))]
    [JsonPropertyName("ok")]
    public override bool Ok => base.Ok;
}

/// <summary>
///     Generic operation result for empty requests for Web API service and some MVC actions.
/// </summary>
public class EmptyOperationResult : OperationResult
{
}