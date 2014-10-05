using Newtonsoft.Json;

namespace TictailSharp.Api.Model
{
    public abstract class BaseItem
    {
        /// <summary>
        /// Total price of this line item, in cents
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public int Price { get; set; }

        /// <summary>
        /// Currency code (ISO 4217) of item price
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Number of this item in the order
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

    }
}
