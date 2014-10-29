using RestSharp;
using System;
using System.Net;
using TictailSharp.Api.Model;

namespace TictailSharp.Api.Implentation
{
    /// <summary>
    /// Client used to communicate with the Tictail API
    /// </summary>
    public class TictailClient : ITictailClient
    {
        private readonly TictailEndpoint _endpoint;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="endpoint">Endpoint of the api</param>
        public TictailClient(TictailEndpoint endpoint)
        {
            _endpoint = endpoint;
        }

        /// <summary>
        /// Execute a request against the api endpoint
        /// </summary>
        /// <param name="request">REST request</param>
        /// <param name="expectedStatusCode">Expected HTTPS statuscode for success</param>
        /// <returns>REST response</returns>
        public IRestResponse ExecuteRequest(IRestRequest request, HttpStatusCode expectedStatusCode)
        {
            if (_endpoint != null && !string.IsNullOrEmpty(_endpoint.AccessToken))
            {
                request.AddHeader("Authorization", "Bearer " + _endpoint.AccessToken);
            }
            request.AddHeader("Content-Type", "application/json");

            var response = RestRequest(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Unknown status, ResponseStatus: " + response.ResponseStatus);
            }

            if (response.StatusCode == expectedStatusCode)
            {
                return response;
            }

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new TictailException(response.Content, "Forbidden access, check the API key");
            }

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new TictailException(response.Content, "No access, check your authcode, has it allready been used?");
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new TictailException(response.Content, "Does the ressouce exist?");
            }

            throw new Exception("Unknown error, Statuscode: " + response.StatusDescription);
        }

        /// <summary>
        /// Perform the raw request against the API
        /// </summary>
        /// <param name="request">The REST request to perform</param>
        /// <returns>A REST repsonse</returns>
        protected virtual IRestResponse RestRequest(IRestRequest request)
        {
            var client = new RestClient(_endpoint.TictailServerUri.AbsoluteUri);
            return client.Execute(request);
        }
    }
}
