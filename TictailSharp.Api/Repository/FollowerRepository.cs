using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using TictailSharp.Api.Model.Follower;

namespace TictailSharp.Api.Repository
{
    /// <summary>
    /// Follower repository
    /// </summary>
    public class FollowerRepository : IFollowerRepository
    {
        private readonly ITictailClient _client;

        /// <summary>
        /// Construct Follower repositiory
        /// </summary>
        /// <param name="client">Tictail client</param>
        /// <param name="storeId">ID of Tictail store to retrive Follower from</param>
        public FollowerRepository(ITictailClient client, string storeId)
        {
            _client = client;
            StoreId = storeId;
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
            catch (KeyNotFoundException)
            {
                throw new Exception("No Store found with ID : " + StoreId);
            }
        }
      
        /// <summary>
        /// Delete a follower from the store
        /// </summary>
        /// <param name="follower">The follower to delete</param>
        /// <returns>True if delete succeeded</returns>
        public bool Delete(Follower follower)
        {
            //  https://tictail.com/developers/documentation/api-reference/#Follower
            if (string.IsNullOrEmpty(StoreId))
            {
                throw new Exception("You must provide a valid store Id");
            }

            // /v1/stores/<store_id>/followers/<user_id>
            var request = new RestRequest("v1/stores/{storeId}/followers/{userId}", Method.DELETE);
            request.AddUrlSegment("storeId", StoreId);
            request.AddUrlSegment("userId", follower.Id);

            try
            {
                _client.ExecuteRequest(request, HttpStatusCode.NoContent); // 204 = NoContent
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        /// <summary>
        /// Get all followers
        /// </summary>
        /// <returns>An enumerator of Follower</returns>
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
            catch (KeyNotFoundException)
            {
                throw new Exception("No Store found with ID : " + StoreId);
            }
        }

        /// <summary>
        /// Deserlize array of followers
        /// </summary>
        /// <param name="data">JSON array of followers</param>
        /// <returns>An enumerator of Follower</returns>
        public IEnumerator<Follower> DeserializeRangeGet(string data)
        {
            return JsonConvert.DeserializeObject<List<Follower>>(data).GetEnumerator();
        }

        /// <summary>
        /// Get all followers
        /// </summary>
        /// <returns>An enumerator of Follower</returns>
        IEnumerator<Follower> IEnumerable<Follower>.GetEnumerator()
        {
            return GetRange();
        }

        /// <summary>
        /// Get all followers
        /// </summary>
        /// <returns>An enumerator of Follower</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetRange();
        }

        /// <summary>
        /// ID of store to fetch Product from
        /// </summary>
        public string StoreId { get; set; }
    }
}
