using System.Text.Json.Serialization;

namespace Maib.Ecomm.Api.Connector.Models;

public sealed class ItemDto
{
    /// <summary>
    /// Product ID
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Product name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Product price
    /// </summary>
    [JsonPropertyName("price")]
    public decimal? Price { get; set; }

    /// <summary>
    /// Product quantity
    /// </summary>
    [JsonPropertyName("quantity")]
    public int? Quantity { get; set; }
}