using System;
using System.Net;
using TictailSharp.Api.Implentation;
using TictailSharp.Api.Model;
using TictailSharp.Api.Model.Theme;
using TictailSharp.Api.Resources;
using TictailSharp.Api.Test.TestImplementation;
using Xunit;

namespace TictailSharp.Api.Test
{
    public class ThemeResourceTest : IThemeResource
    {
        
        #region Interface
        public Theme Get()
        {
            const string tictailStoreJsonReponse = "{" +
                      "\"id\": \"myStore\"," +
                      "}";
            const string tictailThemeJsonReponse = "{" +
                                  "\"id\": \"myTheme\"," +
                                  "}";

            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"), "accesstoken_abcdefhiljklmnopqrstuvxuz");
            var clientTest = new TictailClientTest(endpointDummy);
            clientTest.Content = tictailStoreJsonReponse;

            var repository = new TictailRepository(clientTest);
            var store = repository.Stores["somestore"];
            clientTest.Content = tictailThemeJsonReponse;
            return store.Theme.Get();
        }


        public Theme DeserializeGet(string value)
        {
            var repository = new ThemeResource(new TictailClientTest(), "abc");
            return repository.DeserializeGet(value);
        }
        #endregion
        
        #region Tests

        [Fact]
        public void Get_Ok_Theme()
        {
            var theme = Get();
            Assert.Equal("myTheme", theme.Id);
        }

        [Fact]
        public void DeserializeGet_Ok_Theme()
        {
            const string tictailJsonReponse = "{" +
                      "\"markup\": \"<!DOCTYPE html>\\n<html lang=\\\"en\\\"> </html>\", "+
                      "\"id\": \"eee\""+
                      "}";

            var theme = DeserializeGet(tictailJsonReponse);
            Assert.Equal("eee", theme.Id);
            Assert.Equal("<!DOCTYPE html>\n<html lang=\"en\"> </html>", theme.Markup);
        }

        /// <summary>
        /// 404 - Theme Not Found in store
        /// </summary>
        [Fact]
        public void GetStoreNotFound_Theme()
        {
            const string tictailJsonReponse = "{" +
                                  "\"status\": 404," +
                                  "\"message\": \"Not Found. You have requested this URI [/v1/stores/aaa/theme] but did you mean /v1/stores/<id:store_id>/theme or /v1/stores/<id:store_id>/orders or /v1/stores/<id:store_id>/customers ?\", " +
                                  "\"params\": {}, " +
                                  "\"support_email\": \"developers@tictail.com\"" +
                                  "}";

            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"), "accesstoken_abcdefhiljklmnopqrstuvxuz");
            var clientTest = new TictailClientTest(endpointDummy);
            clientTest.Content = tictailJsonReponse;
            clientTest.StatusCode = HttpStatusCode.NotFound;
            var repository = new TictailRepository(clientTest);
            var ex = Assert.Throws<TictailException>(delegate { repository.Stores.Get("someWrongId"); });

            Assert.Equal("Not Found. You have requested this URI [/v1/stores/aaa/theme] but did you mean /v1/stores/<id:store_id>/theme or /v1/stores/<id:store_id>/orders or /v1/stores/<id:store_id>/customers ?", ex.Message);
        }
        #endregion
        


    }
}
