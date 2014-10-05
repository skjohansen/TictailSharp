using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TictailSharp.Api.Model;

namespace TictailSharp.Api.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ITictailClient _client;

        public OrderRepository(ITictailClient client, string storeId)
        {
            _client = client;
            StoreId = storeId;
        }

        public IEnumerator<Order> GetEnumerator()
        {
            return GetRange();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public Order this[string index]
        {
            get { return Get(index); }
        }

        public string StoreId { get; set; }

        
        public IEnumerator<Order> GetRange()
        {
            if (string.IsNullOrEmpty(StoreId))
            {
                throw new Exception("You must provide a valid store Id");
            }

            //GET /v1/stores/<store_id>/orders
            var request = new RestRequest("v1/stores/{storeId}/orders", Method.GET);
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

        public IEnumerator<Order> DeserializeRangeGet(string value)
        {
            return JsonConvert.DeserializeObject<List<Order>>(value).GetEnumerator();
        }

        public Order Get(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                throw new Exception("You must provide a valid order Id");
            }

            if (string.IsNullOrEmpty(StoreId))
            {
                throw new Exception("You must provide a valid store Id");
            }

            var request = new RestRequest("v1/stores/{storeId}/orders/{orderId}", Method.GET);
            request.AddUrlSegment("storeId", StoreId);
            request.AddUrlSegment("orderId", orderId);

            try
            {
                // GET /v1/stores/<store_id>/orders/<order_id>
                string content = _client.ExecuteRequest(request, HttpStatusCode.OK).Content;
                return DeserializeGet(content);

            }
            catch (KeyNotFoundException kex)
            {
                throw new Exception("No Order found with ID : " + orderId + ", at store : " + StoreId);
            }
        }

        public Order DeserializeGet(string value)
        {
            return JsonConvert.DeserializeObject<Order>(value);
        }




    }
}
