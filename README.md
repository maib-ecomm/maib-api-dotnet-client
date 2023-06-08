# MAIB MerchantProxy .NET SDK
[![N|Solid](https://www.maib.md/images/logo.svg)](https://www.maib.md)


CONTENTS OF THIS FILE
=====================

 * Introduction
 * Requirements
 * Installation
 * Before usage
 * Usage
 * Troubleshoting


INTRODUCTION
============

The MAIB MerchantProxy .NET SDK is used to easily integrate the MAIB MerchantProxy into your project.
Based on the .NET Core Libraries to connect and process the requests with the Bank server.

The MAIB MerchantProxy .NET SDK has 4 ways of payment.
 * SMS Transaction (`PayAsync`). When the client's money transfers on the merchant account instantly when the user do the payment. This way is recommended use.
 * DMS Transaction (`HoldDmsPaymentAsync`, `CompleteDmsPaymentAsync`). This type of transaction is executed in two steps. First payment needs to be initiated with `HoldDmsPaymentAsync` then completed with `CompleteDmsPaymentAsync`.
 * OneClick Transaction (`SaveOneClickPaymentAsync`, `ExecuteOneClickPaymentAsync`). This type of transaction allow user to save the card for latter use. First user need to save the card by `SaveOneClickPaymentAsync` on check-out form should select save card then user cand execute oneclick payments by `ExecuteOneClickPaymentAsync` with the `BillerId` property.
 * Recurring Transactions (`SaveRecurringPaymentAsync`, `ExecuteRecurringPaymentAsync`). This type is similar to OneClick transactions except the fact that user don't have to check anything on check-out form but the order of execution should be the following first `SaveRecurringPaymentAsync` then for later transactions `ExecuteRecurringPaymentAsync` with the `BillerId`.
 * Refund Transaction (`RefundPaymentAsync`). This is intended for refunding all type of transactions.

 For authentication ther is `GenerateTokenAsync`. 


REQUIREMENTS
============

 * Any .NET implimentation [Combatibility](https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-1)


INSTALLATION
============

 * Via terminal
 ```bash
dotnet add package MerchantHub.Connector.Proxy.Api --version {latest available version}
 ```

* Paste into *.csproj

```xml
<PackageReference Include="MerchantHub.Connector.Proxy.Api" Version="{latest available version}" />
```


BEFORE USAGE
============

To initiate an payment you need to obtain the `ProjectId` and `ProjectSecret` in MechantHub.

USAGE
=====
 * Namespace needed to include
  ```csharp
    using MerchantHub.Connector.Proxy.Api.Extensions;
  ````
 * Register the client first overload
  ```csharp
    services.AddMerchantProxyConnector({IConfiguration instance}, {sectionName});
  ````
   in configuration should have the following section:

   ```csharp
    "sectionName": {
        "Url": "OurApiUrl",
        "ReqeustTimoutMs": {nr of ms for timeout}
    }
  ````
 * Second overload
  
  ```csharp
    services.AddMerchantProxyConnector({IConfiguration instance});
  ````
   in configuration should have the following section:
  ```csharp
    "MerchantHubProxyApi": {
        "Url": "OurApiUrl",
        "ReqeustTimoutMs": {nr of ms for timeout}
    }
  ````
  * Dependency injection
  ```csharp

    public class YourService{
        private readonly IMerchantHubProxyClient _merchantClient;
        public YourService(IMerchantHubProxyClient merchantClient){
            _merchantClient = merchantClient;
        }
    }
  ````

TROUBLESHOTING
==============
All requests return following result:
```json
{
  "Result": {},
  "Ok": bool,
  "OperationId": uuid,
  "Errors": []
}
````

Properties
- Ok - denotes if the response is succesful or not. Succesful response is when Result is not null and errors are null or empty list
- OperationId - returns operation id needed for debuging purposes and logs
- Result - holds request response
- Errors - holds request errors

For more indepth description refer to [Official documentation](https://maib-ecommerce.gitbook.io/ro/)
