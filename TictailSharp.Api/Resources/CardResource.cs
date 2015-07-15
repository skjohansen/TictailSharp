using System;
using TictailSharp.Api.Model.Card;

namespace TictailSharp.Api.Resources
{
    /// <summary>
    /// Not yet implemented!
    /// </summary>
    public class CardResource : ICardResource
    {
        #region Interface
        //

        /// <summary>
        /// Store to post cards to
        /// POST /v1/stores/[store_id]/cards
        /// </summary>
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

        /// <summary>
        /// Post a card
        /// </summary>
        /// <param name="value">Card data</param>
        /// <returns>Url of the created card</returns>
        public string Post(Card value)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Tests
        #endregion

        /// <summary>
        /// Get a specific card
        /// </summary>
        /// <param name="resourceId">ID of card</param>
        /// <returns>Retrived Card</returns>
        public Card Get(string resourceId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deserlize card data
        /// </summary>
        /// <param name="data">JSON Card data</param>
        /// <returns>A Card object</returns>
        public Card DeserializeGet(string data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a specific card
        /// </summary>
        /// <param name="resourceId">ID of card</param>
        /// <returns>Retrived Card</returns>
        public Card this[string resourceId]
        {
            get { return Get(resourceId); }
        }
    }
}
