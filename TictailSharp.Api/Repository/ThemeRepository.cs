using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TictailSharp.Api.Model;

namespace TictailSharp.Api.Repository
{
    public class ThemeRepository : IThemeRepository, IStore
    {
        private readonly ITictailClient _client;

        public ThemeRepository(ITictailClient client, string storeId)
        {
            _client = client;
            StoreId = storeId;
        }

        public Theme Get()
        {
            if (string.IsNullOrEmpty(StoreId))
            {
                throw new Exception("You must provide a valid product Id");
            }

            var request = new RestRequest("v1/stores/{storeId}/theme", Method.GET);
            request.AddUrlSegment("storeId", StoreId);

            try
            {
                return DeserializeGet(_client.ExecuteRequest(request, HttpStatusCode.OK).Content);
            }
            catch (KeyNotFoundException kex)
            {
                throw new Exception("No Me found");
            }
        }

        public string StoreId { get; set; }


        public Theme DeserializeGet(string value)
        {
            //GET /v1/stores/<store_id>/theme
            return JsonConvert.DeserializeObject<Theme>(value);
        }
    }
}
