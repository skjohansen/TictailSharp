using TictailSharp.Api.Resources;

namespace TictailSharp.Api.Implentation
{
    /// <summary>
    /// Works as an  entrypoint to all the tictail resources, giving a structure simulare to the URL structure of the API
    /// </summary>
    public class TictailRepository
    {
        private readonly ITictailClient _client;

        private IStoreResource _storeResource;
        private IMeResource _meResource;
        private IOauthResource _oauthResource;

        /// <summary>
        /// Construct the repository with an endpoint
        /// </summary>
        /// <param name="endpoint">A Tictail endpoint</param>
        public TictailRepository(TictailEndpoint endpoint)
            : this(new TictailClient(endpoint))
        {
        }

        /// <summary>
        /// Construct the repository with a client
        /// </summary>
        /// <param name="client">A TictailClient</param>
        public TictailRepository(ITictailClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Store ressources within the repository
        /// </summary>
        public IStoreResource Stores
        {
            get { return _storeResource ?? (_storeResource = new StoreResource(_client)); }
        }

        /// <summary>
        /// The Me ressouce
        /// </summary>
        public IMeResource Me
        {
            get { return _meResource ?? (_meResource = new MeResource(_client)); }
        }

        /// <summary>
        /// The Oauth ressource
        /// </summary>
        public IOauthResource Oauth
        {
            //TODO: This should be removed is not part of the repository
            get { return _oauthResource ?? (_oauthResource = new OauthResource(_client)); }
        }
    }
}
