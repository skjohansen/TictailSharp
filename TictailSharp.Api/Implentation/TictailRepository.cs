using TictailSharp.Api.Repository;

namespace TictailSharp.Api.Implentation
{
    /// <summary>
    /// Works as an  entrypoint to all the tictail resources, giving a structure simulare to the URL structure of the API
    /// </summary>
    public class TictailRepository
    {
        private readonly ITictailClient _client;

        private IStoreRepository _storeRepository;
        private IMeRepository _meRepository;
        private IOauthRespository _oauthRepository;

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
        public IStoreRepository Stores
        {
            get { return _storeRepository ?? (_storeRepository = new StoreRepository(_client)); }
        }

        /// <summary>
        /// The Me ressouce
        /// </summary>
        public IMeRepository Me
        {
            get { return _meRepository ?? (_meRepository = new MeRepository(_client)); }
        }

        /// <summary>
        /// The Oauth ressource
        /// </summary>
        public IOauthRespository Oauth
        {
            //TODO: This should be removed is not part of the repository
            get { return _oauthRepository ?? (_oauthRepository = new OauthRepository(_client)); }
        }
    }
}
