using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TictailSharp.Api.Model;

namespace TictailSharp.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ITictailClient _client;

        public ProductRepository(ITictailClient client, string storeId)
        {
            _client = client;
            StoreId = storeId;
        }


        /// <summary>
        /// It's hard to sell online if you don't have anything to sell. Use this resource to get products in Tictail stores.
        /// </summary>
        /// <param name="productId">ID of the product</param>
        /// <returns>A specific product</returns>
        public Product Get(string productId)
        {

            if (string.IsNullOrEmpty(productId))
            {
                throw new Exception("You must provide a valid product Id");
            }

            if (string.IsNullOrEmpty(StoreId))
            {
                throw new Exception("You must provide a valid store Id");
            }

            var request = new RestRequest("v1/stores/{storeId}/products/{productId}", Method.GET);
            request.AddUrlSegment("storeId", StoreId);
            request.AddUrlSegment("productId", productId);

            try
            {
                // GET /v1/stores/<store_id>/products/<product_id>
                string content = _client.ExecuteRequest(request, HttpStatusCode.OK).Content;
                return DeserializeGet(content);
            }
            catch (KeyNotFoundException kex)
            {
                throw new Exception("No Product found with ID : " + productId + ", at store : " + StoreId);
            }
        }

        /// <summary>
        /// Get all product, or a specific range
        /// It's hard to sell online if you don't have anything to sell. Use this resource to get products in Tictail stores.
        /// </summary>
        /// <param name="after">Only get products after this product_id. Defaults to the first product.</param>
        /// <param name="before">Only get products before this product_id</param>
        /// <param name="limit">Limit number of products returned (default 100)</param>
        /// <param name="categories">List of category ids</param>
        /// <returns>A list of products</returns>
        public IEnumerator<Product> GetRangeFull(uint limit = 100, string after = null, string before = null, string[] categories = null)
        {
            if (string.IsNullOrEmpty(StoreId))
            {
                throw new Exception("You must provide a valid store Id");
            }

            var request = new RestRequest("v1/stores/{storeId}/products", Method.GET);
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

            if (categories != null && categories.Length != 0)
            {
                request.AddParameter(new Parameter() { Name = "categories", Value = String.Join(",", categories), Type = ParameterType.QueryString });
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
        
        public IEnumerator<Product> GetEnumerator()
        {
            return GetRangeFull(10000U);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Product this[string index]
        {
            get { return Get(index); }
        }

        public string StoreId { get; set; }


        public IEnumerator<Product> GetRange()
        {
            return GetRangeFull();
        }

        public IEnumerator<Product> DeserializeRangeGet(string value)
        {
            return JsonConvert.DeserializeObject<List<Product>>(value).GetEnumerator();
        }



        public Product DeserializeGet(string value)
        {
            return JsonConvert.DeserializeObject<Product>(value);
        }
    }
}
