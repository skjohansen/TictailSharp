using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TictailSharp.Api.Model;

namespace TictailSharp.Api.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ITictailClient _client;

        public CustomerRepository(ITictailClient client, string storeId)
        {
            _client = client;
            StoreId = storeId;
        }

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
            catch (KeyNotFoundException kex)
            {
                throw new Exception("No Customer found with ID : " + customerId + ", at store : " + StoreId);
            }
        }

        public IEnumerator<Customer> GetRange()
        {
            return GetRangeFull();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="after">Only get customers after this id Defaults to the first customer.</param>
        /// <param name="before">Only get customers before this id</param>
        /// <param name="limit">Limit number of customers returned (default 100)</param>
        /// <returns></returns>
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
            catch (KeyNotFoundException kex)
            {
                //TODO: Can there also be an error if wrong afterProductId, beforeProductId, limit ??
                throw new Exception("No Store found with ID : " + StoreId);
            }
        }

        public IEnumerator<Customer> GetEnumerator()
        {
            return GetRangeFull(null, null, 100000U);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string StoreId { get; set; }

        public Customer this[string customerId]
        {
            get { return Get(customerId); }
        }


        public IEnumerator<Customer> DeserializeRangeGet(string value)
        {
            return JsonConvert.DeserializeObject<List<Customer>>(value).GetEnumerator();
        }

        public Customer DeserializeGet(string value)
        {
            return JsonConvert.DeserializeObject<Customer>(value);
        }





    }
}
