using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TictailSharp.Api.Model;

namespace TictailSharp.Api.Repository
{
    public class MeRepository : IMeRepository
    {
        private readonly ITictailClient _client;

        public MeRepository(ITictailClient client)
        {
            _client = client;
        }

        public Me Get()
        {
            var request = new RestRequest("v1/me", Method.GET);
            try
            {
                return DeserializeGet(_client.ExecuteRequest(request, HttpStatusCode.OK).Content);
            }
            catch (KeyNotFoundException kex)
            {
                throw new Exception("No Me found");
            }
        }

        public Me DeserializeGet(string value)
        {
            //GET /v1/me
            return JsonConvert.DeserializeObject<Me>(value);

        }
    }
}
