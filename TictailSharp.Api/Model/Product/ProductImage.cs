using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace TictailSharp.Api.Model.Product
{
    /// <summary>
    /// Image of an product
    /// </summary>
    public class ProductImage : BaseProductImage
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Timestamp when this image was created
        /// </summary>
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Timestamp when this image was last modified
        /// </summary>
        [JsonProperty(PropertyName = "modified_at")]
        public DateTime ModifiedAt { get; set; }

        /// <summary>
        /// The image URL
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// An object with urls keyed by the different sizes of this image, 30, 40, 45, 50, 75, 100, 300, 500, 1000 and 2000
        /// </summary>
        [JsonProperty(PropertyName = "sizes")]
        public Dictionary<string, string> Sizes { get; set; }

        /// <summary>
        /// Output all properties
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("ID: ").AppendLine(Id);
            toString.Append("CreatedAt: ").AppendLine(CreatedAt.ToString(CultureInfo.InvariantCulture));
            toString.Append("ModifiedAt: ").AppendLine(ModifiedAt.ToString(CultureInfo.InvariantCulture)).AppendLine();
            toString.Append("OriginalWidth: ").AppendLine(OriginalWidth.ToString(CultureInfo.InvariantCulture));
            toString.Append("OriginalHeight: ").AppendLine(OriginalHeight.ToString(CultureInfo.InvariantCulture));
            toString.Append("Url: ").AppendLine(Url);
            toString.Append("Sizes: ").AppendLine(Sizes.Keys.Count.ToString(CultureInfo.InvariantCulture));
            foreach (var size in Sizes)
            {
                toString.Append(size.Key).Append(" - ").AppendLine(size.Value);
            }
            return toString.ToString();
        }
    }
}
