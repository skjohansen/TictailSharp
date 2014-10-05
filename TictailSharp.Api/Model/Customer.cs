using System;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model
{
    /// <summary>
    /// The customer may always be right, we don't pretend to know. All customers that have made a purchase from a given store are found in this resource, though.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Email to the customer, note that this can be a proxy email address
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Full name of the customer
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Country of the customer as a two-letter code (ISO 3166-1)
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        /// Preferred language of the customers as a two-letter code (ISO 639-1)
        /// </summary>
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        /// <summary>
        /// Timestamp when this product was created
        /// </summary>
        /// <example>2013-12-18T21:57:07</example>
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Timestamp when this product was last modified
        /// </summary>
        /// <example>2013-12-18T21:57:07</example>
        [JsonProperty(PropertyName = "modified_at")]
        public DateTime? ModifiedAt { get; set; }

        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("ID: ").AppendLine(Id);
            toString.Append("Email: ").AppendLine(Email);
            toString.Append("Name: ").AppendLine(Name);
            toString.Append("Country: ").AppendLine(Country);
            toString.Append("Language: ").AppendLine(Language);
            toString.Append("CreatedAt: ").AppendLine(CreatedAt.ToString(CultureInfo.InvariantCulture));
            if (ModifiedAt.HasValue)
            {
                toString.Append("ModifiedAt: ").AppendLine(ModifiedAt.Value.ToString(CultureInfo.InvariantCulture)).AppendLine();
            }
            return toString.ToString();
        }
    }
}
