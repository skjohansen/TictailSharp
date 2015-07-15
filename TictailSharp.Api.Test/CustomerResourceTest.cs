using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TictailSharp.Api.Implentation;
using TictailSharp.Api.Model;
using TictailSharp.Api.Model.Customer;
using TictailSharp.Api.Resources;
using TictailSharp.Api.Test.TestImplementation;
using Xunit;

namespace TictailSharp.Api.Test
{
    public class CustomerResourceTest : ICustomerResource
    {
        #region Interface

        public IEnumerator<Customer> GetEnumerator()
        {
            throw new NotImplementedException("No test needed");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Customer Get(string id)
        {
            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"), "accesstoken_abcdefhiljklmnopqrstuvxuz");
            var clientTest = new TictailClientTest(endpointDummy);

            // Prepare store content
            clientTest.Content = "{" +
                        "\"id\": \"myStore\"," +
                      "}";

            var repository = new TictailRepository(clientTest);
            var store = repository.Stores["somestore"];

            // Prepare customer content
            clientTest.Content = "{" +
                        "\"id\": \""+id+"\"" +
                    "}";
            return store.Customers.Get(id);
        }

        public Customer DeserializeGet(string value)
        {
            var repository = new CustomerResource(new TictailClientTest(), "abc");
            return repository.DeserializeGet(value);
        }

        public string StoreId { get; set; }

        public Customer this[string index]
        {
            get { throw new NotImplementedException("No test needed"); }
        }

        public IEnumerator<Customer> GetRange()
        {
            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"), "accesstoken_abcdefhiljklmnopqrstuvxuz");
            var clientTest = new TictailClientTest(endpointDummy);

            // Prepare store content
            clientTest.Content = "{" +
                        "\"id\": \"myStore\"," +
                      "}";

            var repository = new TictailRepository(clientTest);
            var store = repository.Stores["somestore"];

            // Prepare customer content
            clientTest.Content = "[" +
                    "{" +
                        "\"id\": \"1234\"" +
                    "}" +
                "]";
            return store.Customers.GetRange();
        }

        public IEnumerator<Customer> DeserializeRangeGet(string value)
        {
            var repository = new CustomerResource(new TictailClientTest(), "abc");
            return repository.DeserializeRangeGet(value);
        }
        #endregion

        #region Test

        [Fact]
        public void GetRange_Ok_Customer()
        {
            var customerRange = GetRange();
            var customers = Cast<Customer>(customerRange).ToList();
            Assert.Equal(1, customers.Count);
            Assert.Equal("1234", customers[0].Id);
        }


        [Fact]
        public void Get_Ok_Customer_Specific()
        {
            var customer = Get("1234");
            Assert.Equal("1234", customer.Id);
        }

        [Fact]
        public void DeserializeGet_Ok_Customer()
        {
            const string tictailJsonReponse = 
                "{" +
                    "\"id\": \"i3r4t5\"," +
                    "\"email\": \"xx@email.com\"," +
                    "\"name\": \"Some Random Name\"," +
                    "\"country\": \"SE\"," +
                    "\"language\": \"SV\"," +
                    "\"created_at\": \"1999-01-11T20:00:00\"," +
                    "\"modified_at\": \"1999-02-22T21:10:01\"," +
                "}";


            var customer = DeserializeGet(tictailJsonReponse);
            

            Assert.Equal("i3r4t5", customer.Id);
            Assert.Equal("xx@email.com", customer.Email);
            Assert.Equal("Some Random Name", customer.Name);
            Assert.Equal("SE", customer.Country);
            Assert.Equal("SV", customer.Language);
            Assert.Equal(new DateTime(1999, 1, 11, 20, 0, 0), customer.CreatedAt);
            Assert.Equal(new DateTime(1999, 2, 22, 21, 10, 1), customer.ModifiedAt);
        }

        [Fact]
        public void DeserializeRangeGet_Ok_Customers()
        {
            const string tictailJsonReponse = "[" + 
                    "{" +
                        "\"id\": \"i3r4t5\"," +
                        "\"email\": \"xx@email.com\"," +
                        "\"name\": \"Some Random Name\"," +
                        "\"country\": \"SE\"," +
                        "\"language\": \"SV\"," +
                        "\"created_at\": \"1999-01-11T20:00:00\"," +
                        "\"modified_at\": \"1999-02-22T21:10:01\"," +
                    "}," +
                   "{" +
                        "\"id\": \"5t6y7u\"," +
                        "\"email\": \"email@xx.com\"," +
                        "\"name\": \"Another Random Name\"," +
                        "\"country\": \"DK\"," +
                        "\"language\": \"DA\"," +
                        "\"created_at\": \"2000-02-12T21:01:02\"," +
                        "\"modified_at\": \"2003-03-04T02:02:11\"," +
                    "}" +
                "]";


            var customersResponse = DeserializeRangeGet(tictailJsonReponse);
            var customers = Cast<Customer>(customersResponse).ToList();
            Assert.Equal(2, customers.Count);
            // Customer, element 0
            Assert.Equal("i3r4t5", customers[0].Id);
            Assert.Equal("xx@email.com", customers[0].Email);
            Assert.Equal("Some Random Name", customers[0].Name);
            Assert.Equal("SE", customers[0].Country);
            Assert.Equal("SV", customers[0].Language);
            Assert.Equal(new DateTime(1999,1,11,20,0,0), customers[0].CreatedAt);
            Assert.Equal(new DateTime(1999,2,22,21,10,1), customers[0].ModifiedAt);
            // Customer, element 1
            Assert.Equal("5t6y7u", customers[1].Id);
            Assert.Equal("email@xx.com", customers[1].Email);
            Assert.Equal("Another Random Name", customers[1].Name);
            Assert.Equal("DK", customers[1].Country);
            Assert.Equal("DA", customers[1].Language);
            Assert.Equal(new DateTime(2000, 2, 12, 21, 1, 2), customers[1].CreatedAt);
            Assert.Equal(new DateTime(2003, 3, 4, 2, 2, 11), customers[1].ModifiedAt);

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
