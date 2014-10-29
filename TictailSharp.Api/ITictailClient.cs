using System.Net;
using RestSharp;

namespace TictailSharp.Api
{
    /// <summary>
    /// Interface of TictailClient
    /// </summary>
    public interface ITictailClient
    {
        /// <summary>
        /// Execute a request to the Tictail API
        /// </summary>
        /// <param name="request">REST-Request against the API</param>
        /// <param name="expectedStatusCode">Expected HTTP statuscode, for successful request</param>
        /// <returns>REST-response from the API</returns>
        IRestResponse ExecuteRequest(IRestRequest request, HttpStatusCode expectedStatusCode);
    }
}
