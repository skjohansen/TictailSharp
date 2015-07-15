using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TictailSharp.Api.Model.Customer;

namespace TictailSharp.Api.Resources
{
    /// <summary>
    /// Customer repository
    /// </summary>
    public class CustomerResource : ICustomerResource
    {
        private readonly ITictailClient _client;

        /// <summary>
        /// Construct Customer repositiory
        /// </summary>
        /// <param name="client">Tictail client</param>
        /// <param name="storeId">ID of Tictail store to retrive Customer from</param>
        public CustomerResource(ITictailClient client, string storeId)
        {
            _client = client;
            StoreId = storeId;
        }

        /// <summary>
        /// Get a Customer from Tictail API
        /// </summary>
        /// <param name="customerId">ID of the Customer</param>
        /// <returns>A specific Customer</returns>
        public Customer Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                throw new Exception("You must provide a valid customer Id");
            }

            if (string.IsNullOrEmpty(StoreId))
            {
                throw new Exception("You must provide a valid store Id");
            }

            var request = new RestRequest("v1/stores/{storeId}/customers/{customerId}", Method.GET);
            request.AddUrlSegment("storeId", StoreId);
            request.AddUrlSegment("customerId", customerId);

            try
            {
                // GET /v1/stores/<store_id>/customers/<customer_id>
                string content = _client.ExecuteRequest(request, HttpStatusCode.OK).Content;
                return DeserializeGet(content);

            }
            catch (KeyNotFoundException)
            {
                throw new Exception("No Customer found with ID : " + customerId + ", at store : " + StoreId);
            }
        }



        /// <summary>
        /// Get all Customers, or a specific range
        /// </summary>
        /// <param name="after">Only get Customers after this id Defaults to the first customer.</param>
        /// <param name="before">Only get Customers before this id</param>
        /// <param name="limit">Limit number of customers returned (default 100)</param>
        /// <returns>An enumerator of Customers</returns>
        public IEnumerator<Customer> GetRangeFull(string after=null, string before = null, uint limit = 100)
        {
            if (string.IsNullOrEmpty(StoreId))
            {
                throw new Exception("You must provide a valid store Id");
            }

            var request = new RestRequest("v1/stores/{storeId}/customers", Method.GET);
            request.AddUrlSegment("storeId", StoreId);
            if (!string.IsNullOrEmpty(after))
            {
                request.AddParameter(new Parameter() { Name = "after", Value = after, Type = ParameterType.QueryString });
            }

            if (!string.IsNullOrEmpty(before))
            {
                request.AddParameter(new Parameter() { Name = "before", Value = before, Type = ParameterType.QueryString });
            }

            if (limit > 0)
            {
                request.AddParameter(new Parameter() { Name = "limit", Value = limit, Type = ParameterType.QueryString });
            }

            try
            {
                // GET /v1/stores/<store_id>/products
                string content = _client.ExecuteRequest(request, HttpStatusCode.OK).Content;
                return DeserializeRangeGet(content);
            }
            catch (KeyNotFoundException)
            {
                //TODO: Can there also be an error if wrong afterProductId, beforeProductId, limit ??
                throw new Exception("No Store found with ID : " + StoreId);
            }
        }

        /// <summary>
        /// Get enumerator of all Customers
        /// </summary>
        /// <returns>An enumerator of Customers</returns>
        public IEnumerator<Customer> GetRange()
        {
            return GetRangeFull();
        }

        /// <summary>
        /// Get enumerator of all Customers
        /// </summary>
        /// <returns>An enumerator of Customers</returns>
        public IEnumerator<Customer> GetEnumerator()
        {
            return GetRange();
        }

        /// <summary>
        /// Get enumerator of all Customers
        /// </summary>
        /// <returns>An enumerator of Customers</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// ID of store to fetch Product from
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        /// Get a Customer from Tictail API
        /// </summary>
        /// <param name="customerId">ID of the customer</param>
        /// <returns>A specific Customer</returns>
        public Customer this[string customerId]
        {
            get { return Get(customerId); }
        }

        /// <summary>
        /// Deserlize array of customers
        /// </summary>
        /// <param name="data">JSON array of customers</param>
        /// <returns>An enumerator of Customers</returns>
        public IEnumerator<Customer> DeserializeRangeGet(string data)
        {
            return JsonConvert.DeserializeObject<List<Customer>>(data).GetEnumerator();
        }

        /// <summary>
        /// Deserlize an customer
        /// </summary>
        /// <param name="data">JSON data of a customer</param>
        /// <returns>A Customer</returns>
        public Customer DeserializeGet(string data)
        {
            return JsonConvert.DeserializeObject<Customer>(data);
        }





    }
}
