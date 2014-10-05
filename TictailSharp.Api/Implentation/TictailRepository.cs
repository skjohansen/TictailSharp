﻿using TictailSharp.Api.Repository;

namespace TictailSharp.Api.Implentation
{
    public class TictailRepository
    {
        private readonly ITictailClient _client = null;

        private IStoreRepository _storeRepository;
        private IMeRepository _meRepository;

        public TictailRepository(TictailEndpoint endpoint)
            : this(new TictailClient(endpoint))
        {
        }

        public TictailRepository(ITictailClient client)
        {
            _client = client;
        }

        public IStoreRepository Stores
        {
            get { return _storeRepository ?? (_storeRepository = new StoreRepository(_client)); }
        }

        public IMeRepository Me
        {
            get { return _meRepository ?? (_meRepository = new MeRepository(_client)); }
        } 
    }
}