using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using TictailSharp.Api.Model;

namespace TictailSharp.Api.Repository
{
    public class FollowerRepository : IFollowerRepository
    {
        private readonly ITictailClient _client;

        public FollowerRepository(ITictailClient client, string storeId)
        {
            _client = client;
            StoreId = storeId;
        }

        public string StoreId { get; set; }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetRange();
        }


        /// <summary>
        /// Add a new follower of this store
        /// </summary>
        /// <param name="follower">The new follower (only email is need)</param>
        /// <returns>Location - The url of the created follower</returns>
        public string Post(Follower follower)
        {
            //  https://tictail.com/developers/documentation/api-reference/#Follower
            if (string.IsNullOrEmpty(StoreId))
            {
                throw new Exception("You must provide a valid store Id");
            }

            //POST /v1/stores/<store_id>/followers
            var request = new RestRequest("v1/stores/{storeId}/followers", Method.POST);
            request.AddUrlSegment("storeId", StoreId);

            var postBody = new JObject();
            postBody.Add("email", follower.Email);
            string body = postBody.ToString();
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            
            try
            {
                var response = _client.ExecuteRequest(request, HttpStatusCode.Created);

                var locationHeader = response.Headers.FirstOrDefault(f => f.Name == "Location");
                if (locationHeader == null)
                {
                    return string.Empty;
                }
                return (string)locationHeader.Value;
            }
            catch (KeyNotFoundException kex)
            {
                throw new Exception("No Store found with ID : " + StoreId);
            }
        }
      
        public bool Delete(Follower value)
        {
            //  https://tictail.com/developers/documentation/api-reference/#Follower
            if (string.IsNullOrEmpty(StoreId))
            {
                throw new Exception("You must provide a valid store Id");
            }

            // /v1/stores/<store_id>/followers/<user_id>
            var request = new RestRequest("v1/stores/{storeId}/followers/{userId}", Method.DELETE);
            request.AddUrlSegment("storeId", StoreId);
            request.AddUrlSegment("userId", value.Id);

            try
            {
                _client.ExecuteRequest(request, HttpStatusCode.NoContent); // 204 = NoContent
                return true;
            }
            catch (KeyNotFoundException kex)
            {
                return false;
            }
        }

        public IEnumerator<Follower> GetRange()
        {
            if (string.IsNullOrEmpty(StoreId))
            {
                throw new Exception("You must provide a valid store Id");
            }

            //GET /v1/stores/<store_id>/followers
            var request = new RestRequest("v1/stores/{storeId}/followers", Method.GET);
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

        public IEnumerator<Follower> DeserializeRangeGet(string value)
        {
            return JsonConvert.DeserializeObject<List<Follower>>(value).GetEnumerator();
        }

        IEnumerator<Follower> IEnumerable<Follower>.GetEnumerator()
        {
            return GetRange();
        }
    }
}
