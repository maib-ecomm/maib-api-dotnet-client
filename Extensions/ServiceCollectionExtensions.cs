using MerchantHub.Connector.Proxy.Api.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MerchantHub.Connector.Proxy.Api.Extensions;

/// <summary>
///     Represents Service Collection extensions.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Adds connector to merchant proxy service.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <param name="serviceLifetime">The <see cref="T:Microsoft.Extensions.DependencyInjection.ServiceLifetime" /> of the service.</param>
    /// <param name="sectionName">Name of the section.</param>
    public static IServiceCollection AddMerchantProxyConnector(
        this IServiceCollection services,
        IConfiguration configuration, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton,
        string sectionName = "MerchantHubProxyApi")
    {
        services.Configure<ConnectorOptions>(c => configuration.GetSection(sectionName).Bind(c));
        services.AddHttpClient(MerchantHubProxyClient.HttpClientName);
        services.Add(new ServiceDescriptor(typeof(IMerchantHubProxyClient), typeof(MerchantHubProxyClient),
            serviceLifetime));

        return services;
    }
}