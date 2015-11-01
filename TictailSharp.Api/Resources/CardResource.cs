using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using TictailSharp.Api.Model.Card;

namespace TictailSharp.Api.Resources
{
    /// <summary>
    /// Not yet implemented!
    /// </summary>
    public class CardResource : ICardResource
    {
        private readonly ITictailClient _client;

        public CardResource(ITictailClient client, string storeId)
        {
            _client = client;
            StoreId = storeId;
        }

        #region Interface
        //

        /// <summary>
        /// Store to post cards to
        /// POST /v1/stores/[store_id]/cards
        /// </summary>
        public string StoreId { get; set; }

        #endregion

        #region Tests
        #endregion

        /// <summary>
        /// Get a specific card
        /// </summary>
        /// <param name="cardId">ID of card</param>
        /// <returns>Retrived Card</returns>
        public GetCard Get(string cardId)
        {
            if (string.IsNullOrEmpty(cardId))
            {
                throw new Exception("You must provide a valid card Id");
            }

            if (string.IsNullOrEmpty(StoreId))
            {
                throw new Exception("You must provide a valid store Id");
            }

            var request = new RestRequest("v1/stores/{storeId}/cards/{cardId}", Method.GET);
            request.AddUrlSegment("storeId", StoreId);
            request.AddUrlSegment("cardId", cardId);

            try
            {
                var content = _client.ExecuteRequest(request, HttpStatusCode.OK).Content;
                return DeserializeGet(content);
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("No Card found with ID : " + cardId + ", at store : " + StoreId);
            }
        }

        /// <summary>
        /// Deserlize card data
        /// </summary>
        /// <param name="data">JSON Card data</param>
        /// <returns>A Card object</returns>
        public GetCard DeserializeGet(string data)
        {
            return JsonConvert.DeserializeObject<GetCard>(data);
        }

        /// <summary>
        /// Get a specific card
        /// </summary>
        /// <param name="resourceId">ID of card</param>
        /// <returns>Retrived Card</returns>
        public GetCard this[string resourceId]
        {
            get { return Get(resourceId); }
        }

        /// <summary>
        /// Post a card
        /// </summary>
        /// <param name="card">Card data</param>
        /// <returns>Url of the created card</returns>
        public GetCard Post(PostCard card)
        {
            if (string.IsNullOrEmpty(StoreId))
            {
                throw new Exception("You can't specify an empty storeId");
            }

            var request = new RestRequest("v1/stores/{storeId}/cards", Method.POST);
            request.AddUrlSegment("storeId", StoreId);
            request.RequestFormat = DataFormat.Json;

            var serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            string bodyContent;
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, card);
                bodyContent = writer.ToString();
            }

            request.AddParameter("application/json", bodyContent, ParameterType.RequestBody);

            GetCard createdCard;
            try
            {
                createdCard = DeserializeGet(_client.ExecuteRequest(request, HttpStatusCode.Created).Content);
            }
            catch (KeyNotFoundException)
            {
                throw new Exception("No Store found with ID : " + StoreId);
            }

            return createdCard;
        }
    }
}
