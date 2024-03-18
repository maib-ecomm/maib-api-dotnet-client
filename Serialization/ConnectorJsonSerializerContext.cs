using System;
using System.Text.Json.Serialization;
using MerchantHub.Connector.Proxy.Api.Models;
using MerchantHub.Connector.Proxy.Api.Models.Enums;
using MerchantHub.Connector.Proxy.Api.Models.Requests;
using MerchantHub.Connector.Proxy.Api.Models.Responses;

namespace MerchantHub.Connector.Proxy.Api.Serialization;

[JsonSourceGenerationOptions(
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    Converters = new[] { typeof(JsonStringEnumConverter<Currency>) })]

[JsonSerializable(typeof(BaseRequest))]
[JsonSerializable(typeof(CheckPaymentRequest))]
[JsonSerializable(typeof(CompleteDmsPaymentRequest))]
[JsonSerializable(typeof(DeleteBillerRequest))]
[JsonSerializable(typeof(ExecuteOneClickPaymentRequest))]
[JsonSerializable(typeof(ExecuteRecurringPaymentRequest))]
[JsonSerializable(typeof(GenerateTokenRequest))]
[JsonSerializable(typeof(HoldDmsPaymentRequest))]
[JsonSerializable(typeof(PayRequest))]
[JsonSerializable(typeof(RefundPaymentRequest))]
[JsonSerializable(typeof(SaveOneClickPaymentRequest))]
[JsonSerializable(typeof(SaveRecurringPaymentRequest))]
[JsonSerializable(typeof(SaveRecurringPaymentRequest))]

[JsonSerializable(typeof(OperationResult<CheckPaymentResponse>))]
[JsonSerializable(typeof(OperationResult<CompleteDmsPaymentResponse>))]
[JsonSerializable(typeof(OperationResult<DeleteBillerResponse>))]
[JsonSerializable(typeof(OperationResult<ExecuteRecurringPaymentResponse>))]
[JsonSerializable(typeof(OperationResult<GenerateTokenResponse>))]
[JsonSerializable(typeof(OperationResult<InitPaymentResponse>))]
[JsonSerializable(typeof(OperationResult<RefundPaymentResponse>))]

[JsonSerializable(typeof(ItemDto))]
[JsonSerializable(typeof(OperationError))]
[JsonSerializable(typeof(OperationResult))]
[JsonSerializable(typeof(EmptyOperationResult))]

[JsonSerializable(typeof(Currency))]
internal partial class ConnectorJsonSerializerContext : JsonSerializerContext
{
}