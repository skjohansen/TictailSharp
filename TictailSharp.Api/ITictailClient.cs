using System.Net;
using RestSharp;

namespace TictailSharp.Api
{
    public interface ITictailClient
    {
        IRestResponse ExecuteRequest(IRestRequest request, HttpStatusCode expectedStatusCode);
    }
}
