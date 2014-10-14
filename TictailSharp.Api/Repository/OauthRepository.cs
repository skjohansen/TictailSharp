using Newtonsoft.Json;
using RestSharp;
using System.Net;
using TictailSharp.Api.Model;

namespace TictailSharp.Api.Repository
{
    public class OauthRepository : IOauthRespository
    {
        private readonly ITictailClient _client;

        public OauthRepository(ITictailClient client)
        {
            _client = client;
        }


        public Token DeserializeGet(string value)
        {
            return JsonConvert.DeserializeObject<Token>(value);
        }

        public Token Post(Oauth oauth)
        {
            var request = new RestRequest("oauth/token", Method.POST);

            request.AddParameter("application/x-www-form-urlencoded", oauth.GenerateBody(), ParameterType.RequestBody);

            string content = _client.ExecuteRequest(request, HttpStatusCode.OK).Content;
            return DeserializeGet(content);
        }
    }
}
