using System;
using System.Net;
using RestSharp;
using TictailSharp.Api.Model;
using TictailSharp.Api.Repository;
using TictailSharp.Api.Test.TestImplementation;
using Xunit;

namespace TictailSharp.Api.Test
{
    public class OauthRepositoryTest : IOauthRespository 
    {
        /// <summary>
        /// All is OK : used by Post_ValidAuthCode_AccessToken
        /// </summary>
        /// <param name="oauth">The oauth data going in</param>
        /// <returns>A token</returns>
        public Token Post(Oauth oauth)
        {
            const string tictailJsonReponse = "{" +
                                                  "\"access_token\": \"accesstoken_xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx\"," +
                                                  "\"token_type\": \"Bearer\"," +
                                                  "\"expires_in\": 3155760000," +
                                                  "\"store\": {" +
                                                      "\"id\": \"ab1\"," +
                                                      "\"name\": \"Some example store\"," +
                                                      "\"language\": \"en\"," +
                                                      "\"url\": \"http://example.tictail.com\"," +
                                                      "\"storekeeper_email\": \"random@email.com\"," +
                                                      "\"created_at\": \"1999-02-12T20:10:20\"," +
                                                      "\"modified_at\": null" +
                                                  "}" +
                                              "}";

            var testClient = new TictailClientTest
            {
                Content = tictailJsonReponse,
                ResponseStatus = ResponseStatus.Completed,
                StatusCode = HttpStatusCode.OK
            };

            var sut = new OauthRepository(testClient);
            return sut.Post(oauth);
        }

        [Fact]
        public void DeserializeGet_ValidTokenJson_Token()
        {
            const string accessJson = "{" +
                                          "\"access_token\": \"accesstoken_abcdef123456\", "+
                                          "\"token_type\": \"Bearer\", "+
                                          "\"expires_in\": 123450000, "+
                                          "\"store\": {"+
                                            "\"description\": \"Some description\", "+
                                            "\"language\": \"en\", "+
                                            "\"url\": \"http://some.tictail.com\", "+
                                            "\"country\": \"SE\", "+
                                            "\"created_at\": \"2013-01-02T10:15:18\", "+
                                            "\"dashboard_url\": \"https://tictail.com/dashboard/store/somedashboard\", "+
                                            "\"modified_at\": null, "+
                                            "\"logotype\": null, "+
                                            "\"appstore_currency\": \"SEK\", "+
                                            "\"currency\": \"SEK\", "+
                                            "\"sandbox\": true, "+
                                            "\"contact_email\": \"\", "+
                                            "\"storekeeper_email\": \"some@email.com\", "+
                                            "\"short_description\": null, "+
                                            "\"followers\": 0, "+
                                            "\"name\": \"A random name\", "+
                                            "\"id\": \"ab1\", "+
                                            "\"vat\": {"+
                                                "\"applied_to_shipping\": true, "+
                                                "\"rate\": \"0.250000\", "+
                                                "\"region\": \"SE\", "+
                                                "\"included_in_prices\": true"+
                                            "},"+
                                            "\"wallpapers\": {}"+
                                        "}"+
                                    "}";
            var sut = new OauthRepository(new TictailClientTest());

            var token = sut.DeserializeGet(accessJson);
            Assert.Equal("accesstoken_abcdef123456", token.AccessToken);
            Assert.Equal("Bearer", token.TokenType);
            Assert.Equal(123450000, token.ExpiresIn);
            Assert.NotNull(token.Store);
            Assert.Equal("Some description", token.Store.Description);
            Assert.Equal("en", token.Store.Language);
            Assert.Equal("http://some.tictail.com", token.Store.Url);
            Assert.Equal("SE", token.Store.Country);
            Assert.Equal(new DateTime(2013,1,2,10,15,18), token.Store.CreatedAt);
            Assert.Equal("https://tictail.com/dashboard/store/somedashboard", token.Store.DashboardUrl);
            Assert.Null(token.Store.ModifiedAt);
            Assert.Null(token.Store.Logotypes);
            Assert.Equal("SEK", token.Store.AppstoreCurrency);
            Assert.Equal("SEK", token.Store.Currency);
            Assert.True(token.Store.Sandbox);
            Assert.Equal("", token.Store.ContactEmail);
            Assert.Equal("some@email.com", token.Store.StorekeeperEmail);
            Assert.Null(token.Store.ShortDescription);
            Assert.Equal(0, token.Store.NumberOfFollowers);
            Assert.Equal("A random name", token.Store.Name);
            Assert.Equal("ab1", token.Store.Id);
            //TODO: Wallpapers
            Assert.NotNull(token.Store.Vat);
            Assert.True(token.Store.Vat.AppliedToShipping);
            Assert.Equal(0.25m, token.Store.Vat.Rate);
            Assert.Equal("SE", token.Store.Vat.Region);
            Assert.True(token.Store.Vat.IncludedInPrices);
        }

        [Fact]
        public void Post_ValidAuthCode_AccessToken()
        {
            var oauth = new Oauth
            {
                AuthCode = "authcode_abcdefghijklmnop123456",
                ClientId = "clientid_ABCDEFGHIJKLM9876543",
                ClientSecret = "clientsecret_123456789abcdefghij"
            };

            var token = Post(oauth);


            Assert.Equal("accesstoken_xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", token.AccessToken);
            Assert.Equal("Bearer", token.TokenType);
            Assert.Equal(3155760000, token.ExpiresIn);
            Assert.NotNull(token.Store);
        }

        [Fact]
        public void Post_UnvalidAuthCode_TictailException()
        {
            var oauth = new Oauth
            {
                AuthCode = "authcode_BAD",
                ClientId = "clientid_ABCDEFGHIJKLM9876543",
                ClientSecret = "clientsecret_123456789abcdefghij"
            };

            const string tictailJsonReponse = "{" +
                                                  "\"status\": 400, " +
                                                  "\"message\": \"Invalid authorization code given\"," +
                                                  "\"params\": {}, " +
                                                  "\"support_email\": \"some@email2.com\"" +
                                              "}";

            var testClient = new TictailClientTest
            {
                Content = tictailJsonReponse,
                ResponseStatus = ResponseStatus.Completed,
                StatusCode = HttpStatusCode.BadRequest
            };

            var sut = new OauthRepository(testClient);

            var tictailException = Assert.Throws<TictailException>(() => sut.Post(oauth));
            Assert.Equal(400, tictailException.Status);
            Assert.Equal("Invalid authorization code given", tictailException.Message);
            Assert.Equal("some@email2.com", tictailException.SupportEmail);

        }

    }
}
