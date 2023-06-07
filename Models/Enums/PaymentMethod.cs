using System.ComponentModel;

namespace MerchantHub.Connector.Proxy.Api.Models.Enums
{
    public enum PaymentMethod
    {
        [Description("ApplePay")] 
        ApplePay = 0,
        [Description("GooglePay")] 
        GooglePay = 1,
        [Description("Card")] 
        Card = 2,
    }
}
