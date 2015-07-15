using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TictailSharp.Api.Model.Category;

namespace TictailSharp.Api.Resources
{
    /// <summary>
    /// Category repository
    /// </summary>
    public class CategoryResource : ICategoryResource
    {
        private readonly ITictailClient _client;

        /// <summary>
        /// Construct Category repositiory
        /// </summary>
        /// <param name="client">Tictail client</param>
        /// <param name="storeId">ID of Tictail store to retrive Category from</param>
        public CategoryResource(ITictailClient client, string storeId)
        {
            _client = client;
            StoreId = storeId;
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>An enumerator of Category</returns>
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
            catch (KeyNotFoundException)
            {
                throw new Exception("No Store found with ID : " + StoreId);
            }
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>An enumerator of Category</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Get();
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>An enumerator of Category</returns>
        IEnumerator<Category> IEnumerable<Category>.GetEnumerator()
        {
            return Get();
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>An enumerator of Category</returns>
        public IEnumerator<Category> GetRange()
        {
            return Get();
        }

        /// <summary>
        /// ID of store to fetch Product from
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        /// Deserlize array of categories
        /// </summary>
        /// <param name="data">JSON array of categories</param>
        /// <returns>An enumerator of Category</returns>
        public IEnumerator<Category> DeserializeRangeGet(string data)
        {
            return JsonConvert.DeserializeObject<List<Category>>(data).GetEnumerator();
        }


    }
}
