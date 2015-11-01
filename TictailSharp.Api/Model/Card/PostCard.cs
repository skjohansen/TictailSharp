using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model.Card
{
    public class PostCard
    {
        /// <summary>
        /// An action-oriented summary of what you want the user to do
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// One of the card types enabled for your app.
        /// </summary>
        [JsonProperty(PropertyName = "card_type")]
        public CardType CardType { get; set; }
        
        /// <summary>
        /// Action url that the user will end up on when performing a card
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        public Uri Action { get; set; }

        /// <summary>
        /// A dictionary containing the content to render in the card.
        /// </summary>
        [JsonProperty(PropertyName = "content")]
        public Dictionary<string, string> Content { get; set; }
    }
}
