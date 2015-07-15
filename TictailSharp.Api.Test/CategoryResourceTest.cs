using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TictailSharp.Api.Implentation;
using TictailSharp.Api.Model.Category;
using TictailSharp.Api.Resources;
using TictailSharp.Api.Test.TestImplementation;
using Xunit;

namespace TictailSharp.Api.Test
{
    public class CategoryResourceTest : ICategoryResource
    {
        #region Interface
        public string StoreId
        {
            get
            {
                throw new NotImplementedException("No test needed");
            }
            set
            {
                throw new NotImplementedException("No test needed");
            }
        }

        public IEnumerator<Category> Get()
        {
            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"), "accesstoken_abcdefhiljklmnopqrstuvxuz");
            var clientTest = new TictailClientTest(endpointDummy);

            // Prepare store content
            clientTest.Content = "{" +
                        "\"id\": \"myStore\"," +
                      "}";

            var repository = new TictailRepository(clientTest);
            var store = repository.Stores["somestore"];
            
            // Prepare category content
            clientTest.Content = "[" +
                    "{" +
                        "\"id\": \"1234\"" +
                    "}" +
                "]";
            return store.Categories.GetRange();


        }

        public IEnumerator<Category> GetEnumerator()
        {
            throw new NotImplementedException("No test needed");
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException("No test needed");
        }

        public IEnumerator<Category> DeserializeGet(string value)
        {
            var repository = new CategoryResource(new TictailClientTest(), "abc");
            return repository.DeserializeRangeGet(value);
        }

        public IEnumerator<Category> GetRange()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Category> DeserializeRangeGet(string value)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Test
        [Fact]
        public void Get_Ok_Category()
        {
            var category = Get();
            var categories = Cast<Category>(category).ToList();
            Assert.Equal(1, categories.Count);
            Assert.Equal("1234", categories[0].Id);
        }

        [Fact]
        public void DeserializeGet_Ok_Category()
        {
            const string tictailJsonReponse = "[" +
                "{" +
                    "\"title\": \"SomeCategory\", " +
                    "\"created_at\": \"2014-02-02T15:01:02\", " +
                    "\"modified_at\": null, " +
                    "\"parent_id\": null, " +
                    "\"position\": 0, " +
                    "\"id\": \"1234\"" +
                "}," +
                "{" +
                    "\"title\": \"SomeOtherCategory\", " +
                    "\"created_at\": \"2014-03-03T03:04:05\", " +
                    "\"modified_at\": \"2014-04-04T04:05:06\", " +
                    "\"parent_id\": \"1234\", " +
                    "\"position\": 1, " +
                    "\"id\": \"2345\"" +
                "}" +
            "]";



            var category = DeserializeGet(tictailJsonReponse);
            var categories = Cast<Category>(category).ToList();
            Assert.Equal(2, categories.Count());

            var cat0 = categories.ElementAt(0);
            Assert.Equal("SomeCategory", cat0.Title);
            Assert.Equal(0, cat0.Position);
            Assert.Equal("1234", cat0.Id);
            Assert.Equal(null, cat0.ModifiedAt);
            Assert.Equal(null, cat0.ParentId);
            Assert.Equal(new DateTime(2014,2,2,15,1,2), cat0.CreatedAt);

            var cat1 = categories.ElementAt(1);
            Assert.Equal("SomeOtherCategory", cat1.Title);
            Assert.Equal(1, cat1.Position);
            Assert.Equal("2345", cat1.Id);
            Assert.Equal(new DateTime(2014, 4, 4, 4, 5, 6), cat1.ModifiedAt);
            Assert.Equal("1234", cat1.ParentId);
            Assert.Equal(new DateTime(2014, 3, 3, 3, 4, 5), cat1.CreatedAt);
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
