using System;

namespace MerchantHub.Connector.Proxy.Api.Endpoints.Transactions.Delete
{
    public sealed class DeleteResult
    {

        /// <summary>
        /// Biller client id
        /// </summary>
        public Guid BillerId { get; set; }

        /// <summary>
        /// Transaction status
        /// </summary>
        public string Status { get; set; }
    }
}
