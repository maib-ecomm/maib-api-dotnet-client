namespace MerchantHub.Connector.Proxy.Api.Dtos
{
    public sealed class ItemDto
    {
        /// <summary>
        ///     Item id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        ///     OrderItem name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        ///     OrderItem price
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        ///     Total nr of items
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        ///     Item total price
        /// </summary>
        public decimal? Total { get; set; }
    }
}
