using System;
using System.Text;

namespace TictailSharp.Api.Model.Oauth
{
    /// <summary>
    /// Oauth used for Authentication
    /// </summary>
    public class Oauth
    {
        private const string GrantTypeAuthorizationCode = "authorization_code";

        /// <summary>
        /// ClientId for Tictail App
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// ClientSecret for Tictail App
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// AuthCode recived from Tictail
        /// </summary>
        public string AuthCode { get; set; }

        /// <summary>
        /// Generate the body send to Tictail
        /// </summary>
        /// <returns>A string of the correctly formed body send to Tictail to retrive an AccessToken</returns>
        public string GenerateBody()
        {
            if (string.IsNullOrEmpty(ClientId))
            {
                throw new Exception("ClientId is not defined");
            }

            if (string.IsNullOrEmpty(ClientSecret))
            {
                throw new Exception("ClientSecret is not defined");
            }

            if (string.IsNullOrEmpty(AuthCode))
            {
                throw new Exception("AuthCode is not defined");
            }

            var oauthBody = new StringBuilder();
            oauthBody.Append("client_id=").Append(ClientId).Append("&");
            oauthBody.Append("client_secret=").Append(ClientSecret).Append("&");
            oauthBody.Append("grant_type=").Append(GrantTypeAuthorizationCode).Append("&");
            oauthBody.Append("code=").Append(AuthCode);
            return oauthBody.ToString();
        }

        /// <summary>
        /// All properties of the Oauth
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("ClientId: ").AppendLine(ClientId);
            toString.Append("ClientSecret: ").AppendLine(ClientSecret);
            toString.Append("AuthCode: ").AppendLine(AuthCode);

            return toString.ToString();

        }

    }
}
