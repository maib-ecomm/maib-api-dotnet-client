namespace MerchantHub.Connector.Proxy.Api.Endpoints.Auth.Token
{
    public sealed class GenerateTokenResult
    {
        /// <summary>
        ///     Access token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        ///     Number of seconds before expiration
        /// </summary>

        public int ExpiresIn { get; set; }

        /// <summary>
        ///     Refresh token
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        ///     Number of seconds before expiration of refresh token
        /// </summary>
        public int RefreshExpiresIn { get; set; }

        /// <summary>
        ///     Token type 
        /// </summary>
        public string TokenType { get; set; }
    }
}
