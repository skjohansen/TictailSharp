using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model.Oauth
{
    /// <summary>
    /// Token retuned when requesting access to the API using Oauth
    /// </summary>
    public class Token
    {
        /// <summary>
        /// The token which provides access to the API
        /// </summary>
        /// <example>"accesstoken_xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"</example>
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Type of token
        /// </summary>
        /// <example>"Bearer"</example>
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// When the token expires
        /// </summary>
        /// <example>3155760000</example>
        [JsonProperty(PropertyName = "expires_in")]
        public long ExpiresIn { get; set; }

        /// <summary>
        /// Information on the store the token gives access to
        /// </summary>
        [JsonProperty(PropertyName = "store")]
        public AccessStore Store { get; set; }

        /// <summary>
        /// Output all properties
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("AccessTokenValue: ").AppendLine(AccessToken);
            toString.Append("TokenType: ").AppendLine(TokenType);
            toString.Append("ExpiresIn: ").AppendLine(ExpiresIn.ToString(CultureInfo.InvariantCulture));
            toString.Append("ExpiresIn: ").AppendLine(Store.ToString());
            return toString.ToString();

        }
    }
}
