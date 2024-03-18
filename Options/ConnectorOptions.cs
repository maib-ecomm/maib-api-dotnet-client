namespace MerchantHub.Connector.Proxy.Api.Options;

/// <summary>
/// Connector options for otp service
/// </summary>
public class ConnectorOptions
{
    private string _url = "https://api.maibmerchants.md";

    /// <summary>
    /// The URL address of the service.
    /// </summary>
    public string Url
    {
        get => _url;
        set => _url = value.TrimEnd('/');
    }

    /// <summary>
    /// How long to wait, in milliseconds, for the Connector before failing.
    /// </summary>
    public int RequestTimeoutMs { get; set; } = 10000;
}