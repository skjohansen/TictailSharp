using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TictailSharp.Api.Model.Store;

namespace TictailSharp.Api.Resources
{
    /// <summary>
    /// Store repository
    /// </summary>
    public class StoreResource : IStoreResource
    {
        private readonly ITictailClient _client;

        /// <summary>
        /// Construct Store repositiory
        /// </summary>
        /// <param name="client">Tictail client</param>
        public StoreResource(ITictailClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Get Store from Tictail API
        /// </summary>
        /// <param name="storeId">ID of store to retrive</param>
        /// <returns>A Store</returns>
        public Store this[string storeId]
        {
            get { return Get(storeId); }
        }

        /// <summary>
        /// Get Store from Tictail API
        /// </summary>
        /// <param name="storeId">ID of store to retrive</param>
        /// <returns>A Store</returns>
        public Store Get(string storeId)
        {
            if (string.IsNullOrEmpty(storeId))
            {
                throw new Exception("You can't specify an empty storeId");
            }

            var request = new RestRequest("v1/stores/{storeId}", Method.GET);
            request.AddUrlSegment("storeId", storeId);
            Store store;
            try
            {
                store = DeserializeGet(_client.ExecuteRequest(request, HttpStatusCode.OK).Content);
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("No Store found with ID : " + storeId);
            }
            store.Products = new ProductResource(_client, storeId);
            store.Theme = new ThemeResource(_client, storeId);
            store.Categories = new CategoryResource(_client, storeId);
            store.Customers = new CustomerResource(_client, storeId);
            store.Followers = new FollowerResource(_client, storeId);
            store.Orders = new OrderResource(_client, storeId);
            return store;
        }

        /// <summary>
        /// Deserilize the Store data fetched from the Tictail API
        /// </summary>
        /// <param name="data">Store JSON data</param>
        /// <returns>A Store</returns>
        public Store DeserializeGet(string data)
        {
            return JsonConvert.DeserializeObject<Store>(data);
        }

        /// <summary>
        /// Patch (Update) a store
        /// </summary>
        /// <param name="storeId">ID of store to patch</param>
        /// <param name="resource">Values which should be updated, null are ignored</param>
        public Store Patch(string storeId, PatchStore resource)
        {
            if (string.IsNullOrEmpty(storeId))
            {
                throw new Exception("You can't specify an empty storeId");
            }

            var request = new RestRequest("v1/stores/{storeId}", Method.PATCH);
            request.AddUrlSegment("storeId", storeId);
            request.RequestFormat = DataFormat.Json;
            
            var serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            string bodyContent;
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, resource);
                bodyContent = writer.ToString();
            }

            request.AddParameter("application/json", bodyContent, ParameterType.RequestBody);
            Store store;
            try
            {
                store = DeserializeGet(_client.ExecuteRequest(request, HttpStatusCode.OK).Content);
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("No Store found with ID : " + storeId);
            }

            return store;
        }
    }
}
