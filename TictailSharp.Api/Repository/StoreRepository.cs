using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TictailSharp.Api.Model;

namespace TictailSharp.Api.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ITictailClient _client;

        public StoreRepository(ITictailClient client)
        {
            _client = client;
        }

        public Store this[string idOrHref]
        {
            get { return Get(idOrHref); }
        }

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
            catch (KeyNotFoundException kex)
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

        public Store DeserializeGet(string value)
        {
            return DeserializeGet(value, "[undefined]");
        }

        public Store DeserializeGet(string value, string storeId)
        {
            return JsonConvert.DeserializeObject<Store>(value);

        }
    }
}
