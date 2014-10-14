using Newtonsoft.Json;
using System.Globalization;
using System.Text;

namespace TictailSharp.Api.Model
{
    public class Token
    {
        /// <summary>
        /// 
        /// </summary>
        /// <example>"accesstoken_xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"</example>
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>"Bearer"</example>
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>3155760000</example>
        [JsonProperty(PropertyName = "expires_in")]
        public long ExpiresIn { get; set; }


        [JsonProperty(PropertyName = "store")]
        public AccessStore Store { get; set; }


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
