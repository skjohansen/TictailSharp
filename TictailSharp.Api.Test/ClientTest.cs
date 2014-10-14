using System;
using System.Net;
using RestSharp;
using TictailSharp.Api.Implentation;
using TictailSharp.Api.Model;
using TictailSharp.Api.Test.TestImplementation;
using Xunit;

namespace TictailSharp.Api.Test
{
    public class ClientTest
    {
        [Fact]
        public void WrongAccessToken()
        {
            const string tictailJsonReponse = "{" +
              "\"status\": 403, " +
              "\"message\": \"Forbidden\", " +
              "\"params\": {}, " +
              "\"support_email\": \"developers@tictail.com\"" +
            "}";


            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"), "accesstoken_a");
            var clientTest = new TictailClientTest(endpointDummy);

            IRestRequest request = new RestRequest("v1/me", Method.GET);
            clientTest.Content = tictailJsonReponse;
            clientTest.StatusCode = HttpStatusCode.Forbidden;

            var tictailException = Assert.Throws<TictailException>(delegate { clientTest.ExecuteRequest(request, HttpStatusCode.OK); });
            Assert.Equal("Forbidden access, check the API key", tictailException.CustomMessage);
            Assert.Equal("Forbidden", tictailException.Message);
            Assert.Equal(403, tictailException.Status);
            Assert.Equal("developers@tictail.com", tictailException.SupportEmail);
        }

        [Fact]
        public void WrongAccessCode()
        {
            const string tictailJsonReponse = "{" +
                                                  "\"status\": 400, " +
                                                  "\"message\": \"Invalid authorization code given\"," +
                                                  "\"params\": {}, " +
                                                  "\"support_email\": \"some@email2.com\"" +
                                              "}";


            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"));
            var clientTest = new TictailClientTest(endpointDummy);

            IRestRequest request = new RestRequest("oauth/token", Method.POST);
            clientTest.Content = tictailJsonReponse;
            clientTest.StatusCode = HttpStatusCode.BadRequest;

            var tictailException = Assert.Throws<TictailException>(delegate { clientTest.ExecuteRequest(request, HttpStatusCode.OK); });
            Assert.Equal("No access, check your authcode, has it allready been used?", tictailException.CustomMessage);
            Assert.Equal("Invalid authorization code given", tictailException.Message);
            Assert.Equal(400, tictailException.Status);
            Assert.Equal("some@email2.com", tictailException.SupportEmail);
        }

        [Fact]
        public void RessouceNotFound()
        {
            const string tictailJsonReponse = "{" +
                                                  "\"status\": 404, " +
                                                  "\"message\": \"Not Found. You have requested this URI [/v1/stores/AAA] but did you mean /v1/stores/<id:store_id> or /v1/stores or /v1/stores/<id:store_id>/theme ?\"," +
                                                  "\"params\": {}, " +
                                                  "\"support_email\": \"some@email3.com\"" +
                                              "}";


            var endpointDummy = new TictailEndpoint(new Uri("https://api.somewhere.com"));
            var clientTest = new TictailClientTest(endpointDummy);

            IRestRequest request = new RestRequest("v1/stores/AAA", Method.GET);
            clientTest.Content = tictailJsonReponse;
            clientTest.StatusCode = HttpStatusCode.NotFound;

            var tictailException = Assert.Throws<TictailException>(delegate { clientTest.ExecuteRequest(request, HttpStatusCode.OK); });
            Assert.Equal("Does the ressouce exist?", tictailException.CustomMessage);
            Assert.Equal("Not Found. You have requested this URI [/v1/stores/AAA] but did you mean /v1/stores/<id:store_id> or /v1/stores or /v1/stores/<id:store_id>/theme ?", tictailException.Message);
            Assert.Equal(404, tictailException.Status);
            Assert.Equal("some@email3.com", tictailException.SupportEmail);
        }

        [Fact]
        public void WrongUrl()
        {
            var endpointDummy = new TictailEndpoint(new Uri("https://wrongdomain.com"), "accesstoken_a");
            var clientTest = new TictailClientTest(endpointDummy);
            clientTest.ResponseStatus = ResponseStatus.Error;
            clientTest.StatusCode = HttpStatusCode.Unauthorized;

            IRestRequest request = new RestRequest("v1/me", Method.GET);

            var ex = Assert.Throws<Exception>(delegate { clientTest.ExecuteRequest(request, HttpStatusCode.OK); });
            Assert.Equal("Unknown status, ResponseStatus: Error", ex.Message);
        }
    }
}
