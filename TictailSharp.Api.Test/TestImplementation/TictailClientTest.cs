using System.Collections.Generic;
using System.Net;
using RestSharp;
using TictailSharp.Api.Implentation;

namespace TictailSharp.Api.Test.TestImplementation
{
    public class TictailClientTest : TictailClient
    {
        public TictailClientTest() : base(null)
        {
        }

        public TictailClientTest(TictailEndpoint endpoint)
            : base(endpoint)
        {
            StatusCode = HttpStatusCode.OK;
            ResponseStatus = ResponseStatus.Completed;
        }

        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
        public Dictionary<string, string> ResponseHeaders { get; set; }

        /// <summary>
        /// Override the method which does the actually call against the Tictail API using REST client
        /// These are both 3-party and should be working just fine
        /// </summary>
        /// <param name="request">RestRequst, is not needed for this</param>
        /// <returns>A RestResonse object</returns>
        protected override IRestResponse RestRequest(IRestRequest request)
        {
            IRestResponse response = new RestResponse();
            response.StatusCode = StatusCode;
            response.ResponseStatus = ResponseStatus;
            response.Content = Content;
            if (ResponseHeaders != null)
            {
                foreach (var header in ResponseHeaders)
                {
                    response.Headers.Add(new Parameter()
                    {
                        Name = header.Key,
                        Value = header.Value,
                        Type = ParameterType.HttpHeader
                    });

                }
            }

            return response;
        }
    }
}
