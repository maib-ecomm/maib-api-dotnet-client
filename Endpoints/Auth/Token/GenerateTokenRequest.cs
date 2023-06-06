using MerchantHub.Connector.Proxy.Api.Models;

namespace MerchantHub.Connector.Proxy.Api.Endpoints.Auth.Token
{
    public sealed class GenerateTokenRequest : BaseRequest
    {
        protected override string Action => "/v1/generate-token";

        /// <summary>
        /// Project Id
        /// </summary>
        public string ProjectId { get; set; }

        /// <summary>
        /// Project password
        /// </summary>
        public string? ProjectSecret { get; set; }

        /// <summary>
        /// Refresh token
        /// </summary>
        public string? RefreshToken { get; set; }
    }
}
