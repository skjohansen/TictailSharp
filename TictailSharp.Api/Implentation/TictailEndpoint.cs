using System;

namespace TictailSharp.Api.Implentation
{
    /// <summary>
    /// Defines the information needed to access the Tictail API
    /// </summary>
    public class TictailEndpoint
    {
        private readonly Uri _tictailServer;

        /// <summary>
        /// Constructor with URL
        /// </summary>
        /// <param name="url">URL to the Tictail API</param>
        public TictailEndpoint(Uri url)
        {
            _tictailServer = url;
        }

        /// <summary>
        /// Constructor with URL and AccessToken
        /// </summary>
        /// <param name="url">URL to the Tictail API</param>
        /// <param name="accessToken">AccessToken which identifies the user with the API</param>
        public TictailEndpoint(Uri url, string accessToken)
        {
            AccessToken = accessToken;
            _tictailServer = url;
           
        }

        /// <summary>
        /// AccessToken which identifies the user with the API
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// URL to the Tictail API
        /// </summary>
        public Uri TictailServerUri {get { return _tictailServer; }}
    }
}
