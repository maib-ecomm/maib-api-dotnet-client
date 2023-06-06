using MerchantHub.Connector.Proxy.Api.Http;
using MerchantHub.Connector.Proxy.Api.Http.Interfaces;
using MerchantHub.Connector.Proxy.Api.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MerchantHub.Connector.Proxy.Api.Extensions
{
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
        /// <param name="sectionName">Name of the section.</param>
        public static IServiceCollection AddMerchantProxyConnector(
            this IServiceCollection services,
            IConfiguration configuration,
            string sectionName = "MerchantHubProxyApi")
        {
            return services
                .AddHttpClient()
                .Configure<ConnectorOptions>(c => configuration.GetSection(sectionName).Bind(c))
                .AddSingleton<RestClient>()
                .AddSingleton<IMerchantHubProxyClient, MerchantHubProxyClient>()
                .AddSingleton<IEndpointClient>(sp => sp.GetRequiredService<RestClient>());
        }
    }
}
