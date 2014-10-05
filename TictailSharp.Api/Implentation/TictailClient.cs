using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace TictailSharp.Api.Implentation
{
    public class TictailClient : ITictailClient
    {
        private readonly TictailEndpoint _endpoint;
        public TictailClient(TictailEndpoint endpoint)
        {
            _endpoint = endpoint;
        }

        public IRestResponse ExecuteRequest(IRestRequest request, HttpStatusCode expectedStatusCode)
        {
            request.AddHeader("Authorization", "Bearer " + _endpoint.ApiKey);
            request.AddHeader("Content-Type", "application/json");

            var response = RestRequest(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Unknown response, ResponseStatus: " + response.ResponseStatus);
            }

            if (response.StatusCode == expectedStatusCode)
            {
                return response;
            }

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new Exception("Forbidden access, check the API key");
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException();
            }

            throw new Exception("Unknown error, Statuscode: " + response.StatusDescription);
        }

        protected virtual IRestResponse RestRequest(IRestRequest request)
        {
            var client = new RestClient(_endpoint.TictailServerUri.AbsoluteUri);
            return client.Execute(request);
        }
    }
}
