using System;
using TictailSharp.Api.Implentation;
using TictailSharp.Api.Model.Me;
using TictailSharp.Api.Resources;
using TictailSharp.Api.Test.TestImplementation;
using Xunit;

namespace TictailSharp.Api.Test
{
    public class MeResource : IMeResource
    {
        #region Interface
        public Me Get()
        {
            const string tictailJsonReponse = "{" +
                                              "\"description\": \"Sells something<br>\"," +
                                              "}";

            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"), "accesstoken_abcdefhiljklmnopqrstuvxuz");
            var clientTest = new TictailClientTest(endpointDummy);
            clientTest.Content = tictailJsonReponse;

            var repository = new TictailRepository(clientTest);
            return repository.Me.Get();
        }


        public Me DeserializeGet(string value)
        {
            var repository = new TictailRepository(new TictailClientTest());
            return repository.Me.DeserializeGet(value);
        }
        #endregion

        #region Tests
        [Fact]
        public void Get_Ok_Me()
        {
            var me = Get();
            Assert.Equal("Sells something<br>", me.Description);
        }

        [Fact]
        public void DeserializeGet_Ok_Me()
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


            var me = DeserializeGet(tictailJsonReponse);
            Assert.Equal("Sells something<br>", me.Description);
            Assert.Equal("sv", me.Language);
            Assert.Equal("http://xxx.tictail.com", me.Url);
            Assert.Equal("SE", me.Country);
            Assert.Equal(new DateTime(1999, 1, 11, 20, 0, 0), me.CreatedAt);
            Assert.Equal("https://tictail.com/dashboard/store/xxx", me.DashboardUrl);
            Assert.Equal(new DateTime(1999, 2, 22, 21, 10, 1), me.ModifiedAt);
            Assert.Equal(null, me.Logotypes);
            Assert.Equal("SEK", me.Currency);
            Assert.Equal(true, me.Sandbox);
            Assert.Equal("yy@y.y", me.ContactEmail);
            Assert.Equal("xx@xx.x", me.StorekeeperEmail);
            Assert.Equal(0, me.NumberOfFollowers);
            Assert.Equal("abc", me.Id);
            Assert.Equal("SomeName", me.Name);

            // VAT
            Assert.NotNull(me.Vat);
            Assert.Equal(true, me.Vat.AppliedToShipping);
            Assert.Equal(true, me.Vat.IncludedInPrices);
            Assert.Equal("R_EU", me.Vat.Region);
            Assert.Equal(0.25m, me.Vat.Rate);
        }

        #endregion


    }
}
