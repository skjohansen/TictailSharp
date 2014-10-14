using System;
using System.Text;

namespace TictailSharp.Api.Model
{
    public class Oauth
    {
        private const string GrantTypeAuthorizationCode = "authorization_code";

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AuthCode { get; set; }

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
