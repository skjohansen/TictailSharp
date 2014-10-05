using System;

namespace TictailSharp.Api.Repository
{
    public class CardRepository : ICardRepository
    {
        #region Interface
        //POST /v1/stores/<store_id>/cards
        public string StoreId
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Post(Model.Card value)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Tests
        #endregion
    }
}
