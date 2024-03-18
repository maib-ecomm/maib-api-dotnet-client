using Maib.Ecomm.Api.Connector.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Maib.Ecomm.Api.Connector.Extensions;

/// <summary>
///     Represents Service Collection extensions.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Adds connector to merchant ecomm service.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <param name="serviceLifetime">The <see cref="T:Microsoft.Extensions.DependencyInjection.ServiceLifetime" /> of the service.</param>
    /// <param name="sectionName">Name of the section.</param>
    public static IServiceCollection AddMaibEcommConnector(
        this IServiceCollection services,
        IConfiguration configuration, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton,
        string sectionName = "MaibEcommApiClient")
    {
        services.Configure<ConnectorOptions>(c => configuration.GetSection(sectionName).Bind(c));
        services.AddHttpClient(MaibEcommApiClient.HttpClientName);
        services.Add(new ServiceDescriptor(typeof(IMaibEcommApiClient), typeof(MaibEcommApiClient),
            serviceLifetime));

        return services;
    }
}