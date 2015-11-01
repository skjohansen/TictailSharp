using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using TictailSharp.Api.Model.Product;
using TictailSharp.Api.Model.Store;

namespace TictailSharp.Api.Model
{
    /// <summary>
    /// All basic information on a Tictail Store
    /// </summary>
    public abstract class BaseStore
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Store name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Short description of the store
        /// </summary>
        [JsonProperty(PropertyName = "short_description")]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Number of followers
        /// </summary>
        [JsonProperty(PropertyName = "followers")]
        public int NumberOfFollowers { get; set; }

        /// <summary>
        /// Currency of the store as a three-letter code (ISO 4217)
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// VAT settings of the store
        /// </summary>
        [JsonProperty(PropertyName = "vat")]
        public Vat Vat { get; set; }

        /// <summary>
        /// Language of the store as a two-letter code (ISO 639-1)
        /// </summary>
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        /// <summary>
        /// Country of the store as two-letter code (ISO 3166-1 alpha-2)
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        /// List with the logotype
        /// </summary>
        [JsonProperty(PropertyName = "logotype")]
        public List<ProductImage> Logotypes { get; set; }

        //Map of wallpapers by their categories
        //TODO: Wallpapers

        /// <summary>
        /// Description of the store
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// URL to store
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Store subdomain
        /// </summary>
        [JsonProperty("subdomain")]
        public string Subdomain { get; set; }

        /// <summary>
        /// Timestamp when this store was created
        /// </summary>
        [JsonProperty(PropertyName = "created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Timestamp when this store was last modified
        /// </summary>
        [JsonProperty(PropertyName = "modified_at")]
        public DateTime? ModifiedAt { get; set; }

        /// <summary>
        /// Contact email for customers
        /// </summary>
        [JsonProperty(PropertyName = "contact_email")]
        public string ContactEmail { get; set; }

        /// <summary>
        /// Email to storekeeper
        /// </summary>
        [JsonProperty(PropertyName = "storekeeper_email")]
        public string StorekeeperEmail { get; set; }

        /// <summary>
        /// Whether or not this store is a sandbox store
        /// </summary>
        [JsonProperty(PropertyName = "sandbox")]
        public bool Sandbox { get; set; }

        /// <summary>
        /// URL to stores dashboard
        /// </summary>
        [JsonProperty(PropertyName = "dashboard_url")]
        public string DashboardUrl { get; set; }

        /// <summary>
        /// The currency used for appstore purchases
        /// </summary>
        [JsonProperty(PropertyName = "appstore_currency")]
        public string AppstoreCurrency { get; set; }

        /// <summary>
        /// Output all properties
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString()
        {

            var toString = new StringBuilder();
            toString.Append("ID: ").AppendLine(Id);
            toString.Append("Name: ").AppendLine(Name);
            toString.Append("ShortDescription: ").AppendLine(ShortDescription);
            toString.Append("Followers: ").AppendLine(NumberOfFollowers.ToString(CultureInfo.InvariantCulture));
            toString.Append("Currency: ").AppendLine(Currency);
            toString.Append("Vat: ").AppendLine(Vat.ToString());
            toString.Append("Language: ").AppendLine(Language);
            toString.Append("Country: ").AppendLine(Country);
            if (Logotypes != null && Logotypes.Count > 0)
            {
                foreach (var logotype in Logotypes)
                {
                    toString.Append("Logotype: ").AppendLine(logotype.ToString());
                }

            }
            // TODO:Wallpapers
            toString.Append("Description: ").AppendLine(Description);
            toString.Append("Url: ").AppendLine(Url);
            toString.Append("Subdomain: ").AppendLine(Subdomain);
            if (CreatedAt.HasValue)
            {
                toString.Append("CreatedAt: ").AppendLine(CreatedAt.Value.ToString());
            }
            if (ModifiedAt.HasValue)
            {
                toString.Append("ModifiedAt: ").AppendLine(ModifiedAt.Value.ToString());
            }
            toString.Append("ContactEmail: ").AppendLine(ContactEmail);
            toString.Append("StorekeeperEmail: ").AppendLine(StorekeeperEmail);
            toString.Append("Sandbox: ").AppendLine(Sandbox.ToString());
            toString.Append("DashboardUrl: ").AppendLine(DashboardUrl);
            toString.Append("AppstoreCurrency: ").AppendLine(AppstoreCurrency);
            return toString.ToString();
        }
    }
}
