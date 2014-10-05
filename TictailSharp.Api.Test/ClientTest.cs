using System;
using System.Net;
using RestSharp;
using TictailSharp.Api.Implentation;
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

            var ex = Assert.Throws<Exception>(delegate { clientTest.ExecuteRequest(request, HttpStatusCode.OK); });
            Assert.Equal("Forbidden access, check the API key", ex.Message);
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
            Assert.Equal("Unknown response, ResponseStatus: Error", ex.Message);
        }
    }
}
