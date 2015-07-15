using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TictailSharp.Api.Model.Order;

namespace TictailSharp.Api.Resources
{
    /// <summary>
    /// Order repository
    /// </summary>
    public class OrderResource : IOrderResource
    {
        private readonly ITictailClient _client;

        /// <summary>
        /// Construct Order repositiory
        /// </summary>
        /// <param name="client">Tictail client</param>
        /// <param name="storeId">ID of Tictail store to retrive Order from</param>
        public OrderResource(ITictailClient client, string storeId)
        {
            _client = client;
            StoreId = storeId;
        }


        /// <summary>
        /// Get all Orders
        /// </summary>
        /// <returns>An enumerator of orders</returns>
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
            catch (KeyNotFoundException)
            {
                throw new Exception("No Store found with ID : " + StoreId);
            }
        }

        /// <summary>
        /// Get an Order from Tictail API
        /// </summary>
        /// <param name="orderId">ID of the Order</param>
        /// <returns>A specific Order</returns>
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
            catch (KeyNotFoundException)
            {
                throw new Exception("No Order found with ID : " + orderId + ", at store : " + StoreId);
            }
        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns>An enumerator of orders</returns>
        public IEnumerator<Order> GetEnumerator()
        {
            return GetRange();
        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns>An enumerator of orders</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Get an Order from Tictail API
        /// </summary>
        /// <param name="orderId">ID of the order</param>
        /// <returns>A specific order</returns>
        public Order this[string orderId]
        {
            get { return Get(orderId); }
        }

        /// <summary>
        /// Get or Set ID of store to fetch Product from
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        /// Deserlize an Order
        /// </summary>
        /// <param name="data">JSON of a Order</param>
        /// <returns>An Order</returns>
        public Order DeserializeGet(string data)
        {
            return JsonConvert.DeserializeObject<Order>(data);
        }

        /// <summary>
        /// Deserlize array of Orders
        /// </summary>
        /// <param name="data">JSON array of Orders</param>
        /// <returns>An enumerator of Orders</returns>
        public IEnumerator<Order> DeserializeRangeGet(string data)
        {
            return JsonConvert.DeserializeObject<List<Order>>(data).GetEnumerator();
        }
    }
}
