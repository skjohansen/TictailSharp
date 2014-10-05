using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TictailSharp.Api.Implentation;
using TictailSharp.Api.Model;
using TictailSharp.Api.Repository;
using TictailSharp.Api.Test.TestImplementation;
using Xunit;

namespace TictailSharp.Api.Test
{
    public class ProductRepositoryTest : IProductRepository
    {
        #region Interface
        public IEnumerator<Product> GetEnumerator()
        {
            throw new NotImplementedException("No test needed");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public string StoreId { get; set; }

        public Product this[string index]
        {
            get { throw new NotImplementedException("No test needed"); }
        }

        public IEnumerator<Product> GetRange()
        {
            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"), "accesstoken_abcdefhiljklmnopqrstuvxuz");
            var clientTest = new TictailClientTest(endpointDummy);

            // Prepare store content
            clientTest.Content = "{" +
                        "\"id\": \"myStore\"," +
                      "}";

            var repository = new TictailRepository(clientTest);
            var store = repository.Stores["somestore"];

            // Prepare product content
            clientTest.Content = "[{" +
                        "\"id\": \"prod1\"" +
                        "},{"+
                        "\"id\": \"prod2\"" +
                    "}]";
            return store.Products.GetRange();
        }

        public IEnumerator<Product> DeserializeRangeGet(string value)
        {
            var repository = new ProductRepository(new TictailClientTest(), "abc");
            return repository.DeserializeRangeGet(value);
        }

        public Product Get(string idOrHref)
        {
            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"), "accesstoken_abcdefhiljklmnopqrstuvxuz");
            var clientTest = new TictailClientTest(endpointDummy);

            // Prepare store content
            clientTest.Content = "{" +
                        "\"id\": \"myStore\"," +
                      "}";

            var repository = new TictailRepository(clientTest);
            var store = repository.Stores["somestore"];

            // Prepare product content
            clientTest.Content = "{" +
                        "\"id\": \"" + idOrHref + "\"" +
                    "}";
            return store.Products.Get(idOrHref);
        }

        public Product DeserializeGet(string value)
        {
            var repository = new ProductRepository(new TictailClientTest(), "abc");
            return repository.DeserializeGet(value);
        }

        #endregion

        #region Test

        [Fact]
        public void Get_Ok_Product()
        {
            var customer = Get("1234");
            Assert.Equal("1234", customer.Id);
        }

        [Fact]
        public void GetRange_Ok_Product()
        {
            var products = GetRange();
            var productsList = Cast<Product>(products).ToList();
            Assert.Equal(2, productsList.Count);
            Assert.Equal("prod1", productsList[0].Id);
            Assert.Equal("prod2", productsList[1].Id);
        }

        [Fact]
        public void DeserializeGet_Ok_Product()
        {
            const string tictailJsonReponse = "{"+
                  "\"status\": \"published\", "+
                  "\"description\": \"Nice product<br>\", "+
                  "\"title\": \"Product1\", "+
                  "\"store_id\": \"ab1\", "+
                  "\"unlimited\": false, "+
                  "\"created_at\": \"2013-12-11T22:11:23\", "+
                  "\"modified_at\": \"2013-12-12T20:02:11\", "+
                  "\"slug\": \"prod1\", "+
                  "\"price\": 25000, "+
                  "\"currency\": \"SEK\", "+
                  "\"variations\": ["+
                    "{"+
                      "\"title\": null, "+
                      "\"modified_at\": \"2014-12-10T01:02:03\", "+
                      "\"created_at\": \"2014-12-11T11:12:13\", "+
                      "\"unlimited\": false, "+
                      "\"id\": \"12ab\", "+
                      "\"quantity\": 2"+
                    "}"+
                  "], "+
                  "\"images\": ["+
                    "{"+
                      "\"original_height\": 600, "+
                      "\"sizes\": {"+
                        "\"2000\": \"https://cdn.cloudfront.net/media/i/product/guid.jpeg?size=2000\", "+
                        "\"30\": \"https://cdn.cloudfront.net/media/i/product/guid.jpeg?size=30\", "+
                        "\"300\": \"https://cdn.cloudfront.net/media/i/product/guid.jpeg?size=300\", "+
                        "\"45\": \"https://cdn.cloudfront.net/media/i/product/guid.jpeg?size=45\", "+
                        "\"50\": \"https://cdn.cloudfront.net/media/i/product/guid.jpeg?size=50\", "+
                        "\"40\": \"https://cdn.cloudfront.net/media/i/product/guid.jpeg?size=40\", "+
                        "\"640\": \"https://cdn.cloudfront.net/media/i/product/guid.jpeg?size=640\", "+
                        "\"75\": \"https://cdn.cloudfront.net/media/i/product/guid.jpeg?size=75\", "+
                        "\"100\": \"https://cdn.cloudfront.net/media/i/product/guid.jpeg?size=100\", "+
                        "\"500\": \"https://cdn.cloudfront.net/media/i/product/guid.jpeg?size=500\", "+
                        "\"1000\": \"https://cdn.cloudfront.net/media/i/product/guid.jpeg?size=1000\""+
                      "}, "+
                      "\"url\": \"https://cdn.cloudfront.net/media/i/product/guid.jpeg\", "+
                      "\"created_at\": \"2014-01-04T13:14:15\", "+
                      "\"modified_at\": \"2014-02-05T16:17:18\", "+
                      "\"original_width\": 400, "+
                      "\"id\": \"bc45\""+
                    "}"+
                  "], "+
                  "\"id\": \"678a\", "+

                    "\"categories\": ["+
                        "{"+
                          "\"title\": \"Cat1\", "+
                          "\"created_at\": \"2014-01-02T03:04:05\", "+
                          "\"modified_at\": null, "+
                          "\"parent_id\": null, "+
                          "\"product_count\": 2, "+
                          "\"position\": 0, "+
                          "\"id\": \"abcd\""+
                        "}"+
                      "], "+
                  "\"quantity\": 2"+
            "}";

            var product = DeserializeGet(tictailJsonReponse);

            Assert.Equal("678a", product.Id);
            Assert.Equal("Product1", product.Title);
            Assert.Equal("Nice product<br>", product.Description);
            Assert.Equal("published", product.Status);
            Assert.Equal((uint)25000, product.Price);
            Assert.Equal("prod1", product.Slug);
            Assert.Equal(false, product.Unlimited);
            Assert.Equal((uint)2, product.Quantity);
            Assert.Equal(new DateTime(2013,12,11,22,11,23), product.CreatedAt);
            Assert.Equal(new DateTime(2013, 12, 12, 20, 2, 11), product.ModifiedAt);
            
            // Variation
            Assert.Equal(1, product.Variations.Count);
            Assert.Equal("12ab", product.Variations[0].Id);
            Assert.Equal(null, product.Variations[0].Title);
            Assert.Equal(false, product.Variations[0].Unlimited);
            Assert.Equal((uint)2, product.Variations[0].Quantity);
            Assert.Equal(new DateTime(2014,12,11,11,12,13), product.Variations[0].CreatedAt);
            Assert.Equal(new DateTime(2014,12,10,1,2,3), product.Variations[0].ModifiedAt);
            
            // Image
            Assert.Equal(1, product.Images.Count);
            Assert.Equal(11, product.Images[0].Sizes.Count);
            Assert.Equal("bc45", product.Images[0].Id);
            Assert.Equal(new DateTime(2014,1,4,13,14,15), product.Images[0].CreatedAt);
            Assert.Equal(new DateTime(2014,2,5,16,17,18), product.Images[0].ModifiedAt);
            Assert.Equal((uint)400, product.Images[0].OriginalWidth);
            Assert.Equal((uint)600, product.Images[0].OriginalHeight);


            // Categories
            Assert.Equal(1, product.Categories.Count);
            Assert.Equal("abcd", product.Categories[0].Id);
            Assert.Equal("Cat1", product.Categories[0].Title);
            Assert.Equal(null, product.Categories[0].ParentId);
            Assert.Equal(0, product.Categories[0].Position);
            Assert.Equal(new DateTime(2014,1,2,3,4,5), product.Categories[0].CreatedAt);
            Assert.False(product.Categories[0].ModifiedAt.HasValue);

        }

        [Fact]
        public void DeserializeRangeGet_Ok_Product()
        {
            const string tictailJsonReponse = "[{" +
                                              "\"status\": \"published\", " +
                                              "\"description\": \"Nice product<br>\", " +
                                              "\"title\": \"Product1\", " +
                                              "\"store_id\": \"ab1\"}," +
                                              "{" +
                                              "\"status\": \"unpublished\", " +
                                              "\"description\": \"Another Nice product<br>\", " +
                                              "\"title\": \"Product2\", " +
                                              "\"store_id\": \"ab2\"}" + "]";

            var product = DeserializeRangeGet(tictailJsonReponse);
            var products = Cast<Product>(product).ToList();

            Assert.Equal(2, products.Count);
            Assert.Equal("Product1", products[0].Title);
            Assert.Equal("Nice product<br>", products[0].Description);
            Assert.Equal("published", products[0].Status);
            Assert.Equal("Product2", products[1].Title);
        }

        #endregion

        IEnumerable<T> Cast<T>(IEnumerator iterator)
        {
            while (iterator.MoveNext())
            {
                yield return (T)iterator.Current;
            }
        }

    }
}
