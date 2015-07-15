using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TictailSharp.Api.Model.Oauth;

namespace TictailSharp.Api.Resources
{
    /// <summary>
    /// Oauth repository
    /// </summary>
    public class OauthResource : IOauthResource
    {
        private readonly ITictailClient _client;

        /// <summary>
        /// Construct Oauth repositiory
        /// </summary>
        /// <param name="client">Tictail client</param>
        public OauthResource(ITictailClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Deserlize the response from the token service
        /// </summary>
        /// <param name="data">JSON token data</param>
        /// <returns>A token object</returns>
        public Token DeserializeGet(string data)
        {
            return JsonConvert.DeserializeObject<Token>(data);
        }

        /// <summary>
        /// Post token request back to Tictail
        /// </summary>
        /// <param name="oauth">Oauth object</param>
        /// <returns>A token</returns>
        public Token Post(Oauth oauth)
        {
            var request = new RestRequest("oauth/token", Method.POST);

            request.AddParameter("application/x-www-form-urlencoded", oauth.GenerateBody(), ParameterType.RequestBody);

            string content = _client.ExecuteRequest(request, HttpStatusCode.OK).Content;
            return DeserializeGet(content);
        }
    }
}
