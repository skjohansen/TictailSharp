using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TictailSharp.Api.Implentation;
using TictailSharp.Api.Model.Follower;
using TictailSharp.Api.Resources;
using TictailSharp.Api.Test.TestImplementation;
using Xunit;

namespace TictailSharp.Api.Test
{
    public class FollowerResourceTest : IFollowerResource
    {
        #region Interface
        public IEnumerator<Follower> GetEnumerator()
        {
            throw new NotImplementedException("No test is needed");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string StoreId { get; set; }
        public string Post(Follower value)
        {
            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"), "accesstoken_abcdefhiljklmnopqrstuvxuz");
            var clientTest = new TictailClientTest(endpointDummy);

            // Prepare store content
            clientTest.Content = "{" +
                        "\"id\": \"myStore\"," +
                      "}";

            var repository = new TictailRepository(clientTest);
            var store = repository.Stores["somestore"];
            clientTest.StatusCode = HttpStatusCode.Created;
            clientTest.Content = string.Empty;
            clientTest.ResponseHeaders = new Dictionary<string, string>();
            clientTest.ResponseHeaders.Add("Location","http://some.tictail/url/"+value.Email.Replace("@","").Replace(".",""));

            return store.Followers.Post(value);
        }

        public bool Delete(Follower value)
        {
            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"), "accesstoken_abcdefhiljklmnopqrstuvxuz");
            var clientTest = new TictailClientTest(endpointDummy);

            // Prepare store content
            clientTest.Content = "{" +
                        "\"id\": \"myStore\"," +
                      "}";

            var repository = new TictailRepository(clientTest);
            var store = repository.Stores["somestore"];
            clientTest.StatusCode = HttpStatusCode.NoContent;

            return store.Followers.Delete(value);
            
        }

        public IEnumerator<Follower> GetRange()
        {
            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"), "accesstoken_abcdefhiljklmnopqrstuvxuz");
            var clientTest = new TictailClientTest(endpointDummy);

            // Prepare store content
            clientTest.Content = "{" +
                        "\"id\": \"myStore\"," +
                      "}";

            var repository = new TictailRepository(clientTest);
            var store = repository.Stores["somestore"];

            // Prepare followers content
            clientTest.Content = "[{" +
                        "\"id\": \"prod1\"" +
                        "},{" +
                        "\"id\": \"prod2\"" +
                    "}]";
            return store.Followers.GetRange();
        }

        public IEnumerator<Follower> DeserializeRangeGet(string value)
        {
            var repository = new FollowerResource(new TictailClientTest(), "abc");
            return repository.DeserializeRangeGet(value);
        }
        #endregion 

        #region Test

        [Fact]
        public void GetRange_Ok_Follower()
        {
            var followers = GetRange();
            var followersList = Cast<Follower>(followers).ToList();
            Assert.Equal(2, followersList.Count);
            Assert.Equal("prod1", followersList[0].Id);
            Assert.Equal("prod2", followersList[1].Id);
        }

        [Fact]
        public void Post_Ok_Follower()
        {
            var newFollower = new Follower()
            {
                Email = "some@email.com"
            };
            string location = Post(newFollower);
            Assert.Equal("http://some.tictail/url/someemailcom", location);
        }

        [Fact]
        public void Delete_Ok_Follower()
        {
            // Prepare followers content
            var toDelete = new Follower()
            {
                CreatedAt = new DateTime(2014, 8, 1),
                Email = "some@email.com",
                Id = "ID1"
            };
            var isDeleted = Delete(toDelete);
            Assert.Equal(true, isDeleted);
        }


        [Fact]
        public void DeserializeRangeGet_Ok_Follower()
        {
            const string tictailJsonReponse = "[" +
                                                  "{" +
                                                      "\"created_at\": \"2014-06-01T21:00:00\"," +
                                                      "\"modified_at\": null, " +
                                                      "\"email\": \"test@test.com\", " +
                                                      "\"id\": \"123a\"" +
                                                  "}" +
                                              "]";

            var followerRange = DeserializeRangeGet(tictailJsonReponse);

            var followers = Cast<Follower>(followerRange).ToList();
            Assert.Equal(1, followers.Count);
            // Customer, element 0
            Assert.Equal("123a", followers[0].Id);
            Assert.Equal("test@test.com", followers[0].Email);
            Assert.Equal(new DateTime(2014,6,1,21,0,0), followers[0].CreatedAt);
            Assert.False(followers[0].ModifiedAt.HasValue);
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
