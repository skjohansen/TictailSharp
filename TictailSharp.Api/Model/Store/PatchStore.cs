using Newtonsoft.Json;

namespace TictailSharp.Api.Model.Store
{
    public class PatchStore
    {
        /// <summary>
        /// The name of the store
        /// </summary>
        [JsonProperty("name")]
        //[JsonIgnore]
        public string Name { get; set; }

        /// <summary>
        /// A longer description of the store, some HTML is ok
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// A short description of the store, no HTML
        /// </summary>
        [JsonProperty("short_description")]
        //[JsonIgnore]
        public string ShortDescription { get; set; }

        /// <summary>
        /// The store's currency, as a three-letter code
        /// </summary>
        [JsonProperty("currency")]
        //[JsonIgnore]
        public string Currency { get; set; }

        /// <summary>
        /// The store's language as a two-letter code
        /// </summary>
        [JsonProperty("language")]
        //[JsonIgnore]
        public string Language { get; set; }

        /// <summary>
        /// The store's country as a two-letter code
        /// </summary>
        [JsonProperty("country")]
        //[JsonIgnore]
        public string Country { get; set; }

        /// <summary>
        /// See VAT object for details
        /// </summary>
        [JsonProperty("vat")]
        //[JsonIgnore]
        public string Vat { get; set; }
    }
}
