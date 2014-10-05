using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TictailSharp.Api.Model;

namespace TictailSharp.Api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ITictailClient _client;

        public CategoryRepository(ITictailClient client, string storeId)
        {
            _client = client;
            StoreId = storeId;
        }

        public IEnumerator<Category> Get()
        {
            if (string.IsNullOrEmpty(StoreId))
            {
                throw new Exception("You must provide a valid store Id");
            }

            // GET /v1/stores/<store_id>/categories
            var request = new RestRequest("v1/stores/{storeId}/categories", Method.GET);
            request.AddUrlSegment("storeId", StoreId);

            try
            {
                string content = _client.ExecuteRequest(request, HttpStatusCode.OK).Content;
                return DeserializeRangeGet(content);
            }
            catch (KeyNotFoundException kex)
            {
                throw new Exception("No Store found with ID : " + StoreId);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Get();
        }

        public string StoreId { get; set; }


        public IEnumerator<Category> GetRange()
        {
            return Get();
        }

        public IEnumerator<Category> DeserializeRangeGet(string value)
        {
            return JsonConvert.DeserializeObject<List<Category>>(value).GetEnumerator();
        }

        IEnumerator<Category> IEnumerable<Category>.GetEnumerator()
        {
            return Get();
        }
    }
}
