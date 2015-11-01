using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TictailSharp.Api.Model.Product;
using TictailSharp.Api.Model.Store;

namespace TictailSharp.Api.Resources
{
    /// <summary>
    /// Product repository
    /// </summary>
    public class ProductResource : IProductResource
    {
        private readonly ITictailClient _client;

        /// <summary>
        /// Construct Product repositiory
        /// </summary>
        /// <param name="client">Tictail client</param>
        /// <param name="storeId">ID of Tictail store to retrive Product from</param>
        public ProductResource(ITictailClient client, string storeId)
        {
            _client = client;
            StoreId = storeId;
        }

        /// <summary>
        /// Get a Product from Tictail API
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
                var content = _client.ExecuteRequest(request, HttpStatusCode.OK).Content;
                return DeserializeGet(content);
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("No Product found with ID : " + productId + ", at store : " + StoreId);
            }
        }

        /// <summary>
        /// Get all product, or a specific range
        /// </summary>
        /// <param name="after">Only get products after this product_id. Defaults to the first product.</param>
        /// <param name="before">Only get products before this product_id</param>
        /// <param name="limit">Limit number of products returned (default 100)</param>
        /// <param name="categories">List of category ids</param>
        /// <returns>An enumerator of products</returns>
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
            catch (KeyNotFoundException)
            {
                //TODO: Can there also be an error if wrong afterProductId, beforeProductId, limit ??
                throw new Exception("No Store found with ID : " + StoreId);
            }

        }
        
        /// <summary>
        /// Get enumerator of all Products
        /// </summary>
        /// <returns>An enumerator of Products</returns>
        public IEnumerator<Product> GetEnumerator()
        {
            return GetRangeFull(10000U);
        }

        /// <summary>
        /// Get enumerator of all products
        /// </summary>
        /// <returns>An enumerator of products</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>An enumerator of products</returns>
        public IEnumerator<Product> GetRange()
        {
            return GetRangeFull();
        }

        /// <summary>
        /// Get a Product from Tictail API
        /// </summary>
        /// <param name="productId">ID of the product</param>
        /// <returns>A specific product</returns>
        public Product this[string productId]
        {
            get { return Get(productId); }
        }

        /// <summary>
        /// ID of store to fetch Product from
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        /// Deserlize array of products
        /// </summary>
        /// <param name="data">JSON array of Products</param>
        /// <returns>An enumerator of Products</returns>
        public IEnumerator<Product> DeserializeRangeGet(string data)
        {
            return JsonConvert.DeserializeObject<List<Product>>(data).GetEnumerator();
        }

        /// <summary>
        /// Deserlize a Product
        /// </summary>
        /// <param name="data">JSON of a Product</param>
        /// <returns>A Product</returns>
        public Product DeserializeGet(string data)
        {
            return JsonConvert.DeserializeObject<Product>(data);
        }

        /// <summary>
        /// Update the position of a product (product_ids). Use PATCH to update the properties of a product
        /// </summary>
        /// <param name="product"></param>
        public void Put(Product product)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add a new product to this store (store_id)
        /// </summary>
        /// <param name="product">Product to be added to store</param>
        /// <returns></returns>
        public Product Post(PostProduct product)
        {
            if (string.IsNullOrEmpty(StoreId))
            {
                throw new Exception("You can't specify an empty storeId");
            }

            var request = new RestRequest("v1/stores/{storeId}/products", Method.POST);
            request.AddUrlSegment("storeId", StoreId);
            request.RequestFormat = DataFormat.Json;
            
            var serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            string bodyContent;
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, product);
                bodyContent = writer.ToString();
            }

            request.AddParameter("application/json", bodyContent, ParameterType.RequestBody);

            Product createdProduct;
            try
            {
                createdProduct = DeserializeGet(_client.ExecuteRequest(request, HttpStatusCode.Created).Content);
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("No Store found with ID : " + StoreId);
            }

            return createdProduct;
        }

        /// <summary>
        /// Update a product (product_ids) in this store (store_id). Supports partial updates, where values not specified in the request body are not overwritten.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public Product Patch(string productId, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
