using System;
using System.Text.Json.Serialization;

namespace MerchantHub.Connector.Proxy.Api.Models.Responses
{
    public sealed class DeleteBillerResponse
    {
        /// <summary>
        /// Card identifier in the maib ecomm system
        /// </summary>
        [JsonPropertyName("billerId")]
        public Guid BillerId { get; set; }

        /// <summary>
        /// Request execution status.
        /// 
        /// OK - card has been successfully deleted.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
