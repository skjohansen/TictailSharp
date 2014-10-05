using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model
{
    public class ShippingAlternative
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        
        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The price at which this shipping alternative becomes free or null if the store did not set such price
        /// </summary>
        [JsonProperty(PropertyName = "free_at_price")]
        public int FreeAtPrice { get; set; }

        /// <summary>
        /// Price for this shipping alternative, in cents
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public int Price { get; set; }

        /// <summary>
        /// Currency for this alternative as a three-letter code (ISO 4217)
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Minimum expected delivery days
        /// </summary>
        [JsonProperty(PropertyName = "minimum_delivery_days")]
        public int MinimumDeliveryDays { get; set; }

        /// <summary>
        /// Maximum expected delivery days
        /// </summary>
        [JsonProperty(PropertyName = "maximum_delivery_days")]
        public int MaximumDeliveryDays { get; set; }

        /// <summary>
        /// List of destinations this alternative is valid for as a two-letter code (ISO3166-1)
        /// </summary>
        [JsonProperty(PropertyName = "regions")]
        public List<string> Regions { get; set; }

        /// <summary>
        /// Timestamp when this shipping alternative was created
        /// </summary>
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Timestamp when this shipping alternative was last modified
        /// </summary>
        [JsonProperty(PropertyName = "modified_at")]
        public DateTime? ModifiedAt { get; set; }


        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("Id: ").AppendLine(Id);
            toString.Append("Title: ").AppendLine(Title);
            toString.Append("Description: ").AppendLine(Description);
            toString.Append("FreeAtPrice: ").AppendLine(FreeAtPrice.ToString(CultureInfo.InvariantCulture));
            toString.Append("Price: ").AppendLine(Price.ToString(CultureInfo.InvariantCulture));
            toString.Append("Currency: ").AppendLine(Currency);
            toString.Append("MinimumDeliveryDays: ").AppendLine(MinimumDeliveryDays.ToString(CultureInfo.InvariantCulture));
            toString.Append("MaximumDeliveryDays: ").AppendLine(MaximumDeliveryDays.ToString(CultureInfo.InvariantCulture));
            toString.Append("Regions: ").AppendLine(Regions.Count.ToString(CultureInfo.InvariantCulture));
            foreach (var region in Regions)
            {
                toString.Append("Region:").AppendLine(region);
            }

            toString.Append("CreatedAt: ").AppendLine(CreatedAt.ToString(CultureInfo.InvariantCulture));
            if (ModifiedAt.HasValue)
            {
                toString.Append("ModifiedAt: ").AppendLine(ModifiedAt.Value.ToString(CultureInfo.InvariantCulture)).AppendLine();
            }
            toString.Append("Currency: ").AppendLine(Currency);
            return toString.ToString();
        }
    }
}
