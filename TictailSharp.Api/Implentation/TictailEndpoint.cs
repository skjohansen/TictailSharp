using System;

namespace TictailSharp.Api.Implentation
{
    public class TictailEndpoint
    {
        private readonly Uri _tictailServer;
        private readonly string _apiKey;

        // Support of OAuth
        // https://tictail.com/developers/documentation/authentication/#External_Apps   

        public TictailEndpoint(Uri url, string apikey)
        {
            _apiKey = apikey;
            _tictailServer = url;
           
        }

        public string ApiKey { get { return _apiKey; } }
        public Uri TictailServerUri {get { return _tictailServer; }}
    }
}
