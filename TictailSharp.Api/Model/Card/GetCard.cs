using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model.Card
{
    /// <summary>
    /// TODO Needs to be implemented
    /// </summary>
    public class GetCard
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "card_type")]
        public CardType CardType { get; set; }

        /// <summary>
        /// Action url that the user will end up on when performing a card
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        public Uri Action { get; set; }
        [JsonProperty(PropertyName = "content")]
        public Dictionary<string, string> Content { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty(PropertyName = "modified_at")]
        public DateTime? ModifiedAt { get; set; }

        // //id
        //title
        //card_type
        //content
        //action
        // //created_at
        // //modified_at

    }
}
