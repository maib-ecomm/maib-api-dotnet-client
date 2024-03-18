# MAIB api .NET client
[![N|Solid](https://www.maib.md/images/logo.svg)](https://www.maib.md)


CONTENTS OF THIS FILE
=====================

 * Introduction
 * Requirements
 * Installation
 * Before usage
 * Usage
 * Examples
 * Troubleshoting


INTRODUCTION
============

The MAIB api .NET client is a .NET Core based library used to easily integrate the MAIB MerchantProxy into your project.

The MAIB api .NET client has 4 payment methods.
 * Direct payment (`PayAsync`) - the customer's money is transferred to the merchant account instantly when the customer makes a payment. This method is preferred.
 * 2 step payment (`HoldDmsPaymentAsync`, `CompleteDmsPaymentAsync`) - this type of transaction occurs in two stages. The payment must first be initiated using `HoldDmsPaymentAsync` and then completed using `CompleteDmsPaymentAsync`.
 * Recurring payment(`SaveRecurringPaymentAsync`, `ExecuteRecurringPaymentAsync`) - this type of transaction allows customer to save the card for later use. Transaction must be initiated with `SaveRecurringPaymentAsync`. After that, subsequential payments can be performed by merchant with `ExecuteRecurringPaymentAsync`
 * One-Click payment (`SaveOneClickPaymentAsync`, `ExecuteOneClickPaymentAsync`) - this type of transaction allows customer to save the card for later use. Transaction must be initiated with `SaveOneClickPaymentAsync`. Then on the check-out form customer should select save card. After that, subsequential payments can be initiated with `ExecuteOneClickPaymentAsync`.
 * Refund payment (`RefundPaymentAsync`) - this operation is intended for refunding all types of transactions.
 * Delete card (`DeleteBillerAsync`) - this operation is intended for deleting cards saved for recurring and one-click transactions.

 Operation `GenerateTokenAsync` is used to aqcuire access token, used in another operations. 


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

To perform any operations with client you need to obtain the `ProjectId` and `ProjectSecret` in MechantHub.

USAGE
=====
 * Program.cs needs to include
  ```csharp
    using MerchantHub.Connector.Proxy.Api.Extensions;
  ````
 * Register the client
  ```csharp
    services.AddMerchantProxyConnector({IConfiguration instance}, {sectionName});
  ````
   configuration must contain the following section:

   ```csharp
    "sectionName": {
        "Url": "OurApiUrl",
        "RequestTimeoutMs": {nr of ms for timeout}
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

EXAMPLES
========
* Access token generation

```csharp
            var generateTokenRequest = new GenerateTokenRequest
            {
                ProjectId = "YourProjectId",
                ProjectSecret = "YourProjectSecret"
            };

            var generateTokenResult = await _merchantHubProxyClient.GenerateTokenAsync(generateTokenRequest, cancellationToken);

            if (!generateTokenResult.Ok)
            {
                // result failed
                foreach (var error in generateTokenResult.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }

                return;
            }
````

* Direct payments

```csharp
            var payRequest = new PayRequest
            {
                AccessToken = generateTokenResult.Result.AccessToken,
                Amount = 10.1m,
                CallBackUrl = "Your CallBackUrl", //optional
                ClientIp = "Your ClientIp",
                ClientName = "Your ClientName",
                Currency = Currency.MDL,
                Delivery = 2m, //optional
                Description = "Your description", //optional
                Email = "Your email", //optional
                FailUrl = "Your fail url", //optional
                OkUrl = "Your ok url", //optional
                Language = "en", //optional available options en/ru/ro
                OrderId = "Your order id", //optional
                Phone = "Your phone number", //optional
                Items = new List<ItemDto> //optional
                {
                    new ItemDto
                    {
                        Id = "Item id", //optional
                        Name = "Item name", //optional
                        Price = 20.0m, //optional
                        Quantity = 2 //optional
                    }
                }
            };
            var payResult = await _merchantHubProxyClient.PayAsync(payRequest, cancellationToken);
            if (!payResult.Ok)
            {
                //request failed
                foreach (var error in payResult.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }

                return;
            }

            var payId = payResult.Result.PayId;
            var payUrl = payResult.Result.PayUrl;

            //process pay response ...

            return;
````

* 2 step payments

First step

```csharo
            var holdRequest = new HoldDmsPaymentRequest
            {
                AccessToken = generateTokenResult.Result.AccessToken,
                Amount = 10.1m,
                CallBackUrl = "Your CallBackUrl", //optional
                ClientIp = "Your ClientIp",
                ClientName = "Your ClientName",
                Currency = Currency.MDL,
                Delivery = 2m, //optional
                Description = "Your description", //optional
                Email = "Your email", //optional
                FailUrl = "Your fail url", //optional
                OkUrl = "Your ok url", //optional
                Language = "en", //optional available options en/ru/ro
                OrderId = "Your order id", //optional
                Phone = "Your phone number", //optional
                Items = new List<ItemDto> //optional
                {
                    new ItemDto
                    {
                        Id = "Item id", //optional
                        Name = "Item name", //optional
                        Price = 20.0m, //optional
                        Quantity = 2 //optional
                    }
                }
            };
            var holdResult = await _merchantHubProxyClient.HoldDmsPaymentAsync(holdRequest, cancellationToken);
            if (!holdResult.Ok)
            {
                //request failed
                foreach (var error in holdResult.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }

                return;
            }

            var payId = holdResult.Result.PayId;
            var payUrl = holdResult.Result.PayUrl;

            //process hold response ...

            return;
```
Second step

```csharp
            var completeRequest = new CompleteDmsPaymentRequest()
            {
                PayId = holdResult.PayId, // payment id from result of the previous step
                AccessToken = generateTokenResult.Result.AccessToken,
                ConfirmAmount = 10.1m,
                ClientIp = "Your ClientIp",
            };
            var completeResult = await _merchantHubProxyClient.CompleteDmsPaymentAsync(completeRequest, cancellationToken);
            if (!completeResult.Ok)
            {
                //request failed
                foreach (var error in completeResult.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }

                return;
            }

            var payId = completeResult.Result.PayId;
            var orderId = completeResult.Result.OrderId;//null if was not send on hold request
            var cardNumber = completeResult.Result.CardNumber;
            var statusCode = completeResult.Result.StatusCode;
            var status = completeResult.Result.Status;
            var statusMessage = completeResult.Result.StatusMessage;
            var confirmAmount = completeResult.Result.ConfirmAmount;

            //process complete response ...

            return;
```
* One-Click payments

Save card

```csharp
            var saveRequest = new SaveOneClickPaymentRequest()
            {
                AccessToken = generateTokenResult.Result.AccessToken,
                Amount = 10.1m,
                CallBackUrl = "Your CallBackUrl", //optional
                ClientIp = "Your ClientIp",
                ClientName = "Your ClientName",
                Currency = Currency.MDL,
                Delivery = 2m, //optional
                Description = "Your description", //optional
                Email = "Your email", //optional
                FailUrl = "Your fail url", //optional
                OkUrl = "Your ok url", //optional
                Language = "en", //optional available options en/ru/ro
                OrderId = "Your order id", //optional
                Phone = "Your phone number", //optional
                Items = new List<ItemDto> //optional
                {
                    new ItemDto
                    {
                        Id = "Item id", //optional
                        Name = "Item name", //optional
                        Price = 20.0m, //optional
                        Quantity = 2 //optional
                    }
                },
                BillerExpiry = "Your card expiration date"
            };
            var saveResult = await _merchantHubProxyClient.SaveOneClickPaymentAsync(saveRequest, cancellationToken);
            if (!saveResult.Ok)
            {
                //request failed
                foreach (var error in saveResult.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }

                return;
            }

            var payId = saveResult.Result.PayId;
            var payUrl = saveResult.Result.PayUrl;

            //process save response ...

            return;
```

Execute one-click payments
```csharp
            var executeOneClickRequest = new ExecuteOneClickPaymentRequest()
            {
                AccessToken = generateTokenResult.Result.AccessToken,
                Amount = 10.1m,
                CallBackUrl = "Your CallBackUrl", //optional
                Currency = Currency.MDL,
                Delivery = 2m, //optional
                Description = "Your description", //optional
                FailUrl = "Your fail url", //optional
                OkUrl = "Your ok url", //optional
                Language = "en", //optional available options en/ru/ro
                OrderId = "Your order id", //optional
                Items = new List<ItemDto> //optional
                {
                    new ItemDto
                    {
                        Id = "Item id", //optional
                        Name = "Item name", //optional
                        Price = 20.0m, //optional
                        Quantity = 2 //optional
                    }
                },
                BillerId = Guid.NewGuid()//this is sent to the callback url that was setted on save one click request in case if the user selected savecard on checkout form
            };
            var executeOneClickResult = await _merchantHubProxyClient.ExecuteOneClickPaymentAsync(executeOneClickRequest, cancellationToken);
            if (!executeOneClickResult.Ok)
            {
                //request failed
                foreach (var error in executeOneClickResult.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }

                return;
            }

            var payId = executeOneClickResult.Result.PayId;
            var payUrl = executeOneClickResult.Result.PayUrl;

            //process execute response ...

            return;
```

* Recurring payments

Save recurring
```csharp
            var saveRecurringRequest = new SaveRecurringPaymentRequest()
            {
                AccessToken = generateTokenResult.Result.AccessToken,
                Amount = 10.1m,
                CallBackUrl = "Your CallBackUrl", //optional
                ClientIp = "Your ClientIp",
                ClientName = "Your ClientName",
                Currency = Currency.MDL,
                Delivery = 2m, //optional
                Description = "Your description", //optional
                Email = "Your email", //optional
                FailUrl = "Your fail url", //optional
                OkUrl = "Your ok url", //optional
                Language = "en", //optional available options en/ru/ro
                OrderId = "Your order id", //optional
                Phone = "Your phone number", //optional
                Items = new List<ItemDto> //optional
                {
                    new ItemDto
                    {
                        Id = "Item id", //optional
                        Name = "Item name", //optional
                        Price = 20.0m, //optional
                        Quantity = 2 //optional
                    }
                },
                BillerExpiry = "Your card expiration date"
            };
            var saveRecurringPaymentAsync = await _merchantHubProxyClient.SaveRecurringPaymentAsync(saveRecurringRequest, cancellationToken);
            if (!saveRecurringPaymentAsync.Ok)
            {
                //request failed
                foreach (var error in saveRecurringPaymentAsync.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }

                return;
            }

            var payId = saveRecurringPaymentAsync.Result.PayId;
            var payUrl = saveRecurringPaymentAsync.Result.PayUrl;

            //process save response ...

            return;
```

Execute recurring
```csharp
            var executeRecurringRequest = new ExecuteRecurringPaymentRequest()
            {
                AccessToken = generateTokenResult.Result.AccessToken,
                Amount = 10.1m,
                Currency = Currency.MDL,
                Delivery = 2m, //optional
                Description = "Your description", //optional
                OrderId = "Your order id", //optional
                Items = new List<ItemDto> //optional
                {
                    new ItemDto
                    {
                        Id = "Item id", //optional
                        Name = "Item name", //optional
                        Price = 20.0m, //optional
                        Quantity = 2 //optional
                    }
                },
                BillerId = Guid.NewGuid()//this is sent to the callback url that was setted on save one click request in case if the user selected savecard on checkout form
            };
            var executeRecurrinResult = await _merchantHubProxyClient.ExecuteRecurringPaymentAsync(executeRecurringRequest, cancellationToken);
            if (!executeRecurrinResult.Ok)
            {
                //request failed
                foreach (var error in executeRecurrinResult.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }

                return;
            }

            var payId = executeRecurrinResult.Result.PayId;
            var orderId = executeRecurrinResult.Result.OrderId;//null if was not send on request
            var cardNumber = executeRecurrinResult.Result.CardNumber;
            var statusCode = executeRecurrinResult.Result.StatusCode;
            var status = executeRecurrinResult.Result.Status;
            var statusMessage = executeRecurrinResult.Result.StatusMessage;
            var rrn = executeRecurrinResult.Result.Rrn;
            var billerId = executeRecurrinResult.Result.BillerId;
            var approval = executeRecurrinResult.Result.Approval;
            var currency = executeRecurrinResult.Result.Currency;
            var amount = executeRecurrinResult.Result.Amount;


            //process execute response ...

            return;
```
* Refund payment
```csharp
            var refundRequest = new RefundPaymentRequest
            {
                AccessToken = generateTokenResult.Result.AccessToken,
                PayId = Guid.NewGuid(), //id of payment which you want to refund
                RefundAmount = 10m //should be smaller or equal to the amount you payed for this pay Id
            };
            var refundResult = await _merchantHubProxyClient.RefundPaymentAsync(refundRequest, cancellationToken);
            if (!refundResult.Ok)
            {
                //request failed
                foreach (var error in refundResult.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }

                return;
            }

            var payId = refundResult.Result.PayId;
            var orderId = refundResult.Result.OrderId;//null if was not send on pay request
            var refundAmount = refundResult.Result.RefundAmount;
            var statusCode = refundResult.Result.StatusCode;
            var status = refundResult.Result.Status;
            var statusMessage = refundResult.Result.StatusMessage;


            //process refund response ...

            return;
```
* Delete biller
```csharp
            var deleteRequest = new DeleteBillerRequest()
            {
                AccessToken = generateTokenResult.Result.AccessToken,
                BillerId = Guid.NewGuid() //id of biller which you want to delete
            };
            var deleteBillerAsync = await _merchantHubProxyClient.DeleteBillerAsync(deleteRequest, cancellationToken);
            if (!deleteBillerAsync.Ok)
            {
                //request failed
                foreach (var error in deleteBillerAsync.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }

                return;
            }

            var payId = deleteBillerAsync.Result.BillerId;
            var status = deleteBillerAsync.Result.Status;

            //process delete response ...

            return;
```

* Check payment
```csharp
            var checkRequest = new CheckPaymentRequest()
            {
                AccessToken = generateTokenResult.Result.AccessToken,
                PayId = Guid.NewGuid() //id of payment which you want to check
            };
            var checkPaymentAsync = await _merchantHubProxyClient.CheckPaymentAsync(checkRequest, cancellationToken);
            if (!checkPaymentAsync.Ok)
            {
                //request failed
                foreach (var error in checkPaymentAsync.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }

                return;
            }

            //all properties are nullable
            var payId = checkPaymentAsync.Result.PayId;
            var orderId = checkPaymentAsync.Result.OrderId;
            var cardNumber = checkPaymentAsync.Result.CardNumber;
            var statusCode = checkPaymentAsync.Result.StatusCode;
            var status = checkPaymentAsync.Result.Status;
            var statusMessage = checkPaymentAsync.Result.StatusMessage;
            var rrn = checkPaymentAsync.Result.Rrn;
            var billerId = checkPaymentAsync.Result.BillerId;
            var billerExpiry = checkPaymentAsync.Result.BillerExpiry;
            var approval = checkPaymentAsync.Result.Approval;
            var currency = checkPaymentAsync.Result.Currency;
            var amount = checkPaymentAsync.Result.Amount;
            var clientName = checkPaymentAsync.Result.ClientName;
            var threeDs = checkPaymentAsync.Result.ThreeDs;
            var confirmAmount = checkPaymentAsync.Result.ConfirmAmount;
            var refundAmount = checkPaymentAsync.Result.RefundAmount;
            var description = checkPaymentAsync.Result.Description;
            var clientIp = checkPaymentAsync.Result.ClientIp;
            var email = checkPaymentAsync.Result.Email;
            var phone = checkPaymentAsync.Result.Phone;
            var delivery = checkPaymentAsync.Result.Delivery;
            var items = checkPaymentAsync.Result.Items;


            //process delete response ...

            return;
```

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

For more indepth description refer to [Official documentation](https://docs.maibmerchants.md/)
