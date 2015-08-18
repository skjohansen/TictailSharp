using System;
using System.Net;
using TictailSharp.Api.Implentation;
using TictailSharp.Api.Model;
using TictailSharp.Api.Model.Store;
using TictailSharp.Api.Resources;
using TictailSharp.Api.Test.TestImplementation;
using Xunit;

namespace TictailSharp.Api.Test
{
    public class StoreResourceTest : IStoreResource
    {
        #region interface
        public Store this[string index]
        {
            get { throw new Exception("No need to test"); }
        }

        public Store Get(string idOrHref)
        {
            const string tictailJsonReponse = "{" +
                                  "\"description\": \"Sells something<br>\"," +
                                  "}";


            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"), "accesstoken_abcdefhiljklmnopqrstuvxuz");
            var clientTest = new TictailClientTest(endpointDummy);
            clientTest.Content = tictailJsonReponse;

            var repository = new TictailRepository(clientTest);
            return repository.Stores.Get(idOrHref);
        }


        public Store DeserializeGet(string value)
        {
            var repository = new TictailRepository(new TictailClientTest());
            return repository.Stores.DeserializeGet(value);
        }
        public Store Patch(string resourceId, PatchStore resource)
        {
            const string tictailJsonReponse = "{" +
                      "\"description\": \"A new description\"," +
                      "}";


            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"), "accesstoken_abcdefhiljklmnopqrstuvxuz");
            var clientTest = new TictailClientTest(endpointDummy);
            clientTest.Content = tictailJsonReponse;

            var repository = new TictailRepository(clientTest);
            return repository.Stores.Patch(resourceId, resource);
        }
        #endregion

        #region Test

        [Fact]
        public void Get_Ok_Store()
        {
            var store = Get("abc");
            Assert.Equal("Sells something<br>", store.Description);
        }

        [Fact]
        public void DeserializeGet_Ok_Store()
        {
            const string tictailJsonReponse = "{" +
                                  "\"description\": \"Sells something<br>\"," +
                                  "\"language\": \"sv\"," +
                                  "\"url\": \"http://xxx.tictail.com\"," +
                                  "\"country\": \"SE\"," +
                                  "\"created_at\": \"1999-01-11T20:00:00\"," +
                                  "\"dashboard_url\": \"https://tictail.com/dashboard/store/xxx\"," +
                                  "\"modified_at\": \"1999-02-22T21:10:01\"," +
                                  "\"logotype\": null," +
                                  "\"currency\": \"SEK\"," +
                                  "\"sandbox\": true," +
                                  "\"contact_email\": \"yy@y.y\"," +
                                  "\"storekeeper_email\": \"xx@xx.x\"," +
                                  "\"followers\": 0," +
                                  "\"id\": \"abc\"," +
                                  "\"vat\": {" +
                                      "\"applied_to_shipping\": true," +
                                      "\"rate\": \"0.250000\"," +
                                      "\"region\": \"R_EU\"," +
                                      "\"included_in_prices\": true" +
                                  "}," +
                                  "\"name\": \"SomeName\"" +
                                  "}";

            var store = DeserializeGet(tictailJsonReponse);
            Assert.Equal("Sells something<br>", store.Description);
            Assert.Equal("sv", store.Language);
            Assert.Equal("http://xxx.tictail.com", store.Url);
            Assert.Equal("SE", store.Country);
            Assert.Equal(new DateTime(1999, 1, 11, 20, 0, 0), store.CreatedAt);
            Assert.Equal("https://tictail.com/dashboard/store/xxx", store.DashboardUrl);
            Assert.Equal(new DateTime(1999, 2, 22, 21, 10, 1), store.ModifiedAt);
            Assert.Equal(null, store.Logotypes);
            Assert.Equal("SEK", store.Currency);
            Assert.Equal(true, store.Sandbox);
            Assert.Equal("yy@y.y", store.ContactEmail);
            Assert.Equal("xx@xx.x", store.StorekeeperEmail);
            Assert.Equal(0, store.NumberOfFollowers);
            Assert.Equal("abc", store.Id);
            Assert.Equal("SomeName", store.Name);

            // VAT
            Assert.NotNull(store.Vat);
            Assert.Equal(true, store.Vat.AppliedToShipping);
            Assert.Equal(true, store.Vat.IncludedInPrices);
            Assert.Equal("R_EU", store.Vat.Region);
            Assert.Equal(0.25m, store.Vat.Rate);
        }

        /// <summary>
        /// Tests 404 - No Such Store
        /// </summary>
        [Fact]
        public void GetNoSuchStore_Store()
        {
            
            const string tictailJsonReponse = "{" +
                                              "\"status\": 404," +
                                              "\"message\": \"Not Found. You have requested this URI [/v1/stores/a123445] but did you mean /v1/stores/<id:store_id> or /v1/stores or /v1/stores/<id:store_id>/apps ?\", " +
                                              "\"params\": {}, " +
                                              "\"support_email\": \"developers@tictail.com\"" +
                                              "}";

            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"), "accesstoken_abcdefhiljklmnopqrstuvxuz");
            var clientTest = new TictailClientTest(endpointDummy);
            clientTest.Content = tictailJsonReponse;
            clientTest.StatusCode = HttpStatusCode.NotFound;
            var repository = new TictailRepository(clientTest);
            var ex = Assert.Throws<TictailException>(delegate { repository.Stores.Get("someWrongId"); });

            Assert.Equal("Not Found. You have requested this URI [/v1/stores/a123445] but did you mean /v1/stores/<id:store_id> or /v1/stores or /v1/stores/<id:store_id>/apps ?", ex.Message);
        }

        [Fact]
        public void PatchStoreDescription_Ok_PatchStoreWithJustDescription()
        {
            var ps = new PatchStore()
            {
                Description = "A new description"
            };

            var store = Patch("abc", ps);
            Assert.Equal(store.Description, ps.Description);

        }

        #endregion






    }
}
