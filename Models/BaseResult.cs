using System;

namespace MerchantHub.Connector.Proxy.Api.Models
{
    public sealed class BaseResult
    {
        /// <summary>
        ///     Pay id
        /// </summary>
        public Guid PayId { get; set; }

        /// <summary>
        ///     Pay url
        /// </summary>
        public string PayUrl { get; set; }
    }
}
