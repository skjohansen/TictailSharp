using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TictailSharp.Api.Model.Store;

namespace TictailSharp.Api.Repository
{
    /// <summary>
    /// Store repository
    /// </summary>
    public class StoreRepository : IStoreRepository
    {
        private readonly ITictailClient _client;

        /// <summary>
        /// Construct Store repositiory
        /// </summary>
        /// <param name="client">Tictail client</param>
        public StoreRepository(ITictailClient client)
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
            store.Products = new ProductRepository(_client, storeId);
            store.Theme = new ThemeRepository(_client, storeId);
            store.Categories = new CategoryRepository(_client, storeId);
            store.Customers = new CustomerRepository(_client, storeId);
            store.Followers = new FollowerRepository(_client, storeId);
            store.Orders = new OrderRepository(_client, storeId);
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

    }
}
