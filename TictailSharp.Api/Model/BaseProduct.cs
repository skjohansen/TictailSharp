using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using TictailSharp.Api.Converters;

namespace TictailSharp.Api.Model
{
    /// <summary>
    /// Base product which defines all comon parts of products
    /// </summary>
    public abstract class BaseProduct
    {
        /// <summary>
        /// Title of the product
        /// </summary>
        /// <example>Basil</example>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Description, can include some HTML
        /// </summary>
        /// <example>Nice basil</example>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Status, one of published, unpublished, deleted
        /// </summary>
        /// <example>published</example>
        [JsonProperty(PropertyName = "status")]
        [JsonConverter(typeof(LowercaseConverter))]
        public ProductStatus Status { get; set; }

        /// <summary>
        /// Price, in cents
        /// </summary>
        /// <example>2500</example>
        [JsonProperty(PropertyName = "price")]
        public uint Price { get; set; }

        /// <summary>
        /// An URL-safe slug of this product's title
        /// </summary>
        /// <example>basil</example>
        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Which categories does this product belong to?
        /// </summary>
        [JsonProperty(PropertyName = "categories")]
        public List<Category.Category> Categories { get; set; }

        /// <summary>
        /// Output all properties
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append("Title: ").AppendLine(Title);
            toString.Append("Description: ").AppendLine(Description);
            toString.Append("Status: ").AppendLine(Status.ToString());
            toString.Append("Price: ").AppendLine(Price.ToString(CultureInfo.InvariantCulture));
            toString.Append("Slug: ").AppendLine(Slug);
            
            return toString.ToString();
        }
    }
}
